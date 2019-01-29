using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Avtobuska.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewData["LinijaID"] = new SelectList(_context.Linija, "ID", "ID");
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
