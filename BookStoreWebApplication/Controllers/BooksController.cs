using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreWebApplication.Models;

namespace BookStoreWebApplication.Controllers
{
	public class BooksController : Controller
	{
		private readonly DbbookStoreContext _context;

		public BooksController(DbbookStoreContext context)
		{
			_context = context;
		}

		// GET: Books
		public async Task<IActionResult> Index()
		{
			var books = await _context.Books.Include(b => b.BooksGenres).ThenInclude(b => b.Genre).ToListAsync();

			return View(books);
		}

		// GET: Books/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Books == null)
			{
				return NotFound();
			}

			var book = await _context.Books.Include(b => b.BooksGenres).ThenInclude(g => g.Genre)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			return View(book);
		}

		// GET: Books/Create
		public async Task<IActionResult> Create()
		{
			ViewBag.AllGenres = await _context.Genres.ToListAsync();
			return View();
		}

		// POST: Books/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,PublicationYear,Genre,CoverType,Price,GenreIds")] Book book)
		{
			if (ModelState.IsValid)
			{
				var selectedGenres = (await _context.Genres.ToListAsync())
						.FindAll(g => book.GenreIds.Contains(g.Id));
				_context.Add(book);
				foreach (var genre in selectedGenres)
				{
					var bookGenre = new BooksGenre { Book = book, GenreId = genre.Id };
					_context.Add(bookGenre);
				}
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(book);
		}

		// GET: Books/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Books == null)
			{
				return NotFound();
			}

			var book = await _context.Books.Include(b => b.BooksGenres).ThenInclude(b => b.Genre).FirstAsync(book => book.Id == id);
			if (book == null)
			{
				return NotFound();
			}
			ViewBag.AllGenres = await _context.Genres.ToListAsync();

			return View(book);
		}

		// POST: Books/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PublicationYear,CoverType,Price,GenreIds")] Book book)
		{
			if (id != book.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var prevSelectedGenres = await _context.BooksGenres.ToListAsync();
					var prevSelectedGenresIds = prevSelectedGenres
						.FindAll(g => g.BookId == book.Id)
						.Select(g => g.GenreId).ToList();
					var selectedGenres = (await _context.Genres.ToListAsync())
						.FindAll(g => book.GenreIds.Contains(g.Id));
					var selectedGenresIds = selectedGenres
						.Select(g => g.Id);

					var genresToAdd = selectedGenres.FindAll(genre => !prevSelectedGenresIds.Contains(genre.Id));
					var genresIdsToDelete = prevSelectedGenresIds.FindAll(pg => !selectedGenresIds.Contains(pg));

					var genresToDelete = prevSelectedGenres.FindAll(g => genresIdsToDelete.Contains(g.GenreId));
					foreach (var genre in genresToDelete)
					{
						_context.Remove(genre);
					}
                    foreach (var genre in genresToAdd)
                    {
						var bookGenre = new BooksGenre { GenreId = genre.Id, BookId = book.Id };
						_context.Add(bookGenre);
						book.BooksGenres.Add(bookGenre);
					}
					_context.Update(book);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!BookExists(book.Id))
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
			return View(book);
		}

		// GET: Books/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Books == null)
			{
				return NotFound();
			}

			var book = await _context.Books
                .Include(b => b.BooksGenres).ThenInclude(b => b.Genre)
                .FirstOrDefaultAsync(m => m.Id == id);
			if (book == null)
			{
				return NotFound();
			}

			return View(book);
		}

		// POST: Books/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Books == null)
			{
				return Problem("Entity set 'DbbookStoreContext.Books'  is null.");
			}
			var book = await _context.Books.FindAsync(id);
			if (book != null)
			{
				_context.Books.Remove(book);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool BookExists(int id)
		{
			return _context.Books.Any(e => e.Id == id);
		}
	}
}
