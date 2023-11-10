using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Ima
    {
        public Ima(string korisnickoIme, string brojTransakcija)
        {
            KorisnickoIme = korisnickoIme;
            BrojTransakcija = brojTransakcija;
        }

        public string KorisnickoIme { get; set; }
        public string BrojTransakcija { get; set; }

        public virtual TransakciskaSmetka BrojTransakcijaNavigation { get; set; }
        public virtual Korisnik KorisnickoImeNavigation { get; set; }
    }
}
