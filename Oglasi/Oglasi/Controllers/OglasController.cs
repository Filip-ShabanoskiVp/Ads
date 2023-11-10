using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Oglasi.Models;

namespace Oglasi.Controllers
{
    public class OglasController : Controller
    {
        private readonly db_201920z_va_prj_oglasnikContext _context;
        
        public OglasController(db_201920z_va_prj_oglasnikContext context)
        {
            _context = context;
            
        }

        // GET: Oglas
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            ViewBag.KorisnickoImeAdmin = HttpContext.Session.GetString("korisnikAdminId");

            //if (id == 0)
            //{
            //    var db_201920z_va_prj_oglasnikContext = _context.Oglas.Include(o => o.ImeKatNavigation);
            //    return View(await db_201920z_va_prj_oglasnikContext.ToListAsync());
            //}
            if (id == 1)
            {
                //VOZILA
                
                var db_201920z_va_prj_oglasnikContext = _context.Oglas.Where(z => z.ImeKat == "Возила");
                var kupeni = _context.KupenPreku.ToList();
             List<Oglas> lista = new List<Oglas>();
             foreach (var item in db_201920z_va_prj_oglasnikContext)
             {
                 if (!kupeni.Any(z => z.IdOglas == item.IdOglas)) lista.Add(item);
             }

             return View(lista);
            }
            else if (id == 2)
            {
                //LITERATURA
                var db_201920z_va_prj_oglasnikContext = _context.Oglas.Where(z => z.ImeKat == "Литература");
                 var kupeni = _context.KupenPreku.ToList();
             List<Oglas> lista = new List<Oglas>();
             foreach (var item in db_201920z_va_prj_oglasnikContext)
             {
                 if (!kupeni.Any(z => z.IdOglas == item.IdOglas)) lista.Add(item);
             }

             return View(lista);
            }
            else if (id == 3)
            {
                //NEDVIZNINI
                var db_201920z_va_prj_oglasnikContext = _context.Oglas.Where(z => z.ImeKat == "Недвижнини");
                 var kupeni = _context.KupenPreku.ToList();
             List<Oglas> lista = new List<Oglas>();
             foreach (var item in db_201920z_va_prj_oglasnikContext)
             {
                 if (!kupeni.Any(z => z.IdOglas == item.IdOglas)) lista.Add(item);
             }

             return View(lista);
            }
            else if (id == 4)
            {
                //ZA DOM
                var db_201920z_va_prj_oglasnikContext = _context.Oglas.Where(z => z.ImeKat == "За дом");
                 var kupeni = _context.KupenPreku.ToList();
             List<Oglas> lista = new List<Oglas>();
             foreach (var item in db_201920z_va_prj_oglasnikContext)
             {
                 if (!kupeni.Any(z => z.IdOglas == item.IdOglas)) lista.Add(item);
             }

             return View(lista);
            }
            else if (id == 5)
            {
                //TEHNOLOGIJA
                var db_201920z_va_prj_oglasnikContext = _context.Oglas.Where(z => z.ImeKat == "Технологија");
                 var kupeni = _context.KupenPreku.ToList();
             List<Oglas> lista = new List<Oglas>();
             foreach (var item in db_201920z_va_prj_oglasnikContext)
             {
                 if (!kupeni.Any(z => z.IdOglas == item.IdOglas)) lista.Add(item);
             }

             return View(lista);
            }
            else if (id == 6) 
            {
                var db_201920z_va_prj_oglasnikContext = _context.Oglas.Where(z => z.ImeKat == "Спорт и спортска опрема");
                 var kupeni = _context.KupenPreku.ToList();
             List<Oglas> lista = new List<Oglas>();
             foreach (var item in db_201920z_va_prj_oglasnikContext)
             {
                 if (!kupeni.Any(z => z.IdOglas == item.IdOglas)) lista.Add(item);
             }

             return View(lista);
            }
            else
            {
                var db_201920z_va_prj_oglasnikContext = _context.Oglas.Include(o => o.ImeKatNavigation);
                 var kupeni = _context.KupenPreku.ToList();
             List<Oglas> lista = new List<Oglas>();
             foreach (var item in db_201920z_va_prj_oglasnikContext)
             {
                 if (!kupeni.Any(z => z.IdOglas == item.IdOglas)) lista.Add(item);
             }

             return View(lista);
            }

        }

        // GET: Oglas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("oglasId", id);
           
            var oglas = await _context.Oglas
                .Include(o => o.ImeKatNavigation)
                .FirstOrDefaultAsync(m => m.IdOglas == id);
            if (oglas == null)
            {
                return NotFound();
            }
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            ViewBag.messagee= HttpContext.Session.GetString("message"); 

            ViewBag.KorisnickoImeAdmin = HttpContext.Session.GetString("korisnikAdminId");
            return View(oglas);
        }

        // GET: Oglas/Create
        public IActionResult Create()
        {
            ViewBag.KorisnickoImeAdmin = HttpContext.Session.GetString("korisnikAdminId");
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            ViewData["ImeKat"] = new SelectList(_context.Kategorija, "ImeKat", "ImeKat");
            if (HttpContext.Session.GetString("korisnikId") != null || HttpContext.Session.GetString("korisnikAdminId")!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Signin", "Korisniks");
            }
        }

        // POST: Oglas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOglas,ImeOglas,ImeKat,Cena,Datum,Opis")] Oglas oglas)
        {
            if (ModelState.IsValid)
            {
              try
                {
                    _context.Add(oglas);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
               }
               catch (Exception)
                {
                    ViewBag.poraka = "Веќе постои оглас со тоа id";
                    
    
                }
            }
            var ogg = oglas.IdOglas;
            ViewData["ImeKat"] = new SelectList(_context.Kategorija, "ImeKat", "ImeKat", oglas.ImeKat);
            return View(oglas);
        }

        // GET: Oglas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglas = await _context.Oglas.FindAsync(id);
            if (oglas == null)
            {
                return NotFound();
            }
            ViewData["ImeKat"] = new SelectList(_context.Kategorija, "ImeKat", "ImeKat", oglas.ImeKat);
            return View(oglas);
        }

        // POST: Oglas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdOglas,ImeOglas,ImeKat,Cena,Datum,Opis")] Oglas oglas)
        {
            if (id != oglas.IdOglas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oglas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OglasExists(oglas.IdOglas))
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
            ViewData["ImeKat"] = new SelectList(_context.Kategorija, "ImeKat", "ImeKat", oglas.ImeKat);
            return View(oglas);
        }

        // GET: Oglas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglas = await _context.Oglas
                .Include(o => o.ImeKatNavigation)
                .FirstOrDefaultAsync(m => m.IdOglas == id);
            if (oglas == null)
            {
                return NotFound();
            }

            return View(oglas);
        }

        // POST: Oglas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var oglas = await _context.Oglas.FindAsync(id);
            _context.Oglas.Remove(oglas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Zachuvaj(string id) {
            
            var oglas = _context.Oglas.FirstOrDefault(z => z.IdOglas == id);
            
            var name = HttpContext.Session.GetString("korisnikId");
            //var user = _context.Korisnik.FirstOrDefault(z => z.KorisnickoIme == name);
            try
            {
                _context.ZachuvanOd.Add(new ZachuvanOd(oglas.IdOglas, HttpContext.Session.GetString("korisnikId")));
                _context.SaveChanges();
            }
            catch (Exception)
            {

                ViewBag.messagee = "Огласот е веќе зачуван од корисникот: " + HttpContext.Session.GetString("korisnikId");
                return RedirectToAction("Details", new { Id=id } );
            }
            return RedirectToAction("Details", "Korisniks");
        
        }

        public ActionResult Preporachaj()
        {
            ViewBag.oglas = HttpContext.Session.GetString("oglasId");
            ViewBag.KorisnickoImeAdmin = HttpContext.Session.GetString("korisnikAdminId");
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            return View();
        }
        [HttpPost]
        public ActionResult Preporachaj(string id, string oglasId)
        {
            var oglas = _context.Oglas.FirstOrDefault(z => z.IdOglas == oglasId);
            HttpContext.Session.SetString("idOglas", oglas.IdOglas);
            ViewBag.oglass = HttpContext.Session.GetString("idOglas");
            try
            {
                _context.Preporaka.Add(new Preporaka(HttpContext.Session.GetString("korisnikId"), id, oglas.IdOglas));
                _context.SaveChanges();
            }
            catch (Exception)
            {
                HttpContext.Session.SetString("Message", "Огласот е веќе препорачан до корисникот: "+id);
                ViewBag.Message = HttpContext.Session.GetString("Message");
                return RedirectToAction("Preporachaj", "Oglas");
            }
            ViewBag.Message = HttpContext.Session.GetString("Message");
            return RedirectToAction("Details", "Korisniks");
        }
        public ActionResult kupi_oglas()
        {
            ViewBag.oglas = HttpContext.Session.GetString("oglasId");
            ViewBag.KorisnickoIme = HttpContext.Session.GetString("korisnikId");
            return View();
        }
        [HttpPost]
        public ActionResult kupi_oglas(string idTransakcija, string oglasId)
        {
           
            var oglas = _context.Oglas.FirstOrDefault(z => z.IdOglas == oglasId);
            var getTransakcii = _context.TransakciskaSmetka.Select(z => z.BrojTransakcija);
            HttpContext.Session.SetString("idOglas", oglas.IdOglas);
            ViewBag.oglas = HttpContext.Session.GetString("idOglas");
     
            try
            {
               
                var flag = true;
                foreach (var t in _context.TransakciskaSmetka)
                {
                    if (idTransakcija == t.BrojTransakcija)
                    {
                        flag = false;
                        break; 
                    }
                }
                if (flag)
                {
                    _context.TransakciskaSmetka.Add(new TransakciskaSmetka(idTransakcija));
                    _context.Ima.Add(new Ima(HttpContext.Session.GetString("korisnikId"), idTransakcija));
                }
                _context.KupenPreku.Add(new KupenPreku(idTransakcija,oglas.IdOglas));
                
                _context.SaveChanges();
            }
            catch (Exception)
            {
                HttpContext.Session.SetString("kupuva", "Огласот е веќе купен од корисникот: " + HttpContext.Session.GetString("korisnikId"));
                ViewBag.Message = HttpContext.Session.GetString("kupuva");
                return RedirectToAction("Preporachaj", "Oglas");
            }
            ViewBag.Message = HttpContext.Session.GetString("kupuva");
          
            return RedirectToAction("Details", "Korisniks");
        }


        private bool OglasExists(string id)
        {
            return _context.Oglas.Any(e => e.IdOglas == id);
        }
    }
}
