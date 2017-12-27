using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Data.EF
{
    public class MojKontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=test;Trusted_Connection=true;MultipleActiveResultSets=true;User Id =; Password=");
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
        public DbSet<Ocjena> Ocjene { get; set; ***REMOVED***
        public DbSet<Predaje> Predaje { get; set; ***REMOVED***
        public DbSet<Predmet> Predmet { get; set; ***REMOVED***
        public DbSet<PredmetiNaSmjeru> PredmetiNaSmjeru { get; set; ***REMOVED***
        public DbSet<Razred> Razred { get; set; ***REMOVED***
        public DbSet<SkolskaGodina> SkolskaGodina { get; set; ***REMOVED***
        public DbSet<SmjerPredmet> SmjerPredmet { get; set; ***REMOVED***
        public DbSet<UcenikCasovi> UceniciCasovi { get; set; ***REMOVED***
        public DbSet<UcenikPredmet> UceniciPredmeti { get; set; ***REMOVED***
        public DbSet<UcenikRazredi> UceniciRazredi { get; set; ***REMOVED***
        public DbSet<Uloga> Uloge { get; set; ***REMOVED***


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

            //  ===disable all cascade delete===
            //var cascadeFKs = modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetForeignKeys())
            //    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            //foreach (var fk in cascadeFKs)
            //    fk.DeleteBehavior = DeleteBehavior.Restrict;

            //base.OnModelCreating(modelBuilder);
    ***REMOVED***
***REMOVED***
***REMOVED***
       
