using System;
using System.Collections.Generic;

namespace Oglasi.Models
{
    public partial class Zanas
    {
        public Zanas()
        {
            Ocenuva = new HashSet<Ocenuva>();
            RabotiVo = new HashSet<RabotiVo>();
            TelBroevi = new HashSet<TelBroevi>();
        }

        public string Ime { get; set; }
        public string Mail { get; set; }
        public string Lokacija { get; set; }

        public virtual ICollection<Ocenuva> Ocenuva { get; set; }
        public virtual ICollection<RabotiVo> RabotiVo { get; set; }
        public virtual ICollection<TelBroevi> TelBroevi { get; set; }
    }
}
