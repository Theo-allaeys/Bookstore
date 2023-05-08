using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;
using Bookstore.Data;
using Bookstore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private readonly AuthorService _authorService = new AuthorService();
        private readonly Bookservice _bookservice = new Bookservice();
        private readonly GenreService _genreService = new GenreService();
        private readonly BookDbContext _dbContext;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        public BookController(BookDbContext dbContext, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            IEnumerable<BookModel> models = _bookservice.GetBooks();
            return View(models);
        }

        public IActionResult Create()
        {
            BookModel model = new BookModel();
            model.Authors = _authorService.GetAll();
            model.Genres = _genreService.GetAll();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookModel model)
        {
            var uniqueFileName = Path.GetFileNameWithoutExtension(model.img.FileName) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(model.img.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
            var filePath = Path.Combine(uploads, uniqueFileName);
            model.img.CopyTo(new FileStream(filePath, FileMode.Create));
            model.ImgUrl = uniqueFileName;
            int id = _bookservice.CreateBook(model);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int id)
        {
            Book book= _bookservice.GetBook(id);
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            BookModel book = _bookservice.GetBookModel(id);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookModel model)
        {
            var uniqueFileName = Path.GetFileNameWithoutExtension(model.img.FileName) + "_" + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(model.img.FileName);
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
            var filePath = Path.Combine(uploads, uniqueFileName);
            model.img.CopyTo(new FileStream(filePath, FileMode.Create));
            model.ImgUrl = uniqueFileName;
            int id = _bookservice.EditBook(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
