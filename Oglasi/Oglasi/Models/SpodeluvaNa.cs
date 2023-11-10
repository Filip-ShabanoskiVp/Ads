using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class SpodeluvaNa
    {
        public string IdOglas { get; set; }
        public string KorisnickoIme { get; set; }
        public string Medium { get; set; }
        public DateTime? DatumSpodelen { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
        public virtual Korisnik KorisnickoImeNavigation { get; set; }
        public virtual SocijalenMedium MediumNavigation { get; set; }
    }
}
