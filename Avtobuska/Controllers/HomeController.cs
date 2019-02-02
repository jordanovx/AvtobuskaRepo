using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Avtobuska.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Avtobuska.ViewModels;

namespace Avtobuska.Controllers
{
    public class HomeController : Controller
    {
        private readonly AvtobuskaContext _context;

        public HomeController(AvtobuskaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Destinacija = new DestinacijaViewModel();
            model.Linija = new LinijaViewModel();

            model.Destinacija.MestaList = new SelectList(_context.Mesto, "ID", "Name");

            return View(model);
        }

        public IActionResult SetDestination(int id)
        {
            
            var liniiii = _context.Linija.ToList();
            var linijaViewModel = new LinijaViewModel();
            linijaViewModel.Linii = new SelectList(liniiii, "ID", "Name");

            return PartialView("LinijaPartial", linijaViewModel);
            
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
