using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oglasi.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            DozvolaZaDodavanje = new HashSet<DozvolaZaDodavanje>();
            ENadredenNaIdVrabotenNaredenNavigation = new HashSet<ENadredenNa>();
            PrakaPorakaDo = new HashSet<PrakaPorakaDo>();
            ZadolzenZa = new HashSet<ZadolzenZa>();
        }

        [Display(Name ="Ид вработен")]
        public string IdVraboten { get; set; }
        [Display(Name = "Име")]
        public string Imeadmin { get; set; }
        [Display(Name = "Презиме")]
        public string Prezimeadmin { get; set; }
        [Display(Name = "Меил")]
        public string Mail { get; set; }
        [Display(Name = "Корисничко име")]
        public string KorisnickoIme { get; set; }
        [Display(Name = "Лозинка")]
        [DataType(DataType.Password)]
        public string lozinka { get; set; }

        public virtual ENadredenNa ENadredenNaIdVrabotenPodredenNavigation { get; set; }
        public virtual RabotiVo RabotiVo { get; set; }
        public virtual ICollection<DozvolaZaDodavanje> DozvolaZaDodavanje { get; set; }
        public virtual ICollection<ENadredenNa> ENadredenNaIdVrabotenNaredenNavigation { get; set; }
        public virtual ICollection<PrakaPorakaDo> PrakaPorakaDo { get; set; }
        public virtual ICollection<ZadolzenZa> ZadolzenZa { get; set; }
    }
}
