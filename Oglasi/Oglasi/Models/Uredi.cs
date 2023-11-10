using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Uredi
    {
        public string IdOglas { get; set; }
        public string Marka { get; set; }
        public string Performansi { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
        public virtual Laptopi Laptopi { get; set; }
        public virtual MobilniTelefoni MobilniTelefoni { get; set; }
    }
}
