using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Knigi
    {
        public string IdOglas { get; set; }
        public string Naslov { get; set; }
        public string Avtor { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
    }
}
