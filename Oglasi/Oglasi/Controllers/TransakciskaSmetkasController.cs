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
    public class TransakciskaSmetkasController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public TransakciskaSmetkasController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
        }

        // GET: TransakciskaSmetkas
        public async Task<IActionResult> Index()
        {
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            ViewBag.oglasId = HttpContext.Session.GetString("oglasId");
            return View(await _context.TransakciskaSmetka.ToListAsync());
        }

        // GET: TransakciskaSmetkas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakciskaSmetka = await _context.TransakciskaSmetka
                .FirstOrDefaultAsync(m => m.BrojTransakcija == id);
            if (transakciskaSmetka == null)
            {
                return NotFound();
            }

            return View(transakciskaSmetka);
        }

        // GET: TransakciskaSmetkas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransakciskaSmetkas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrojTransakcija")] TransakciskaSmetka transakciskaSmetka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transakciskaSmetka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transakciskaSmetka);
        }

        // GET: TransakciskaSmetkas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakciskaSmetka = await _context.TransakciskaSmetka.FindAsync(id);
            if (transakciskaSmetka == null)
            {
                return NotFound();
            }
            return View(transakciskaSmetka);
        }

        // POST: TransakciskaSmetkas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BrojTransakcija")] TransakciskaSmetka transakciskaSmetka)
        {
            if (id != transakciskaSmetka.BrojTransakcija)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transakciskaSmetka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransakciskaSmetkaExists(transakciskaSmetka.BrojTransakcija))
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
            return View(transakciskaSmetka);
        }

        // GET: TransakciskaSmetkas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakciskaSmetka = await _context.TransakciskaSmetka
                .FirstOrDefaultAsync(m => m.BrojTransakcija == id);
            if (transakciskaSmetka == null)
            {
                return NotFound();
            }

            return View(transakciskaSmetka);
        }

        // POST: TransakciskaSmetkas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var transakciskaSmetka = await _context.TransakciskaSmetka.FindAsync(id);
            _context.TransakciskaSmetka.Remove(transakciskaSmetka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransakciskaSmetkaExists(string id)
        {
            return _context.TransakciskaSmetka.Any(e => e.BrojTransakcija == id);
        }
    }
}
