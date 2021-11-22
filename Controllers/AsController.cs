using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class AsController : Controller
    {
        private readonly MvcMovieContext _context;

        public AsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: As
        public async Task<IActionResult> Index()
        {
            return View(await _context.A.ToListAsync());
        }

        // GET: As/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var a = await _context.A
                .FirstOrDefaultAsync(m => m.ID == id);
            if (a == null)
            {
                return NotFound();
            }

            return View(a);
        }

        // GET: As/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: As/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] A a)
        {
            if (ModelState.IsValid)
            {
                _context.Add(a);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(a);
        }

        // GET: As/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var a = await _context.A.FindAsync(id);
            if (a == null)
            {
                return NotFound();
            }
            return View(a);
        }

        // POST: As/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID,Name")] A a)
        {
            if (id != a.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(a);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AExists(a.ID))
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
            return View(a);
        }

        // GET: As/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var a = await _context.A
                .FirstOrDefaultAsync(m => m.ID == id);
            if (a == null)
            {
                return NotFound();
            }

            return View(a);
        }

        // POST: As/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var a = await _context.A.FindAsync(id);
            _context.A.Remove(a);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AExists(string id)
        {
            return _context.A.Any(e => e.ID == id);
        }
    }
}
