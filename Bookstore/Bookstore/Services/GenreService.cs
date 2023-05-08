using Bookstore.Data;

namespace Bookstore.Services
{
    public class GenreService
    {
        public IEnumerable<Genre> GetAll()
        {
            using (var context = new BookDbContext())
            {
                return context.Genres.ToList();
            }
        }
    }
}
