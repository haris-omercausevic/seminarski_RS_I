using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Data.EF
{
    public class MyContext : DbContext
    {      
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

    ***REMOVED***
        public DbSet<Korisnik> Korisnici { get; set; ***REMOVED***
        public DbSet<Nastavnik> Nastavnici { get; set; ***REMOVED***
        public DbSet<Ucenik> Ucenici { get; set; ***REMOVED***
        public DbSet<Smjer> Smjerovi { get; set; ***REMOVED***
        public DbSet<Izostanak> Izostanci { get; set; ***REMOVED***
        public DbSet<Cas> Casovi { get; set; ***REMOVED***
        public DbSet<KorisnikKontakt> KorisnikKontakt { get; set; ***REMOVED***
        public DbSet<KorisniciUloge> KorisniciUloge { get; set; ***REMOVED***
        public DbSet<Materijal> Materijali { get; set; ***REMOVED***
        public DbSet<Obavijest> Obavijesti { get; set; ***REMOVED***
        public DbSet<Predaje> Predaje { get; set; ***REMOVED***
        public DbSet<Predmet> Predmet { get; set; ***REMOVED***
        //public DbSet<PredmetiNaSmjeru> PredmetiNaSmjeru { get; set; ***REMOVED***
        public DbSet<Razred> Razred { get; set; ***REMOVED***
        public DbSet<SkolskaGodina> SkolskaGodina { get; set; ***REMOVED***
        public DbSet<SmjerPredmet> SmjerPredmet { get; set; ***REMOVED***
        public DbSet<UcenikOcjene> UceniciOcjene { get; set; ***REMOVED***
        public DbSet<UcenikCasovi> UceniciCasovi { get; set; ***REMOVED***
        //public DbSet<UcenikPredmet> UceniciPredmeti { get; set; ***REMOVED***
        public DbSet<UcenikRazredi> UceniciRazredi { get; set; ***REMOVED***
        //public DbSet<UcenikOcjene> UceniciOcjene { get; set; ***REMOVED***

        public DbSet<Uloga> Uloge { get; set; ***REMOVED***
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; ***REMOVED***

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Izostanak>()
                .HasOne(x => x.Ucenik)
                .WithMany()
                .HasForeignKey(x => x.UcenikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UcenikCasovi>()
                .HasOne(x => x.Ucenik)
                .WithMany()
                .HasForeignKey(x => x.UcenikId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UcenikCasovi>()
                .HasOne(x => x.Cas)
                .WithMany()
                .HasForeignKey(x => x.CasId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Razred>()
                .HasOne(x => x.SkolskaGodina)
                .WithMany()
                .HasForeignKey(x => x.SkolskaGodinaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Predaje>()
                .HasOne(x => x.SkolskaGodina)
                .WithMany()
                .HasForeignKey(x => x.SkolskaGodinaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Predaje>()
                .HasOne(x => x.SmjerPredmet)
                .WithMany()
                .HasForeignKey(x => x.SmjerPredmetId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<UcenikPredmet>()
            //    .HasOne(x => x.Ucenik)
            //    .WithMany()
            //    .HasForeignKey(x => x.UcenikId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Materijal>()
                .HasOne(x => x.SkolskaGodina)
                .WithMany()
                .HasForeignKey(x => x.SkolskaGodinaId)
                .OnDelete(DeleteBehavior.Restrict);

            //nakon promjena baze

            modelBuilder.Entity<Razred>()
                .HasOne(x => x.Smjer)
                .WithMany()
                .HasForeignKey(x => x.SmjerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UcenikRazredi>()
               .HasOne(x => x.Ucenik)
               .WithMany()
               .HasForeignKey(x => x.UcenikId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UcenikOcjene>()
               .HasOne(x => x.Ucenik)
               .WithMany()
               .HasForeignKey(x => x.UcenikId)
               .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<UcenikOcjene>()
            //    .HasOne(x => x.UcenikPredmet)
            //    .WithMany()
            //    .HasForeignKey(x => x.UcenikPredmetId)
            //    .OnDelete(DeleteBehavior.Restrict);
    ***REMOVED***
***REMOVED***
***REMOVED***
       
