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
    public class AdministratorsController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public AdministratorsController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
        }

        // GET: Administrators
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("korisnikAdminId")))
            {
                return RedirectToAction("LoginAdmin");
            }
            ViewBag.KorisnickoImeAdmin = HttpContext.Session.GetString("korisnikAdminId");
            return View(await _context.Administrator.ToListAsync());
        }

        // GET: Administrators/Details/5
        public async Task<IActionResult> Details()
        {
            var id = HttpContext.Session.GetString("korisnikAdminId");
            AdminMails model = new AdminMails();

            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrator
                .FirstOrDefaultAsync(m => m.IdVraboten == id);
            if (administrator == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("korisnikAdminId")))
            {
                return RedirectToAction("LoginAdmin");
            }
            var userName = HttpContext.Session.GetString("korisnikAdminId");
            if(userName == administrator.KorisnickoIme)
            {
                model.Admin = administrator;

            }
            var tmp = _context.PrakaPorakaDo.Where(z => z.KorisnickoIme == userName);

            ViewBag.KorisnickoImeAdmin = id;
            return View(administrator);

            /* 
                //model.Oglasi = _context.Oglas(_context.ZachuvanOd.Where(z => z.KorisnickoIme == userName));
                var tmp = _context.ZachuvanOd.Where(z => z.KorisnickoIme == userName);
                List<Oglas> oglasi = new List<Oglas>();
                List<string> ids = new List<string>();
               
                ids.AddRange(tmp.Select(z => z.IdOglas));
                
                var oglasitmp = _context.Oglas.Where(z => ids.Contains(z.IdOglas)).ToList();
                oglasi.AddRange(oglasitmp);
                
                model.Saved = oglasi;


                List<Oglas> oglasi2 = new List<Oglas>();
                List<string> ids2 = new List<string>();

                var tmp2 = _context.SopstvenikNa.Where(z => z.KorisnickoIme == userName);
                ids2.AddRange(tmp2.Select(z => z.IdOglas));
                var oglasitmp2 = _context.Oglas.Where(z => ids2.Contains(z.IdOglas)).ToList();
                oglasi2.AddRange(oglasitmp2);
                model.Created = oglasi2;


                List<Oglas> oglasi3 = new List<Oglas>();
                List<string> ids3 = new List<string>();

                var tmp3 = _context.Preporaka.Where(z => z.PrepDo == userName);
                ids3.AddRange(tmp3.Select(z => z.IdOglas));
                var oglasitmp3 = _context.Oglas.Where(z => ids3.Contains(z.IdOglas)).ToList();
                oglasi3.AddRange(oglasitmp3);
                model.Recomended = oglasi3;


                List<Oglas> oglasi4 = new List<Oglas>();
                List<string> ids4 = new List<string>();

                var transaction = _context.Ima.FirstOrDefault(z => z.KorisnickoIme == userName);
                if (transaction != null)
                {
                    var kp = _context.KupenPreku.Where(z => z.BrojTransakcija == transaction.BrojTransakcija);
                    ids4.AddRange(kp.Select(z => z.IdOglas));
                    var oglasitmp4 = _context.Oglas.Where(z => ids4.Contains(z.IdOglas)).ToList();
                    oglasi4.AddRange(oglasitmp4);
                    model.Bought = oglasi4;
                }

                return View(model);
            }
            else {
                return NotFound();
            }*/
        }

        // GET: Administrators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVraboten,Imeadmin,Prezimeadmin,Mail,KorisnickoIme")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrator);
        }

        // GET: Administrators/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrator.FindAsync(id);
            if (administrator == null)
            {
                return NotFound();
            }
            return View(administrator);
        }

        // POST: Administrators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdVraboten,Imeadmin,Prezimeadmin,Mail,KorisnickoIme")] Administrator administrator)
        {
            if (id != administrator.IdVraboten)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministratorExists(administrator.IdVraboten))
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
            return View(administrator);
        }

        // GET: Administrators/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrator = await _context.Administrator
                .FirstOrDefaultAsync(m => m.IdVraboten == id);
            if (administrator == null)
            {
                return NotFound();
            }

            return View(administrator);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var administrator = await _context.Administrator.FindAsync(id);
            _context.Administrator.Remove(administrator);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministratorExists(string id)
        {
            return _context.Administrator.Any(e => e.IdVraboten == id);
        }
        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdmin(Administrator administrator)
        {

            Administrator leggedInUSer = _context.Administrator.Where(x => x.KorisnickoIme == administrator.KorisnickoIme &&
                x.lozinka == administrator.lozinka).FirstOrDefault();
            if (leggedInUSer == null)
            {
                ViewBag.Message = "Погрешно Корисничко име или лозинка, обидете се повторно !!!!";
                return View("LoginAdmin", administrator);
            }
            else
            {

                HttpContext.Session.SetString("korisnikAdminId", administrator.KorisnickoIme);
                return RedirectToAction("Index", "Administrators");
            }

        }
        public IActionResult LogOutAdmin()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginAdmin");
        }
    }
}
