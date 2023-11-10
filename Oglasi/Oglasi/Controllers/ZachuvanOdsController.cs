using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oglasi.Models;

namespace Oglasi.Controllers
{
    public class ZachuvanOdsController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public ZachuvanOdsController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
        }

        // GET: ZachuvanOds
        public async Task<IActionResult> Index()
        {
            var db_201920z_va_prj_oglasnikContext = _context.ZachuvanOd.Include(z => z.IdOglasNavigation).Include(z => z.KorisnickoImeNavigation);
            return View(await db_201920z_va_prj_oglasnikContext.ToListAsync());
        }

        // GET: ZachuvanOds/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zachuvanOd = await _context.ZachuvanOd
                .Include(z => z.IdOglasNavigation)
                .Include(z => z.KorisnickoImeNavigation)
                .FirstOrDefaultAsync(m => m.IdOglas == id);
            if (zachuvanOd == null)
            {
                return NotFound();
            }

            return View(zachuvanOd);
        }

        // GET: ZachuvanOds/Create
        public IActionResult Create()
        {
            ViewData["IdOglas"] = new SelectList(_context.Oglas, "IdOglas", "IdOglas");
            ViewData["KorisnickoIme"] = new SelectList(_context.Korisnik, "KorisnickoIme", "KorisnickoIme");
            return View();
        }

        // POST: ZachuvanOds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOglas,KorisnickoIme")] ZachuvanOd zachuvanOd)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zachuvanOd);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdOglas"] = new SelectList(_context.Oglas, "IdOglas", "IdOglas", zachuvanOd.IdOglas);
            ViewData["KorisnickoIme"] = new SelectList(_context.Korisnik, "KorisnickoIme", "KorisnickoIme", zachuvanOd.KorisnickoIme);
            return View(zachuvanOd);
        }

        // GET: ZachuvanOds/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zachuvanOd = await _context.ZachuvanOd.FindAsync(id);
            if (zachuvanOd == null)
            {
                return NotFound();
            }
            ViewData["IdOglas"] = new SelectList(_context.Oglas, "IdOglas", "IdOglas", zachuvanOd.IdOglas);
            ViewData["KorisnickoIme"] = new SelectList(_context.Korisnik, "KorisnickoIme", "KorisnickoIme", zachuvanOd.KorisnickoIme);
            return View(zachuvanOd);
        }

        // POST: ZachuvanOds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdOglas,KorisnickoIme")] ZachuvanOd zachuvanOd)
        {
            if (id != zachuvanOd.IdOglas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zachuvanOd);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZachuvanOdExists(zachuvanOd.IdOglas))
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
            ViewData["IdOglas"] = new SelectList(_context.Oglas, "IdOglas", "IdOglas", zachuvanOd.IdOglas);
            ViewData["KorisnickoIme"] = new SelectList(_context.Korisnik, "KorisnickoIme", "KorisnickoIme", zachuvanOd.KorisnickoIme);
            return View(zachuvanOd);
        }

        // GET: ZachuvanOds/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zachuvanOd = await _context.ZachuvanOd
                .Include(z => z.IdOglasNavigation)
                .Include(z => z.KorisnickoImeNavigation)
                .FirstOrDefaultAsync(m => m.IdOglas == id);
            if (zachuvanOd == null)
            {
                return NotFound();
            }

            return View(zachuvanOd);
        }

        // POST: ZachuvanOds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zachuvanOd = await _context.ZachuvanOd.FindAsync(id);
            _context.ZachuvanOd.Remove(zachuvanOd);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZachuvanOdExists(string id)
        {
            return _context.ZachuvanOd.Any(e => e.IdOglas == id);
        }
    }
}
