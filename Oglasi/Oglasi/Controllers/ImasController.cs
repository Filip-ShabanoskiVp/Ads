using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oglasi.Models;

namespace Oglasi.Controllers
{
    public class ImasController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public ImasController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
        }

        // GET: Imas
        public async Task<IActionResult> Index()
        {
            var db_201920z_va_prj_oglasnikContext = _context.Ima.Include(i => i.BrojTransakcijaNavigation).Include(i => i.KorisnickoImeNavigation);
            return View(await db_201920z_va_prj_oglasnikContext.ToListAsync());
        }

        

        // GET: Imas/Create
        public IActionResult Create()
        {
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            ViewData["BrojTransakcija"] = new SelectList(_context.TransakciskaSmetka, "BrojTransakcija", "BrojTransakcija");
            ViewData["KorisnickoIme"] = new SelectList(_context.Korisnik, "KorisnickoIme", "KorisnickoIme");
            return View();
        }

        // POST: Imas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KorisnickoIme,BrojTransakcija")] Ima ima)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ima);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrojTransakcija"] = new SelectList(_context.TransakciskaSmetka, "BrojTransakcija", "BrojTransakcija", ima.BrojTransakcija);
            ViewData["KorisnickoIme"] = new SelectList(_context.Korisnik, "KorisnickoIme", "KorisnickoIme", ima.KorisnickoIme);
            return View(ima);
        }

       
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ima = await _context.Ima
                .Include(i => i.BrojTransakcijaNavigation)
                .Include(i => i.KorisnickoImeNavigation)
                .FirstOrDefaultAsync(m => m.BrojTransakcija == id);
            if (ima == null)
            {
                return NotFound();
            }

            return View(ima);
        }

        // POST: Imas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ima = await _context.Ima.FindAsync(id);
            _context.Ima.Remove(ima);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImaExists(string id)
        {
            return _context.Ima.Any(e => e.BrojTransakcija == id);
        }
    }
}
