using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class KupenPreku
    {
        public KupenPreku(string brojTransakcija, string idOglas)
        {
            BrojTransakcija = brojTransakcija;
            IdOglas = idOglas;
        }

        public DateTime? DatumKupen { get; set; }
        public string BrojTransakcija { get; set; }
        public string IdOglas { get; set; }

        public virtual TransakciskaSmetka BrojTransakcijaNavigation { get; set; }
        public virtual Oglas IdOglasNavigation { get; set; }
    }
}
