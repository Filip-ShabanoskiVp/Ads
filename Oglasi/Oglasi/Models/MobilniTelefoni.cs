using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class MobilniTelefoni
    {
        public string IdOglas { get; set; }
        public string TipSim { get; set; }

        public virtual Uredi IdOglasNavigation { get; set; }
    }
}
