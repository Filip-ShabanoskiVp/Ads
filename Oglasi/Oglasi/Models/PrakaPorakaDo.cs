using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class PrakaPorakaDo
    {
        public string IdVraboten { get; set; }
        public string KorisnickoIme { get; set; }
        public string Opis { get; set; }
        public int? BrojKategorija { get; set; }

        public virtual Administrator IdVrabotenNavigation { get; set; }
        public virtual Korisnik KorisnickoImeNavigation { get; set; }
    }
}
