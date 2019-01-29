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
    public class StanicaController : Controller
    {
        private readonly AvtobuskaContext _context;

        public StanicaController(AvtobuskaContext context)
        {
            _context = context; 
        }

        // GET: Stanica
        public async Task<IActionResult> Index()
        {
            var avtobuskaContext = _context.Stanica.Include(s => s.Linija).Include(s => s.Mesto);
            return View(await avtobuskaContext.ToListAsync());
        }

        // GET: Stanica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanica = await _context.Stanica
                .Include(s => s.Linija)
                .Include(s => s.Mesto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stanica == null)
            {
                return NotFound();
            }

            return View(stanica);
        }

        // GET: Stanica/Create
        public IActionResult Create()
        {
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID");
            ViewData["MestoID"] = new SelectList(_context.Mesto, "ID", "ID");
            return View();
        }

        // POST: Stanica/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,MestoID,LinijaID,CenaNaEdenPravec,CenaNaPovraten")] Stanica stanica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stanica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID", stanica.LinijaID);
            ViewData["MestoID"] = new SelectList(_context.Mesto, "ID", "ID", stanica.MestoID);
            return View(stanica);
        }

        // GET: Stanica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanica = await _context.Stanica.FindAsync(id);
            if (stanica == null)
            {
                return NotFound();
            }
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID", stanica.LinijaID);
            ViewData["MestoID"] = new SelectList(_context.Mesto, "ID", "ID", stanica.MestoID);
            return View(stanica);
        }

        // POST: Stanica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,MestoID,LinijaID,CenaNaEdenPravec,CenaNaPovraten")] Stanica stanica)
        {
            if (id != stanica.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stanica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StanicaExists(stanica.ID))
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
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID", stanica.LinijaID);
            ViewData["MestoID"] = new SelectList(_context.Mesto, "ID", "ID", stanica.MestoID);
            return View(stanica);
        }

        // GET: Stanica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanica = await _context.Stanica
                .Include(s => s.Linija)
                .Include(s => s.Mesto)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (stanica == null)
            {
                return NotFound();
            }

            return View(stanica);
        }

        // POST: Stanica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stanica = await _context.Stanica.FindAsync(id);
            _context.Stanica.Remove(stanica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StanicaExists(int id)
        {
            return _context.Stanica.Any(e => e.ID == id);
        }
    }
}
