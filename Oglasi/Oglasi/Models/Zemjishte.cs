using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Zemjishte
    {
        public string IdOglas { get; set; }
        public string Tip { get; set; }
        public string Povrshina { get; set; }
        public string Lokacija { get; set; }
        public string GodinaNaGradba { get; set; }
        public int? BrojNaSobi { get; set; }

        public virtual Oglas IdOglasNavigation { get; set; }
        public virtual Kukja Kukja { get; set; }
        public virtual Stan Stan { get; set; }
    }
}
