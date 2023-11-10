using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Preporaka
    {
        public Preporaka(string prepOd, string prepDo, string idOglas)
        {
            PrepOd = prepOd;
            PrepDo = prepDo;
            IdOglas = idOglas;
        }

        public string PrepOd { get; set; }
        public string PrepDo { get; set; }
        public string IdOglas { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
        public virtual Korisnik PrepDoNavigation { get; set; }
        public virtual Korisnik PrepOdNavigation { get; set; }
    }
}
