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
    public class AlcoholController : Controller
    {
        private readonly MvcCocktailContext _context;

        public AlcoholController(MvcCocktailContext context)
        {
            _context = context;
        }

        // GET: Alcohol
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alcohol.ToListAsync());
        }

        // GET: Alcohol/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcohol = await _context.Alcohol
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcohol == null)
            {
                return NotFound();
            }

            return View(alcohol);
        }

        // GET: Alcohol/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alcohol/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity")] Alcohol alcohol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alcohol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alcohol);
        }

        // GET: Alcohol/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcohol = await _context.Alcohol.FindAsync(id);
            if (alcohol == null)
            {
                return NotFound();
            }
            return View(alcohol);
        }

        // POST: Alcohol/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity")] Alcohol alcohol)
        {
            if (id != alcohol.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alcohol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlcoholExists(alcohol.Id))
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
            return View(alcohol);
        }

        // GET: Alcohol/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcohol = await _context.Alcohol
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcohol == null)
            {
                return NotFound();
            }

            return View(alcohol);
        }

        // POST: Alcohol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alcohol = await _context.Alcohol.FindAsync(id);
            if (alcohol != null)
            {
                _context.Alcohol.Remove(alcohol);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlcoholExists(int id)
        {
            return _context.Alcohol.Any(e => e.Id == id);
        }
    }
}
