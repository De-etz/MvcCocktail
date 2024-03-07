using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCocktail.Data;
using MvcCocktail.Models;

namespace MvcCocktail.Controllers
{
    public class LiquorController : Controller
    {
        private readonly MvcCocktailContext _context;

        public LiquorController(MvcCocktailContext context)
        {
            _context = context;
        }

        // GET: Liquor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Liquor.ToListAsync());
        }

        // GET: Liquor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquor = await _context.Liquor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liquor == null)
            {
                return NotFound();
            }

            return View(liquor);
        }

        // GET: Liquor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Liquor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LiquorType,Id,Name,Quantity")] Liquor liquor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(liquor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(liquor);
        }

        // GET: Liquor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquor = await _context.Liquor.FindAsync(id);
            if (liquor == null)
            {
                return NotFound();
            }
            return View(liquor);
        }

        // POST: Liquor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LiquorType,Id,Name,Quantity")] Liquor liquor)
        {
            if (id != liquor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(liquor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LiquorExists(liquor.Id))
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
            return View(liquor);
        }

        // GET: Liquor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var liquor = await _context.Liquor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (liquor == null)
            {
                return NotFound();
            }

            return View(liquor);
        }

        // POST: Liquor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var liquor = await _context.Liquor.FindAsync(id);
            if (liquor != null)
            {
                _context.Liquor.Remove(liquor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiquorExists(int id)
        {
            return _context.Liquor.Any(e => e.Id == id);
        }
    }
}
