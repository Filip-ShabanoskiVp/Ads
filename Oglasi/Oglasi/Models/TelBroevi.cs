using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class TelBroevi
    {
        public string Ime { get; set; }
        public string TelBr { get; set; }

        public virtual Zanas ImeNavigation { get; set; }
    }
}
