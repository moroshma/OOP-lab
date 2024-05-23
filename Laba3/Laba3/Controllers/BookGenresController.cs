using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Laba3.Data;
using Laba3.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace Laba3.Controllers
{
    public class BookGenresController : Controller
    {
        private readonly DataContext _context;

        public BookGenresController(DataContext context)
        {
            _context = context;
        }

        // GET: BookGenres
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.BookGenres.Include(b => b.Book).Include(b => b.Genre);
            return View(await dataContext.ToListAsync());
        }

        // GET: BookGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookGenreId == id);
            if (bookGenre == null)
            {
                return NotFound();
            }

            return View(bookGenre);
        }

        // GET: BookGenres/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title");
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId");
            return View();
        }

        // POST: BookGenres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookGenreId,Book,Genre")] BookGenre bookGenre)
        {
            if (ModelState.IsValid)
            {
                var bookGenreTemp = await _context.BookGenres
                    .Include(b => b.Book)
                    .Include(b => b.Genre).ToListAsync();
                if (bookGenreTemp.Count == 0)
                    ++bookGenre.BookGenreId;
                else
                {
                    
                    bookGenre.BookGenreId = bookGenreTemp[^1].BookGenreId + 1;
                }
                _context.Add(bookGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Title", bookGenre.Book);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", bookGenre.Genre);
            return View(bookGenre);
        }

        // GET: BookGenres/Edit/5
        public async Task<IActionResult> Edit(int? BookGenreId)
        {
            if (BookGenreId == null)
            {
                return NotFound();
            }
            var bookGenre = await _context.BookGenres
               .Include(b => b.Book)
               .Include(b => b.Genre)
               .FirstOrDefaultAsync(m => m.BookGenreId == BookGenreId);
            if (bookGenre == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookGenre.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", bookGenre.GenreId);
            return View(bookGenre);
        }

        // POST: BookGenres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookGenreId,BookId,GenreId")] BookGenre bookGenre)
        {
            if (5 != bookGenre.BookGenreId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookGenreExists(bookGenre.BookGenreId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "BookId", bookGenre.BookId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", bookGenre.GenreId);
            return View(bookGenre);
        }

        // GET: BookGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGenre = await _context.BookGenres
                .Include(b => b.Book)
                .Include(b => b.Genre)
                .FirstOrDefaultAsync(m => m.BookGenreId == id);
            if (bookGenre == null)
            {
                return NotFound();
            }

            return View(bookGenre);
        }

        // POST: BookGenres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var bookGenre = await _context.BookGenres
               .Include(b => b.Book)
               .Include(b => b.Genre)
               .FirstOrDefaultAsync(m => m.BookGenreId == id);
            if (bookGenre != null)
            {
                _context.BookGenres.Remove(bookGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookGenreExists(int id)
        {
            return _context.BookGenres.Any(e => e.BookGenreId == id);
        }
    }
}
