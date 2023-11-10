using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Koli
    {
        public string IdOglas { get; set; }
        public string Tip { get; set; }
        public string Boja { get; set; }
        public string Model { get; set; }
        public string GodinaProizvedena { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
    }
}
