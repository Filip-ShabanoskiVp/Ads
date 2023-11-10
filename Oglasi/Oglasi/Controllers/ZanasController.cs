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
    public class ZanasController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public ZanasController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
        }

        // GET: Zanas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zanas.ToListAsync());
        }

        // GET: Zanas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanas = await _context.Zanas
                .FirstOrDefaultAsync(m => m.Ime == id);
            if (zanas == null)
            {
                return NotFound();
            }

            return View(zanas);
        }

        // GET: Zanas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zanas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ime,Mail,Lokacija")] Zanas zanas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zanas);
        }

        // GET: Zanas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanas = await _context.Zanas.FindAsync(id);
            if (zanas == null)
            {
                return NotFound();
            }
            return View(zanas);
        }

        // POST: Zanas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Ime,Mail,Lokacija")] Zanas zanas)
        {
            if (id != zanas.Ime)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanasExists(zanas.Ime))
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
            return View(zanas);
        }

        // GET: Zanas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zanas = await _context.Zanas
                .FirstOrDefaultAsync(m => m.Ime == id);
            if (zanas == null)
            {
                return NotFound();
            }

            return View(zanas);
        }

        // POST: Zanas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zanas = await _context.Zanas.FindAsync(id);
            _context.Zanas.Remove(zanas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanasExists(string id)
        {
            return _context.Zanas.Any(e => e.Ime == id);
        }
    }
}
