using Microsoft.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class BookDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BookDB;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
            .HasOne(x => x.Author)
            .WithMany(x => x.books)
            .HasForeignKey(x => x.AuthorFK)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Book>()
            .HasOne(x => x.Genre)
            .WithMany(x => x.books)
            .HasForeignKey(x => x.GenreFK)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Genre>()
                .HasData(
                new Genre() { Id = 1, Name = "Fantasy" },
                new Genre() { Id = 2, Name = "Science Fiction" },
                new Genre() { Id = 3, Name = "Dystopian" },
                new Genre() { Id = 4, Name = "Action & Adventure" },
                new Genre() { Id = 5, Name = "Mystery" },
                new Genre() { Id = 6, Name = "Horror" },
                new Genre() { Id = 7, Name = "Thriller & Suspense" },
                new Genre() { Id = 8, Name = "Historical Fiction" },
                new Genre() { Id = 9, Name = "Romance" },
                new Genre() { Id = 10, Name = "Fantasy" }
                );
        }

        public DbSet<Book> Books { get; set;}
        public DbSet<Genre> Genres { get; set;}
        public DbSet<Author> Author { get; set;}

    }
}
