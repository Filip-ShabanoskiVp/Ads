using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Oglas1
    {
        public string IdOglas { get; set; }
        public string ImeOglas { get; set; }
        public int? Cena { get; set; }
        public DateTime? Datum { get; set; }
        public string Opis { get; set; }
    }
}
