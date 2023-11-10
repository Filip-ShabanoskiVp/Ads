using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oglasi.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            DozvolaZaDodavanje = new HashSet<DozvolaZaDodavanje>();
            Ima = new HashSet<Ima>();
            IskluchenOd = new HashSet<IskluchenOd>();
            OtvorenOd = new HashSet<OtvorenOd>();
            PreporakaPrepDoNavigation = new HashSet<Preporaka>();
            PreporakaPrepOdNavigation = new HashSet<Preporaka>();
            RangiranOd = new HashSet<RangiranOd>();
            SopstvenikNa = new HashSet<SopstvenikNa>();
            SpodeluvaNa = new HashSet<SpodeluvaNa>();
            ZachuvanOd = new HashSet<ZachuvanOd>();
        }
        [Required]
        [Display(Name = "Корисничко име")]
        public string KorisnickoIme { get; set; }
        [Required]
        [Display(Name = "Лозинка")]
        public string Lozinka { get; set; }
        [Required]
        [Display(Name = "Име")]
        public string ImeKor { get; set; }
        [Required]
        [Display(Name = "Презиме")]
        public string PrezimeKor { get; set; }
        [Required]
        [Display(Name ="Телефонски број")]
        public string TelefonskiBroj { get; set; }
        [Required]
        [Display(Name = "Меил")]
        public string Mail { get; set; }
        [Required]
        [Display(Name = "Улица")]
        public string Ulica { get; set; }
        [Required]
        [Display(Name ="Град")]
        public string Grad { get; set; }

       // public string LoginErrorMessage { get; set; }

        public virtual Ocenuva Ocenuva { get; set; }
        public virtual PrakaPorakaDo PrakaPorakaDo { get; set; }
        public virtual ICollection<DozvolaZaDodavanje> DozvolaZaDodavanje { get; set; }
        public virtual ICollection<Ima> Ima { get; set; }
        public virtual ICollection<IskluchenOd> IskluchenOd { get; set; }
        public virtual ICollection<OtvorenOd> OtvorenOd { get; set; }
        public virtual ICollection<Preporaka> PreporakaPrepDoNavigation { get; set; }
        public virtual ICollection<Preporaka> PreporakaPrepOdNavigation { get; set; }
        public virtual ICollection<RangiranOd> RangiranOd { get; set; }
        public virtual ICollection<SopstvenikNa> SopstvenikNa { get; set; }
        public virtual ICollection<SpodeluvaNa> SpodeluvaNa { get; set; }
        public virtual ICollection<ZachuvanOd> ZachuvanOd { get; set; }
    }
}
