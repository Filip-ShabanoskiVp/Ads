using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class TransakciskaSmetka
    {
        public TransakciskaSmetka(string brojTransakcija)
        {
            KupenPreku = new HashSet<KupenPreku>();
            BrojTransakcija = brojTransakcija;
        }

        public string BrojTransakcija { get; set; }

        public virtual Ima Ima { get; set; }
        public virtual ICollection<KupenPreku> KupenPreku { get; set; }
    }
}
