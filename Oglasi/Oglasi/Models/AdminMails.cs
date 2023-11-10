using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oglasi.Models
{
    public class AdminMails
    {
        public Administrator Admin { get; set; }
        public ICollection<Administrator> Mails { get; set; }

        public AdminMails()
        {
            Mails = new List<Administrator>();
        }
    }
}
