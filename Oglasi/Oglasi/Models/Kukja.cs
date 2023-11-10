using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Kukja
    {
        public string IdOglas { get; set; }
        public string DvornaPovrshina { get; set; }

        public virtual Zemjishte IdOglasNavigation { get; set; }
    }
}
