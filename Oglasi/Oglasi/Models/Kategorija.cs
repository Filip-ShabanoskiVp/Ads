using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Kategorija
    {
        public Kategorija()
        {
            DozvolaZaDodavanje = new HashSet<DozvolaZaDodavanje>();
            Oglas = new HashSet<Oglas>();
            ZadolzenZa = new HashSet<ZadolzenZa>();
        }

        public string ImeKat { get; set; }
        public int? BrojKat { get; set; }
        public int? BrojNaOglasi { get; set; }

        public virtual ICollection<DozvolaZaDodavanje> DozvolaZaDodavanje { get; set; }
        public virtual ICollection<Oglas> Oglas { get; set; }
        public virtual ICollection<ZadolzenZa> ZadolzenZa { get; set; }
    }
}
