using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Avtobuska.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Avtobuska.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Avtobuska.Controllers
{
    public class HomeController : Controller
    {
        private readonly AvtobuskaContext _context;

        public HomeController(AvtobuskaContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? MestoID = null, int? LinijaID = null, bool Povraten = false)
        {
            var model = new IndexViewModel();
          
            model.Destinacija.MestaList = new SelectList(_context.Mesto, "ID", "Name");
            

            if (MestoID != null)
            {
                var liniiii = (from linija in _context.Linija
                               from stanica in linija.Stanici
                               where stanica.MestoID == (int)MestoID
                               select new Linija
                               {
                                   ID = linija.ID,
                                   Name = $"{linija.VremeNaTrgnuvanje.ToString("hh:mm")} - {linija.Name} ({linija.Prevoznik.Name})"
                               })
                              .Include(l => l.Prevoznik)
                              .ToList();
                model.Linija.MestoID = (int)MestoID;
                model.Linija.Linii = new SelectList(liniiii, "ID", "Name");
            }

            if (LinijaID != null)
            {
                model.Bilet.Linija = _context.Linija.Where(l => l.ID == LinijaID)
                                            .Include(l => l.Prevoznik)
                                            .SingleOrDefault();
                
                model.Bilet.Destinacija = _context.Stanica.Where(m => m.MestoID == MestoID)
                                                  .Include(s => s.Mesto)
                                                  .SingleOrDefault();
                
                model.Bilet.Povraten = Povraten;
            }

            return View(model);
        }

        public IActionResult Reserviraj(Bilet bilet)
        {
            bilet.DatumNaKupuvanje = DateTime.Now;
            bilet.DatumNaVazenje = DateTime.Now.AddMonths(1);
            

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
