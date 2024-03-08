using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using music_store.Data;
using music_store.Models;

namespace music_store.Controllers
{
    public class AlbumController : Controller
    {
        private readonly music_storeContext _context;

        public AlbumController(music_storeContext context)
        {
            _context = context;
        }

        // GET: Album
        public async Task<IActionResult> Index()
        {
            var music_storeContext = _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre);
            return View(await music_storeContext.ToListAsync());
        }

        // GET: Album/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        public async Task<IActionResult> AlbumSongs()
        {
            var album = await _context.Album
                .Include(a => a.Songs)
                .ToListAsync();

            return View(album);
        }

        // GET: Album/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Name");
            ViewData["GenreId"] = new SelectList(_context.Genre, "GenreId", "Name");
            return View();
        }

        // POST: Album/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // GET: Album/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album = await _context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "Name", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "Name", album.GenreId);
            return View(album);
        }

        // POST: Album/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,GenreId,ArtistId,Title,Price,AlbumArtUrl")] Album album)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "ArtistId", "ArtistId", album.ArtistId);
            ViewData["GenreId"] = new SelectList(_context.Set<Genre>(), "GenreId", "GenreId", album.GenreId);
            return View(album);
        }

        // GET: Album/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Album == null)
            {
                return NotFound();
            }

            var album = await _context.Album
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Album/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Album == null)
            {
                return Problem("Entity set 'music_storeContext.Album'  is null.");
            }
            var album = await _context.Album.FindAsync(id);
            if (album != null)
            {
                _context.Album.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return (_context.Album?.Any(e => e.AlbumId == id)).GetValueOrDefault();
        }
    }
}
