﻿namespace Bookstore.Data
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> books { get; set; }
    }
}
