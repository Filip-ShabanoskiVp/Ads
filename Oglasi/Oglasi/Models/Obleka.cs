using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Obleka
    {
        public string IdOglas { get; set; }
        public string Brend { get; set; }
        public string Tip { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
    }
}
