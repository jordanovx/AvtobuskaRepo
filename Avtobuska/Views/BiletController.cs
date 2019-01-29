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
    public class BiletController : Controller
    {
        private readonly AvtobuskaContext _context;

        public BiletController(AvtobuskaContext context)
        {
            _context = context;
        }

        // GET: Bilet
        public async Task<IActionResult> Index()
        {
            var avtobuskaContext = _context.Bilet.Include(b => b.Linija);
            return View(await avtobuskaContext.ToListAsync());
        }

        // GET: Bilet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet
                .Include(b => b.Linija)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // GET: Bilet/Create
        public IActionResult Create()
        {
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID");
            return View();
        }

        // POST: Bilet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LinijaID,SedisteBroj,Izdaden,Rezerviran,Cena")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bilet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID", bilet.LinijaID);
            return View(bilet);
        }

        // GET: Bilet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet.FindAsync(id);
            if (bilet == null)
            {
                return NotFound();
            }
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID", bilet.LinijaID);
            return View(bilet);
        }

        // POST: Bilet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,LinijaID,SedisteBroj,Izdaden,Rezerviran,Cena")] Bilet bilet)
        {
            if (id != bilet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.ID))
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
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID", bilet.LinijaID);
            return View(bilet);
        }

        // GET: Bilet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilet
                .Include(b => b.Linija)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Bilet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bilet = await _context.Bilet.FindAsync(id);
            _context.Bilet.Remove(bilet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiletExists(int id)
        {
            return _context.Bilet.Any(e => e.ID == id);
        }
    }
}
