using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Avtobuska.Models;

namespace Avtobuska.Views
{
    public class PrevozniksController : Controller
    {
        private readonly AvtobuskaContext _context;

        public PrevozniksController(AvtobuskaContext context)
        {
            _context = context;
        }

        // GET: Prevozniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prevoznik.ToListAsync());
        }

        // GET: Prevozniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevoznik = await _context.Prevoznik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prevoznik == null)
            {
                return NotFound();
            }

            return View(prevoznik);
        }

        // GET: Prevozniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prevozniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Prevoznik prevoznik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prevoznik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prevoznik);
        }

        // GET: Prevozniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevoznik = await _context.Prevoznik.FindAsync(id);
            if (prevoznik == null)
            {
                return NotFound();
            }
            return View(prevoznik);
        }

        // POST: Prevozniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Prevoznik prevoznik)
        {
            if (id != prevoznik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prevoznik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrevoznikExists(prevoznik.ID))
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
            return View(prevoznik);
        }

        // GET: Prevozniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prevoznik = await _context.Prevoznik
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prevoznik == null)
            {
                return NotFound();
            }

            return View(prevoznik);
        }

        // POST: Prevozniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prevoznik = await _context.Prevoznik.FindAsync(id);
            _context.Prevoznik.Remove(prevoznik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrevoznikExists(int id)
        {
            return _context.Prevoznik.Any(e => e.ID == id);
        }
    }
}
