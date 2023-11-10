using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class SocijalenMedium
    {
        public SocijalenMedium()
        {
            SpodeluvaNa = new HashSet<SpodeluvaNa>();
        }

        public string Medium { get; set; }

        public virtual ICollection<SpodeluvaNa> SpodeluvaNa { get; set; }
    }
}
