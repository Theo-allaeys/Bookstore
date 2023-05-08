namespace Bookstore.Data
{

public class Book
    {
        public enum formats { hardcover, paperback, Ebook }
        public int Id { get; set; }
        public string Title { get; set; }
        public string isbn13 { get; set; }
        public int pages { get; set; }
        public int price { get; set; }
        public formats Format { get; set; }
        public string ImgUrl { get; set; }
        public int AuthorFK { get; set; }
        public Author Author { get; set; }
        public int GenreFK { get; set; }
        public Genre Genre { get; set; }
    }
}
