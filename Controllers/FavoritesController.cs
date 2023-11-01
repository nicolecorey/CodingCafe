using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodingCafe.Models;

namespace CodingCafe.Controllers
{
    public class FavoritesController : Controller
    {
        private readonly CafeContext _context;

        public FavoritesController(CafeContext context)
        {
            _context = context;
        }

        // GET: Favorites
        public async Task<IActionResult> Index()
        {
              return _context.Favorites != null ? 
                          View(await _context.Favorites.ToListAsync()) :
                          Problem("Entity set 'CafeContext.Favorites'  is null.");
        }

        // GET: Favorites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Favorites == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites
                .FirstOrDefaultAsync(m => m.FavoritesId == id);
            if (favorites == null)
            {
                return NotFound();
            }

            return View(favorites);
        }

        // GET: Favorites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Favorites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FavoritesId,Name,Description")] Favorites favorites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(favorites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(favorites);
        }

        // GET: Favorites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Favorites == null)
            {
                return NotFound();
            }

            var item = await _context.Favorites.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Favorites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FavoritesId,Name,Description")] Favorites favorites)
        {
            if (id != favorites.FavoritesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(favorites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FavoritesExists(favorites.FavoritesId))
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
            return View(favorites);
        }

        // GET: Favorites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Favorites == null)
            {
                return NotFound();
            }

            var favorites = await _context.Favorites
                .FirstOrDefaultAsync(m => m.FavoritesId == id);
            if (favorites == null)
            {
                return NotFound();
            }

            return View(favorites);
        }

        // POST: Favorites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Favorites == null)
            {
                return Problem("Entity set 'CafeContext.Favorites'  is null.");
            }
            var favorites = await _context.Favorites.FindAsync(id);
            if (favorites != null)
            {
                _context.Favorites.Remove(favorites);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FavoritesExists(int id)
        {
            return (_context.Favorites?.Any(e => e.FavoritesId == id)).GetValueOrDefault();
        }
    }
}
