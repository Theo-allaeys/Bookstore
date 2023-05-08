using Bookstore.Data;
using static Bookstore.Data.Book;

namespace Bookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string isbn13 { get; set; }
        public int pages { get; set; }
        public int price { get; set; }
        public formats Format { get; set; }
        public IFormFile img { get; set; }
        public string ImgUrl { get; set; }
        public Author Author { get; set; }
        public int author { get; set; }
        public Genre genre { get; set; }
        public int Genre { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Genre> Genres { get; set;}

    }
}
