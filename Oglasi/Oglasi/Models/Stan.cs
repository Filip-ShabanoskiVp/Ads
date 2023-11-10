using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Stan
    {
        public string IdOglas { get; set; }
        public string BrZgrada { get; set; }

        public virtual Zemjishte IdOglasNavigation { get; set; }
    }
}
