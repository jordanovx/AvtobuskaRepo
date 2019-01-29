using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Avtobuska.Controllers
{
    public class AvtobuskiStaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}