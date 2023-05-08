namespace Bookstore.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthdate { get; set; }
        public ICollection<Book> books { get; set; }
    }
}
