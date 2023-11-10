using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class ZadolzenZa
    {
        public string IdVraboten { get; set; }
        public string ImeKat { get; set; }

        public virtual Administrator IdVrabotenNavigation { get; set; }
        public virtual Kategorija ImeKatNavigation { get; set; }
    }
}
