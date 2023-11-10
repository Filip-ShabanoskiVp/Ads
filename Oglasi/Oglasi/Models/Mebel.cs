using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Mebel
    {
        public string IdOglas { get; set; }
        public string Namena { get; set; }
        public string Tip { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
    }
}
