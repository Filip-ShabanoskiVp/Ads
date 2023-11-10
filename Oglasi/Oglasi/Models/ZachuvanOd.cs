using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class ZachuvanOd
    {
        public ZachuvanOd(string idOglas, string korisnickoIme)
        {
            IdOglas = idOglas;
            KorisnickoIme = korisnickoIme;
        }

        public string IdOglas { get; set; }
        public string KorisnickoIme { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
        public virtual Korisnik KorisnickoImeNavigation { get; set; }
    }
}
