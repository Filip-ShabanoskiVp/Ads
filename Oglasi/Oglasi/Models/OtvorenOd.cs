using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class OtvorenOd
    {
        public string IdOglas { get; set; }
        public string KorisnickoIme { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
        public virtual Korisnik KorisnickoImeNavigation { get; set; }
    }
}
