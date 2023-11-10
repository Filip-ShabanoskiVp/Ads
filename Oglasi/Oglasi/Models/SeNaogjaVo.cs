using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class SeNaogjaVo
    {
        public string IdOglas { get; set; }
        public string ImeGrad { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
        public virtual Grad ImeGradNavigation { get; set; }
    }
}
