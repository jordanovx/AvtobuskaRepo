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
    public class MestoesController : Controller
    {
        private readonly AvtobuskaContext _context;

        public MestoesController(AvtobuskaContext context)
        {
            _context = context;
        }

        // GET: Mestoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Mesto.ToListAsync());
        }

        // GET: Mestoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesto = await _context.Mesto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mesto == null)
            {
                return NotFound();
            }

            return View(mesto);
        }

        // GET: Mestoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Mesto mesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mesto);
        }

        // GET: Mestoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesto = await _context.Mesto.FindAsync(id);
            if (mesto == null)
            {
                return NotFound();
            }
            return View(mesto);
        }

        // POST: Mestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Mesto mesto)
        {
            if (id != mesto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MestoExists(mesto.ID))
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
            return View(mesto);
        }

        // GET: Mestoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mesto = await _context.Mesto
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mesto == null)
            {
                return NotFound();
            }

            return View(mesto);
        }

        // POST: Mestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mesto = await _context.Mesto.FindAsync(id);
            _context.Mesto.Remove(mesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MestoExists(int id)
        {
            return _context.Mesto.Any(e => e.ID == id);
        }
    }
}
