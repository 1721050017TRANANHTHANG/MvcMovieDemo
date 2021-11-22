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
    public class BsController : Controller
    {
        private readonly MvcMovieContext _context;

        public BsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Bs
        public async Task<IActionResult> Index()
        {
            return View(await _context.B.ToListAsync());
        }

        // GET: Bs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var b = await _context.B
                .FirstOrDefaultAsync(m => m.ID == id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        // GET: Bs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("address,age,ID,Name")] B b)
        {
            if (ModelState.IsValid)
            {
                _context.Add(b);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(b);
        }

        // GET: Bs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var b = await _context.B.FindAsync(id);
            if (b == null)
            {
                return NotFound();
            }
            return View(b);
        }

        // POST: Bs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("address,age,ID,Name")] B b)
        {
            if (id != b.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(b);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BExists(b.ID))
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
            return View(b);
        }

        // GET: Bs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var b = await _context.B
                .FirstOrDefaultAsync(m => m.ID == id);
            if (b == null)
            {
                return NotFound();
            }

            return View(b);
        }

        // POST: Bs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var b = await _context.B.FindAsync(id);
            _context.B.Remove(b);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BExists(string id)
        {
            return _context.B.Any(e => e.ID == id);
        }
    }
}
