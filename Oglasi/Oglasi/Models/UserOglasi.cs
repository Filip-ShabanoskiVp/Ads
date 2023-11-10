using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oglasi.Models
{
    public class UserOglasi
    {
        public Korisnik User { get; set; }
        public ICollection<Oglas> Saved{ get; set; }
        public ICollection<Oglas> Bought { get; set; }
        public ICollection<Oglas> Created { get; set; }
        public ICollection<Oglas> Recomended { get; set; }
        public UserOglasi() {
            Saved = new List<Oglas>();
            Bought = new List<Oglas>();
            Created = new List<Oglas>();
            Recomended = new List<Oglas>();

        }
    }
}
