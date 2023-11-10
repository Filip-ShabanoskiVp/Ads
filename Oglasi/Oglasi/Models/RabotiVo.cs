using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class RabotiVo
    {
        public string Ime { get; set; }
        public string IdVraboten { get; set; }

        public virtual Administrator IdVrabotenNavigation { get; set; }
        public virtual Zanas ImeNavigation { get; set; }
    }
}
