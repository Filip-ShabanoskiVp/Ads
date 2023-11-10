using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Grad
    {
        public Grad()
        {
            SeNaogjaVo = new HashSet<SeNaogjaVo>();
        }

        public string ImeGrad { get; set; }

        public virtual ICollection<SeNaogjaVo> SeNaogjaVo { get; set; }
    }
}
