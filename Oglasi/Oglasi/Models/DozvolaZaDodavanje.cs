using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class DozvolaZaDodavanje
    {
        public string IdVraboten { get; set; }
        public string KorisnickoIme { get; set; }
        public string ImeKat { get; set; }
        public string StatusNaValidacija { get; set; }

        public virtual Administrator IdVrabotenNavigation { get; set; }
        public virtual Kategorija ImeKatNavigation { get; set; }
        public virtual Korisnik KorisnickoImeNavigation { get; set; }
    }
}
