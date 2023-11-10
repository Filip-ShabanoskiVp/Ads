using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Ocenuva
    {
        public string KorisnickoIme { get; set; }
        public string Ime { get; set; }
        public int Ocenka { get; set; }

        public virtual Zanas ImeNavigation { get; set; }
        public virtual Korisnik KorisnickoImeNavigation { get; set; }
    }
}
