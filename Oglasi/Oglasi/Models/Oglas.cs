using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Oglasi.Models
{
    public partial class Oglas
    {
        public Oglas()
        {
            IskluchenOd = new HashSet<IskluchenOd>();
            OtvorenOd = new HashSet<OtvorenOd>();
            Preporaka = new HashSet<Preporaka>();
            RangiranOd = new HashSet<RangiranOd>();
            SopstvenikNa = new HashSet<SopstvenikNa>();
            SpodeluvaNa = new HashSet<SpodeluvaNa>();
            ZachuvanOd = new HashSet<ZachuvanOd>();
        }
        /* [Required]
         [Display(Name = "ID оглас")]*/

        [Key]
        public string IdOglas { get; set; }
        [Required]
        [Display(Name = "Име оглас")]
        public string ImeOglas { get; set; }
        [Required]
        [Display(Name = "Име категорија")]
        public string ImeKat { get; set; }
        [Required]
        [Display(Name = "Цена")]
        public int? Cena { get; set; }
        [Required]
        [Display(Name = "Датум")]
        public DateTime? Datum { get; set; }
        [Required]
        [Display(Name = "Опис")]
        public string Opis { get; set; }

        [Display(Name ="Име категорија")]
        public virtual Kategorija ImeKatNavigation { get; set; }
        public virtual Knigi Knigi { get; set; }
        public virtual Koli Koli { get; set; }
        public virtual KupenPreku KupenPreku { get; set; }
        public virtual Mebel Mebel { get; set; }
        public virtual Obleka Obleka { get; set; }
        public virtual SeNaogjaVo SeNaogjaVo { get; set; }
        public virtual Uredi Uredi { get; set; }
        public virtual Zemjishte Zemjishte { get; set; }
        public virtual ICollection<IskluchenOd> IskluchenOd { get; set; }
        public virtual ICollection<OtvorenOd> OtvorenOd { get; set; }
        public virtual ICollection<Preporaka> Preporaka { get; set; }
        public virtual ICollection<RangiranOd> RangiranOd { get; set; }
        public virtual ICollection<SopstvenikNa> SopstvenikNa { get; set; }
        public virtual ICollection<SpodeluvaNa> SpodeluvaNa { get; set; }
        public virtual ICollection<ZachuvanOd> ZachuvanOd { get; set; }
    }
}
