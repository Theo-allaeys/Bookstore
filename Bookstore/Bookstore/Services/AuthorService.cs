using Bookstore.Data;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Services
{
    public class AuthorService
    {
        public int CreateAuthor(CreateAuthorCommand command)
        {
            using (var context = new BookDbContext())
            {
                Author entity = command.ToAuthor();

                context.Author.Add(entity);
                context.SaveChanges();

                return entity.Id;
            }
        }

        public Author GetById(int id)
        {
            using (var context = new BookDbContext())
            {
                return context.Author.Find(id);
            }
        }

        public Author GetAuthor(int id)
        {
            using (var context = new BookDbContext())
            {
                Author author = context.Author.First(x => x.Id == id);
                return author;
            }
        }

        public int EditAuthor(EditAuthorBase model)
        {
            using (var context = new BookDbContext())
            {
                Author author = context.Author.Find(model.Id);

                author.firstName = model.firstname;
                author.lastName = model.lastname;
                author.birthdate = model.birthdate;

                context.SaveChanges();

                return author.Id;
            }   
            
        }

        public IEnumerable<Author> GetAll()
        {
            using (var context = new BookDbContext())
            {
                return context.Author.ToList();
            }
        }
    }
}
