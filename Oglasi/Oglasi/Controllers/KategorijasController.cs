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
    public class KategorijasController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public KategorijasController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
        }

        // GET: Kategorijas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kategorija.ToListAsync());
        }

        // GET: Kategorijas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorija
                .FirstOrDefaultAsync(m => m.ImeKat == id);
            if (kategorija == null)
            {
                return NotFound();
            }

            return View(kategorija);
        }

        // GET: Kategorijas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategorijas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImeKat,BrojKat,BrojNaOglasi")] Kategorija kategorija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategorija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategorija);
        }

        // GET: Kategorijas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorija.FindAsync(id);
            if (kategorija == null)
            {
                return NotFound();
            }
            return View(kategorija);
        }

        // POST: Kategorijas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ImeKat,BrojKat,BrojNaOglasi")] Kategorija kategorija)
        {
            if (id != kategorija.ImeKat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorijaExists(kategorija.ImeKat))
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
            return View(kategorija);
        }

        // GET: Kategorijas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorija = await _context.Kategorija
                .FirstOrDefaultAsync(m => m.ImeKat == id);
            if (kategorija == null)
            {
                return NotFound();
            }

            return View(kategorija);
        }

        // POST: Kategorijas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var kategorija = await _context.Kategorija.FindAsync(id);
            _context.Kategorija.Remove(kategorija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorijaExists(string id)
        {
            return _context.Kategorija.Any(e => e.ImeKat == id);
        }
    }
}
