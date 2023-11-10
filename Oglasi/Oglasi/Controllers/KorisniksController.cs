using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nancy.Authentication.Forms;
using Oglasi.Models;

namespace Oglasi.Controllers
{
    public class KorisniksController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;

        public KorisniksController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
        }

        // GET: Korisniks
        public async Task<IActionResult> Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("korisnikId")))
            {
                return RedirectToAction("Signin");
            }
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            
            return View(await _context.Korisnik.ToListAsync());
        }
      
        // GET: Korisniks/Details/5
        public async Task<IActionResult> Details()
        {
            var id = HttpContext.Session.GetString("korisnikId");
            ViewBag.KorisnickoIme = id;
            UserOglasi model = new UserOglasi();
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.KorisnickoIme == id);
            if (korisnik == null)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("korisnikId")))
            {
                return RedirectToAction("Signin");
            }
            
            var userName = HttpContext.Session.GetString("korisnikId");
            if (userName == korisnik.KorisnickoIme)
            {
                model.User = korisnik;
                //model.Oglasi = _context.Oglas(_context.ZachuvanOd.Where(z => z.KorisnickoIme == userName));
                var tmp = _context.ZachuvanOd.Where(z => z.KorisnickoIme == userName);
                List<Oglas> oglasi = new List<Oglas>();
                List<string> ids = new List<string>();
                //foreach (var elem in tmp) {
                //    ids.Add(elem.IdOglas);
                //}
                ids.AddRange(tmp.Select(z => z.IdOglas));
                //foreach (var elem in tmp)
                //{
                var oglasitmp = _context.Oglas.Where(z => ids.Contains(z.IdOglas)).ToList();
                oglasi.AddRange(oglasitmp);
                //}
                //model.Oglasi.Add(_context.Oglas1.FirstOrDefault(z => z.IdOglas == "ogl01"));
                model.Saved = oglasi;

                //ids.Clear();
                //oglasi.Clear();

                List<Oglas> oglasi2 = new List<Oglas>();
                List<string> ids2 = new List<string>();

                var tmp2 = _context.SopstvenikNa.Where(z => z.KorisnickoIme == userName);
                ids2.AddRange(tmp2.Select(z => z.IdOglas));
                var oglasitmp2 = _context.Oglas.Where(z => ids2.Contains(z.IdOglas)).ToList();
                oglasi2.AddRange(oglasitmp2);
                model.Created = oglasi2;

                //ids.Clear();
                //oglasi.Clear();

                List<Oglas> oglasi3 = new List<Oglas>();
                List<string> ids3 = new List<string>();

                var tmp3 = _context.Preporaka.Where(z => z.PrepDo == userName);
                ids3.AddRange(tmp3.Select(z => z.IdOglas));
                var oglasitmp3 = _context.Oglas.Where(z => ids3.Contains(z.IdOglas)).ToList();
                oglasi3.AddRange(oglasitmp3);
                model.Recomended = oglasi3;

                //ids.Clear();
                //oglasi.Clear();

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
            }
        }

        // GET: Korisniks/Create
        public IActionResult Register()
        {
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            ViewBag.KorisnickoImeAdmin = HttpContext.Session.GetString("korisnikAdminId");
            return View();
        }

        // POST: Korisniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("KorisnickoIme,Lozinka,ImeKor,PrezimeKor,TelefonskiBroj,Mail,Ulica,Grad")] Korisnik korisnik)
        {
            try
            {
                _context.Add(korisnik);
                await _context.SaveChangesAsync();
            
                ViewBag.Message = "Корисникот " + korisnik.KorisnickoIme + " успешно е регистриран";
            }
            catch {
                ViewBag.Message = "Не може да се креира профил со веќе постоечко корисничко име: " + korisnik.KorisnickoIme;
            }
            return View();
          
        }

        // GET: Korisniks/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik.FindAsync(id);
            if (korisnik == null)
            {
                return NotFound();
            }
            return View(korisnik);
        }

        // POST: Korisniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KorisnickoIme,Lozinka,ImeKor,PrezimeKor,TelefonskiBroj,Mail,Ulica,Grad")] Korisnik korisnik)
        {
            if (id != korisnik.KorisnickoIme)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(korisnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KorisnikExists(korisnik.KorisnickoIme))
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
            return View(korisnik);
        }

        // GET: Korisniks/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var korisnik = await _context.Korisnik
                .FirstOrDefaultAsync(m => m.KorisnickoIme == id);
            if (korisnik == null)
            {
                return NotFound();
            }

            return View(korisnik);
        }

        // POST: Korisniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var korisnik = await _context.Korisnik.FindAsync(id);
            _context.Korisnik.Remove(korisnik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Signin()
        {
            
            return View();
        }
        [HttpPost]
       public IActionResult Signin(Korisnik korisnik)
        {
            
            Korisnik leggedInUSer  =_context.Korisnik.Where(x => x.KorisnickoIme == korisnik.KorisnickoIme &&
                x.Lozinka == korisnik.Lozinka).FirstOrDefault();
                if (leggedInUSer == null)
                {
                
                ViewBag.Message = "Погрешно Корисничко име или лозинка, обидете се повторно !!!!";
                return View("Signin", korisnik);
                }
                else
                {
                    
                    HttpContext.Session.SetString("korisnikId", korisnik.KorisnickoIme);
                
                    return RedirectToAction("Index", "Korisniks");
                }
                
        }
        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Signin");
        }

        private bool KorisnikExists(string id)
        {
            return _context.Korisnik.Any(e => e.KorisnickoIme == id);
        }
    }
}
