using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Oglasi.Models
{
    public partial class db_201920z_va_prj_oglasnikContext : DbContext
    {
        public db_201920z_va_prj_oglasnikContext()
        {
        }

        public db_201920z_va_prj_oglasnikContext(DbContextOptions<db_201920z_va_prj_oglasnikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<DozvolaZaDodavanje> DozvolaZaDodavanje { get; set; }
        public virtual DbSet<ENadredenNa> ENadredenNa { get; set; }
        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Ima> Ima { get; set; }
        public virtual DbSet<IskluchenOd> IskluchenOd { get; set; }
        public virtual DbSet<Kategorija> Kategorija { get; set; }
        public virtual DbSet<Knigi> Knigi { get; set; }
        public virtual DbSet<Koli> Koli { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Kukja> Kukja { get; set; }
        public virtual DbSet<KupenPreku> KupenPreku { get; set; }
        public virtual DbSet<Laptopi> Laptopi { get; set; }
        public virtual DbSet<Mebel> Mebel { get; set; }
        public virtual DbSet<MobilniTelefoni> MobilniTelefoni { get; set; }
        public virtual DbSet<Obleka> Obleka { get; set; }
        public virtual DbSet<Ocenuva> Ocenuva { get; set; }
        public virtual DbSet<Oglas> Oglas { get; set; }
        public virtual DbSet<Oglas1> Oglas1 { get; set; }
        public virtual DbSet<OtvorenOd> OtvorenOd { get; set; }
        public virtual DbSet<PrakaPorakaDo> PrakaPorakaDo { get; set; }
        public virtual DbSet<Preporaka> Preporaka { get; set; }
        public virtual DbSet<RabotiVo> RabotiVo { get; set; }
        public virtual DbSet<RangiranOd> RangiranOd { get; set; }
        public virtual DbSet<SeNaogjaVo> SeNaogjaVo { get; set; }
        public virtual DbSet<SocijalenMedium> SocijalenMedium { get; set; }
        public virtual DbSet<SopstvenikNa> SopstvenikNa { get; set; }
        public virtual DbSet<SpodeluvaNa> SpodeluvaNa { get; set; }
        public virtual DbSet<Stan> Stan { get; set; }
        public virtual DbSet<TelBroevi> TelBroevi { get; set; }
        public virtual DbSet<TransakciskaSmetka> TransakciskaSmetka { get; set; }
        public virtual DbSet<Uredi> Uredi { get; set; }
        public virtual DbSet<ZachuvanOd> ZachuvanOd { get; set; }
        public virtual DbSet<ZadolzenZa> ZadolzenZa { get; set; }
        public virtual DbSet<Zanas> Zanas { get; set; }
        public virtual DbSet<Zemjishte> Zemjishte { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;port=9999;Database=db_201920z_va_prj_oglasnik;Username=db_201920z_va_prj_oglasnik_owner;Password=oglasnik");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.HasSequence<int>("id_oglas", schema: "project")
        .StartsAt(207)
        .IncrementsBy(1);

            modelBuilder.Entity<Administrator>(entity =>
            {

                entity.HasKey(e => e.IdVraboten)
                    .HasName("administrator_pkey");

                entity.ToTable("administrator", "project");

                entity.Property(e => e.IdVraboten)
                    .HasColumnName("id_vraboten")
                    .HasMaxLength(20);

                entity.Property(e => e.Imeadmin)
                    .IsRequired()
                    .HasColumnName("imeadmin")
                    .HasMaxLength(30);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(30);

                entity.Property(e => e.Prezimeadmin)
                    .IsRequired()
                    .HasColumnName("prezimeadmin")
                    .HasMaxLength(30);
                entity.Property(e => e.lozinka)
                   .IsRequired()
                   .HasColumnName("lozinka")
                   .HasMaxLength(30);
            });

            modelBuilder.Entity<DozvolaZaDodavanje>(entity =>
            {
                entity.HasKey(e => new { e.IdVraboten, e.KorisnickoIme, e.ImeKat })
                    .HasName("pk_dozvola");

                entity.ToTable("dozvola_za_dodavanje", "project");

                entity.Property(e => e.IdVraboten)
                    .HasColumnName("id_vraboten")
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.Property(e => e.ImeKat)
                    .HasColumnName("ime_kat")
                    .HasMaxLength(30);

                entity.Property(e => e.StatusNaValidacija)
                    .HasColumnName("status_na_validacija")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdVrabotenNavigation)
                    .WithMany(p => p.DozvolaZaDodavanje)
                    .HasForeignKey(d => d.IdVraboten)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dozvola_za_dodavanje_id_vraboten_fkey");

                entity.HasOne(d => d.ImeKatNavigation)
                    .WithMany(p => p.DozvolaZaDodavanje)
                    .HasForeignKey(d => d.ImeKat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dozvola_za_dodavanje_ime_kat_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.DozvolaZaDodavanje)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("dozvola_za_dodavanje_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<ENadredenNa>(entity =>
            {
                entity.HasKey(e => e.IdVrabotenPodreden)
                    .HasName("e_nadreden_na_pkey");

                entity.ToTable("e_nadreden_na", "project");

                entity.Property(e => e.IdVrabotenPodreden)
                    .HasColumnName("id_vraboten_podreden")
                    .HasMaxLength(30);

                entity.Property(e => e.IdVrabotenNareden)
                    .HasColumnName("id_vraboten_nareden")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdVrabotenNaredenNavigation)
                    .WithMany(p => p.ENadredenNaIdVrabotenNaredenNavigation)
                    .HasForeignKey(d => d.IdVrabotenNareden)
                    .HasConstraintName("e_nadreden_na_id_vraboten_nareden_fkey");

                entity.HasOne(d => d.IdVrabotenPodredenNavigation)
                    .WithOne(p => p.ENadredenNaIdVrabotenPodredenNavigation)
                    .HasForeignKey<ENadredenNa>(d => d.IdVrabotenPodreden)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("e_nadreden_na_id_vraboten_podreden_fkey");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasKey(e => e.ImeGrad)
                    .HasName("grad_pkey");

                entity.ToTable("grad", "project");

                entity.Property(e => e.ImeGrad)
                    .HasColumnName("ime_grad")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Ima>(entity =>
            {
                entity.HasKey(e => e.BrojTransakcija)
                    .HasName("ima_pkey");

                entity.ToTable("ima", "project");

                entity.Property(e => e.BrojTransakcija)
                    .HasColumnName("broj_transakcija")
                    .HasMaxLength(50);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.HasOne(d => d.BrojTransakcijaNavigation)
                    .WithOne(p => p.Ima)
                    .HasForeignKey<Ima>(d => d.BrojTransakcija)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ima_broj_transakcija_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.Ima)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .HasConstraintName("ima_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<IskluchenOd>(entity =>
            {
                entity.HasKey(e => new { e.IdOglas, e.KorisnickoIme })
                    .HasName("pk_iskluchen");

                entity.ToTable("iskluchen_od", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithMany(p => p.IskluchenOd)
                    .HasForeignKey(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("iskluchen_od_id_oglas_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.IskluchenOd)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("iskluchen_od_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<Kategorija>(entity =>
            {
                entity.HasKey(e => e.ImeKat)
                    .HasName("kategorija_pkey");

                entity.ToTable("kategorija", "project");

                entity.Property(e => e.ImeKat)
                    .HasColumnName("ime_kat")
                    .HasMaxLength(30);

                entity.Property(e => e.BrojKat).HasColumnName("broj_kat");

                entity.Property(e => e.BrojNaOglasi).HasColumnName("broj_na_oglasi");
            });

            modelBuilder.Entity<Knigi>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("knigi_pkey");

                entity.ToTable("knigi", "project");

                entity.HasIndex(e => e.Naslov)
                    .HasName("knigi_naslov_key")
                    .IsUnique();

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Avtor)
                    .HasColumnName("avtor")
                    .HasMaxLength(50);

                entity.Property(e => e.Naslov)
                    .IsRequired()
                    .HasColumnName("naslov")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Knigi)
                    .HasForeignKey<Knigi>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("knigi_id_oglas_fkey");
            });

            modelBuilder.Entity<Koli>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("koli_pkey");

                entity.ToTable("koli", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Boja)
                    .HasColumnName("boja")
                    .HasMaxLength(20);

                entity.Property(e => e.GodinaProizvedena)
                    .HasColumnName("godina_proizvedena")
                    .HasColumnType("character varying");

                entity.Property(e => e.Model)
                    .HasColumnName("model")
                    .HasMaxLength(30);

                entity.Property(e => e.Tip)
                    .HasColumnName("tip")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Koli)
                    .HasForeignKey<Koli>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("koli_id_oglas_fkey");
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasKey(e => e.KorisnickoIme)
                    .HasName("korisnik_pkey");

                entity.ToTable("korisnik", "project");

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.Property(e => e.Grad)
                    .HasColumnName("grad")
                    .HasMaxLength(20);

                entity.Property(e => e.ImeKor)
                    .IsRequired()
                    .HasColumnName("ime_kor")
                    .HasMaxLength(20);

                entity.Property(e => e.Lozinka)
                    .IsRequired()
                    .HasColumnName("lozinka")
                    .HasMaxLength(50);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(30);

                entity.Property(e => e.PrezimeKor)
                    .IsRequired()
                    .HasColumnName("prezime_kor")
                    .HasMaxLength(20);

                entity.Property(e => e.TelefonskiBroj)
                    .IsRequired()
                    .HasColumnName("telefonski_broj")
                    .HasMaxLength(30);

                entity.Property(e => e.Ulica)
                    .HasColumnName("ulica")
                    .HasMaxLength(50);
               /* entity.Property(e => e.LoginErrorMessage)
                .HasColumnName("login_error_message")
                .HasMaxLength(30);*/
            });

            modelBuilder.Entity<Kukja>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("kukja_pkey");

                entity.ToTable("kukja", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.DvornaPovrshina)
                    .HasColumnName("dvorna_povrshina")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Kukja)
                    .HasForeignKey<Kukja>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kukja_id_oglas_fkey");
            });

            modelBuilder.Entity<KupenPreku>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("kupen_preku_pkey");

                entity.ToTable("kupen_preku", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.BrojTransakcija)
                    .HasColumnName("broj_transakcija")
                    .HasMaxLength(50);

                entity.Property(e => e.DatumKupen)
                    .HasColumnName("datum_kupen")
                    .HasColumnType("date");

                entity.HasOne(d => d.BrojTransakcijaNavigation)
                    .WithMany(p => p.KupenPreku)
                    .HasForeignKey(d => d.BrojTransakcija)
                    .HasConstraintName("kupen_preku_broj_transakcija_fkey");

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.KupenPreku)
                    .HasForeignKey<KupenPreku>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kupen_preku_id_oglas_fkey");
            });

            modelBuilder.Entity<Laptopi>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("laptopi_pkey");

                entity.ToTable("laptopi", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Tezina)
                    .HasColumnName("tezina")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Laptopi)
                    .HasForeignKey<Laptopi>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("laptopi_id_oglas_fkey");
            });

            modelBuilder.Entity<Mebel>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("mebel_pkey");

                entity.ToTable("mebel", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Namena)
                    .HasColumnName("namena")
                    .HasMaxLength(50);

                entity.Property(e => e.Tip)
                    .HasColumnName("tip")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Mebel)
                    .HasForeignKey<Mebel>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mebel_id_oglas_fkey");
            });

            modelBuilder.Entity<MobilniTelefoni>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("mobilni_telefoni_pkey");

                entity.ToTable("mobilni_telefoni", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.TipSim)
                    .HasColumnName("tip_sim")
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.MobilniTelefoni)
                    .HasForeignKey<MobilniTelefoni>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mobilni_telefoni_id_oglas_fkey");
            });

            modelBuilder.Entity<Obleka>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("obleka_pkey");

                entity.ToTable("obleka", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Brend)
                    .HasColumnName("brend")
                    .HasMaxLength(30);

                entity.Property(e => e.Tip)
                    .HasColumnName("tip")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Obleka)
                    .HasForeignKey<Obleka>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("obleka_id_oglas_fkey");
            });

            modelBuilder.Entity<Ocenuva>(entity =>
            {
                entity.HasKey(e => e.KorisnickoIme)
                    .HasName("ocenuva_pkey");

                entity.ToTable("ocenuva", "project");

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(20);

                entity.Property(e => e.Ocenka).HasColumnName("ocenka");

                entity.HasOne(d => d.ImeNavigation)
                    .WithMany(p => p.Ocenuva)
                    .HasForeignKey(d => d.Ime)
                    .HasConstraintName("ocenuva_ime_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithOne(p => p.Ocenuva)
                    .HasForeignKey<Ocenuva>(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ocenuva_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<Oglas>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                
                    .HasName("oglas_pkey");


                entity.ToTable("oglas", "project");

                entity.Property(e => e.IdOglas)
                
                .HasDefaultValueSql("NEXT VALUE FOR project.oglas.id_oglas")
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.ImeKat)
                    .HasColumnName("ime_kat")
                    .HasMaxLength(30);

                entity.Property(e => e.ImeOglas)
                    .HasColumnName("ime_oglas")
                    .HasMaxLength(30);

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.ImeKatNavigation)
                    .WithMany(p => p.Oglas)
                    .HasForeignKey(d => d.ImeKat)
                    .HasConstraintName("fk_pripagja_vo_kategorija");
            });

            modelBuilder.Entity<Oglas1>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("oglas_pkey");

                entity.ToTable("oglas");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Cena).HasColumnName("cena");

                entity.Property(e => e.Datum)
                    .HasColumnName("datum")
                    .HasColumnType("date");

                entity.Property(e => e.ImeOglas)
                    .HasColumnName("ime_oglas")
                    .HasMaxLength(30);

                entity.Property(e => e.Opis)
                    .HasColumnName("opis")
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<OtvorenOd>(entity =>
            {
                entity.HasKey(e => new { e.IdOglas, e.KorisnickoIme })
                    .HasName("pk_otvoren");

                entity.ToTable("otvoren_od", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithMany(p => p.OtvorenOd)
                    .HasForeignKey(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("otvoren_od_id_oglas_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.OtvorenOd)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("otvoren_od_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<PrakaPorakaDo>(entity =>
            {
                entity.HasKey(e => e.KorisnickoIme)
                    .HasName("praka_poraka_do_pkey");

                entity.ToTable("praka_poraka_do", "project");

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.Property(e => e.BrojKategorija).HasColumnName("broj_kategorija");

                entity.Property(e => e.IdVraboten)
                    .HasColumnName("id_vraboten")
                    .HasMaxLength(30);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasColumnName("opis")
                    .HasMaxLength(1000);

                entity.HasOne(d => d.IdVrabotenNavigation)
                    .WithMany(p => p.PrakaPorakaDo)
                    .HasForeignKey(d => d.IdVraboten)
                    .HasConstraintName("praka_poraka_do_id_vraboten_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithOne(p => p.PrakaPorakaDo)
                    .HasForeignKey<PrakaPorakaDo>(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("praka_poraka_do_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<Preporaka>(entity =>
            {
                entity.HasKey(e => new { e.PrepOd, e.PrepDo, e.IdOglas })
                    .HasName("pk_preporaka");

                entity.ToTable("preporaka", "project");

                entity.Property(e => e.PrepOd)
                    .HasColumnName("prep_od")
                    .HasMaxLength(30);

                entity.Property(e => e.PrepDo)
                    .HasColumnName("prep_do")
                    .HasMaxLength(30);

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithMany(p => p.Preporaka)
                    .HasForeignKey(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preporaka_id_oglas_fkey");

                entity.HasOne(d => d.PrepDoNavigation)
                    .WithMany(p => p.PreporakaPrepDoNavigation)
                    .HasForeignKey(d => d.PrepDo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preporaka_prep_do_fkey");

                entity.HasOne(d => d.PrepOdNavigation)
                    .WithMany(p => p.PreporakaPrepOdNavigation)
                    .HasForeignKey(d => d.PrepOd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("preporaka_prep_od_fkey");
            });

            modelBuilder.Entity<RabotiVo>(entity =>
            {
                entity.HasKey(e => e.IdVraboten)
                    .HasName("raboti_vo_pkey");

                entity.ToTable("raboti_vo", "project");

                entity.Property(e => e.IdVraboten)
                    .HasColumnName("id_vraboten")
                    .HasMaxLength(20);

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdVrabotenNavigation)
                    .WithOne(p => p.RabotiVo)
                    .HasForeignKey<RabotiVo>(d => d.IdVraboten)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("raboti_vo_id_vraboten_fkey");

                entity.HasOne(d => d.ImeNavigation)
                    .WithMany(p => p.RabotiVo)
                    .HasForeignKey(d => d.Ime)
                    .HasConstraintName("raboti_vo_ime_fkey");
            });

            modelBuilder.Entity<RangiranOd>(entity =>
            {
                entity.HasKey(e => new { e.IdOglas, e.KorisnickoIme })
                    .HasName("pk_rangiran");

                entity.ToTable("rangiran_od", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.Property(e => e.Ocenka).HasColumnName("ocenka");

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithMany(p => p.RangiranOd)
                    .HasForeignKey(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rangiran_od_id_oglas_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.RangiranOd)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("rangiran_od_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<SeNaogjaVo>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("se_naogja_vo_pkey");

                entity.ToTable("se_naogja_vo", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.ImeGrad)
                    .HasColumnName("ime_grad")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.SeNaogjaVo)
                    .HasForeignKey<SeNaogjaVo>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("se_naogja_vo_id_oglas_fkey");

                entity.HasOne(d => d.ImeGradNavigation)
                    .WithMany(p => p.SeNaogjaVo)
                    .HasForeignKey(d => d.ImeGrad)
                    .HasConstraintName("se_naogja_vo_ime_grad_fkey");
            });

            modelBuilder.Entity<SocijalenMedium>(entity =>
            {
                entity.HasKey(e => e.Medium)
                    .HasName("socijalen_medium_pkey");

                entity.ToTable("socijalen_medium", "project");

                entity.Property(e => e.Medium)
                    .HasColumnName("medium")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<SopstvenikNa>(entity =>
            {
                entity.HasKey(e => new { e.IdOglas, e.KorisnickoIme })
                    .HasName("pk_sopstvenik");

                entity.ToTable("sopstvenik_na", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithMany(p => p.SopstvenikNa)
                    .HasForeignKey(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sopstvenik_na_id_oglas_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.SopstvenikNa)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sopstvenik_na_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<SpodeluvaNa>(entity =>
            {
                entity.HasKey(e => new { e.IdOglas, e.KorisnickoIme, e.Medium })
                    .HasName("pk_spodeluva");

                entity.ToTable("spodeluva_na", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.Property(e => e.Medium)
                    .HasColumnName("medium")
                    .HasMaxLength(30);

                entity.Property(e => e.DatumSpodelen)
                    .HasColumnName("datum_spodelen")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithMany(p => p.SpodeluvaNa)
                    .HasForeignKey(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spodeluva_na_id_oglas_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.SpodeluvaNa)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spodeluva_na_korisnicko_ime_fkey");

                entity.HasOne(d => d.MediumNavigation)
                    .WithMany(p => p.SpodeluvaNa)
                    .HasForeignKey(d => d.Medium)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spodeluva_na_medium_fkey");
            });

            modelBuilder.Entity<Stan>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("stan_pkey");

                entity.ToTable("stan", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.BrZgrada)
                    .HasColumnName("br_zgrada")
                    .HasMaxLength(20);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Stan)
                    .HasForeignKey<Stan>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("stan_id_oglas_fkey");
            });

            modelBuilder.Entity<TelBroevi>(entity =>
            {
                entity.HasKey(e => new { e.Ime, e.TelBr })
                    .HasName("pk_telefonski_broevi");

                entity.ToTable("tel_broevi", "project");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(20);

                entity.Property(e => e.TelBr)
                    .HasColumnName("tel_br")
                    .HasMaxLength(30);

                entity.HasOne(d => d.ImeNavigation)
                    .WithMany(p => p.TelBroevi)
                    .HasForeignKey(d => d.Ime)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tel_broevi_ime_fkey");
            });

            modelBuilder.Entity<TransakciskaSmetka>(entity =>
            {
                entity.HasKey(e => e.BrojTransakcija)
                    .HasName("transakciska_smetka_pkey");

                entity.ToTable("transakciska_smetka", "project");

                entity.Property(e => e.BrojTransakcija)
                    .HasColumnName("broj_transakcija")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Uredi>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("uredi_pkey");

                entity.ToTable("uredi", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.Marka)
                    .HasColumnName("marka")
                    .HasMaxLength(40);

                entity.Property(e => e.Performansi)
                    .HasColumnName("performansi")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Uredi)
                    .HasForeignKey<Uredi>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("uredi_id_oglas_fkey");
            });

            modelBuilder.Entity<ZachuvanOd>(entity =>
            {
                entity.HasKey(e => new { e.IdOglas, e.KorisnickoIme })
                    .HasName("pk_zachuvan");

                entity.ToTable("zachuvan_od", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.KorisnickoIme)
                    .HasColumnName("korisnicko_ime")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithMany(p => p.ZachuvanOd)
                    .HasForeignKey(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zachuvan_od_id_oglas_fkey");

                entity.HasOne(d => d.KorisnickoImeNavigation)
                    .WithMany(p => p.ZachuvanOd)
                    .HasForeignKey(d => d.KorisnickoIme)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zachuvan_od_korisnicko_ime_fkey");
            });

            modelBuilder.Entity<ZadolzenZa>(entity =>
            {
                entity.HasKey(e => new { e.IdVraboten, e.ImeKat })
                    .HasName("pk_zadolzen");

                entity.ToTable("zadolzen_za", "project");

                entity.Property(e => e.IdVraboten)
                    .HasColumnName("id_vraboten")
                    .HasMaxLength(20);

                entity.Property(e => e.ImeKat)
                    .HasColumnName("ime_kat")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdVrabotenNavigation)
                    .WithMany(p => p.ZadolzenZa)
                    .HasForeignKey(d => d.IdVraboten)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zadolzen_za_id_vraboten_fkey");

                entity.HasOne(d => d.ImeKatNavigation)
                    .WithMany(p => p.ZadolzenZa)
                    .HasForeignKey(d => d.ImeKat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zadolzen_za_ime_kat_fkey");
            });

            modelBuilder.Entity<Zanas>(entity =>
            {
                entity.HasKey(e => e.Ime)
                    .HasName("zanas_pkey");

                entity.ToTable("zanas", "project");

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(20);

                entity.Property(e => e.Lokacija)
                    .HasColumnName("lokacija")
                    .HasMaxLength(30);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnName("mail")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Zemjishte>(entity =>
            {
                entity.HasKey(e => e.IdOglas)
                    .HasName("zemjishte_pkey");

                entity.ToTable("zemjishte", "project");

                entity.Property(e => e.IdOglas)
                    .HasColumnName("id_oglas")
                    .HasMaxLength(20);

                entity.Property(e => e.BrojNaSobi).HasColumnName("broj_na_sobi");

                entity.Property(e => e.GodinaNaGradba)
                    .HasColumnName("godina_na_gradba")
                    .HasColumnType("character varying");

                entity.Property(e => e.Lokacija)
                    .HasColumnName("lokacija")
                    .HasMaxLength(20);

                entity.Property(e => e.Povrshina)
                    .HasColumnName("povrshina")
                    .HasMaxLength(20);

                entity.Property(e => e.Tip)
                    .HasColumnName("tip")
                    .HasMaxLength(30);

                entity.HasOne(d => d.IdOglasNavigation)
                    .WithOne(p => p.Zemjishte)
                    .HasForeignKey<Zemjishte>(d => d.IdOglas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("zemjishte_id_oglas_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
