using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookstore.Data;
using Bookstore.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class AuthorController : Controller
    {
        private readonly BookDbContext _dbContext;
        private readonly AuthorService _service = new AuthorService();

        public AuthorController(BookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _dbContext.Author.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAuthorCommand author)
        {
            if (ModelState.IsValid)
            {
                int id = _service.CreateAuthor(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        public IActionResult Edit(int id)
        {
            Author command = _service.GetAuthor(id);
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EditAuthorBase command)
        {
            if (ModelState.IsValid)
            {
                _service.EditAuthor(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Address/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await _dbContext.Author
                .FirstOrDefaultAsync(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        // POST: Address/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _dbContext.Author.FindAsync(id);
            _dbContext.Author.Remove(author);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
