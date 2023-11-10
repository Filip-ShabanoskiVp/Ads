using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oglasi.Models;

namespace Oglasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public HomeController(ILogger<HomeController> logger, db_201920z_va_prj_oglasnikContext context)
        {
            _logger = logger;
            _context = context;
           
            
        }

        public IActionResult Index()
        {
            var categories = _context.Kategorija.ToList();
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");

            ViewBag.KorisnickoImeAdmin = HttpContext.Session.GetString("korisnikAdminId");
            return View(categories);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
