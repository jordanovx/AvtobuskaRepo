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
    public class LinijaController : Controller
    {
        private readonly AvtobuskaContext _context;

        public LinijaController(AvtobuskaContext context)
        {
            _context = context;
        }

        // GET: Linija
        public async Task<IActionResult> Index()
        {
            var avtobuskaContext = _context.Linija.Include(l => l.Prevoznik);
            return View(await avtobuskaContext.ToListAsync());
        }

        // GET: Linija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linija = await _context.Linija
                .Include(l => l.Prevoznik)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (linija == null)
            {
                return NotFound();
            }

            return View(linija);
        }

        // GET: Linija/Create
        public IActionResult Create()
        {
            ViewData["PrevoznikID"] = new SelectList(_context.Prevoznik, "ID", "ID");
            return View();
        }

        // POST: Linija/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,VremeNaTrgnuvanje,PrevoznikID,BrojNaSedista,Peron")] Linija linija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PrevoznikID"] = new SelectList(_context.Prevoznik, "ID", "ID", linija.PrevoznikID);
            return View(linija);
        }

        // GET: Linija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linija = await _context.Linija.FindAsync(id);
            if (linija == null)
            {
                return NotFound();
            }
            ViewData["PrevoznikID"] = new SelectList(_context.Prevoznik, "ID", "ID", linija.PrevoznikID);
            return View(linija);
        }

        // POST: Linija/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,VremeNaTrgnuvanje,PrevoznikID,BrojNaSedista,Peron")] Linija linija)
        {
            if (id != linija.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinijaExists(linija.ID))
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
            ViewData["PrevoznikID"] = new SelectList(_context.Prevoznik, "ID", "ID", linija.PrevoznikID);
            return View(linija);
        }

        // GET: Linija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linija = await _context.Linija
                .Include(l => l.Prevoznik)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (linija == null)
            {
                return NotFound();
            }

            return View(linija);
        }

        // POST: Linija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linija = await _context.Linija.FindAsync(id);
            _context.Linija.Remove(linija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinijaExists(int id)
        {
            return _context.Linija.Any(e => e.ID == id);
        }
    }
}
