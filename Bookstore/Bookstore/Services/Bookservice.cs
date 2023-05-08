using Bookstore.Data;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services
{
    public class Bookservice
    {

        public int CreateBook(BookModel model)
        {
            using (var context = new BookDbContext())
            {
                Book emp = new Book();
                emp.Title = model.Title;
                emp.isbn13 = model.isbn13;
                emp.pages= model.pages;
                emp.price = model.price;
                emp.Format = model.Format;
                emp.AuthorFK = model.author;
                emp.GenreFK = model.Genre;
                emp.ImgUrl= model.ImgUrl;

                context.Books.Add(emp);
                context.SaveChanges();

                return emp.Id;
            }
        }

        public IEnumerable<BookModel> GetBooks()
        {
            using(var context = new BookDbContext())
            {
                return context.Books.Select(x => new BookModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    price = x.price,
                    ImgUrl = x.ImgUrl,
                    Author = context.Author.First(Author => Author.Id == x.AuthorFK),
                    genre = context.Genres.First(Genre => Genre.Id == x.GenreFK)
                }).ToList();
            }
        }

        public Book GetBook(int id)
        {
            using(var context = new BookDbContext())
            {
                Book book = context.Books.First(x => x.Id == id);
                book.Author = context.Author.Find(book.AuthorFK);
                book.Genre = context.Genres.Find(book.GenreFK);
                return book;
            }
        }

        public BookModel GetBookModel(int id)
        {
            using(var context = new BookDbContext())
            {
                Book book = GetBook(id);
                BookModel model = new()
                {
                    Id = book.Id,
                    Title = book.Title,
                    isbn13 = book.isbn13,
                    pages = book.pages,
                    price = book.price,
                    Format = book.Format,
                    Genre = book.GenreFK,
                    author = book.AuthorFK,
                    ImgUrl= book.ImgUrl,
                };
             return model;
            }
        }

        public int EditBook(BookModel model)
        {
            using (var context = new BookDbContext())
            {
                Book book = GetBook(model.Id);
                book.Title = model.Title;
                book.isbn13 = model.isbn13;
                book.pages = model.pages;
                book.price = model.price;
                book.Format = model.Format;
                book.ImgUrl = model.ImgUrl;
                book.AuthorFK = model.author;
                book.GenreFK = model.Genre;
                context.SaveChanges();
                return book.Id;
            }
        }
    }
}
