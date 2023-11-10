using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Laptopi
    {
        public string IdOglas { get; set; }
        public string Tezina { get; set; }

        public virtual Uredi IdOglasNavigation { get; set; }
    }
}
