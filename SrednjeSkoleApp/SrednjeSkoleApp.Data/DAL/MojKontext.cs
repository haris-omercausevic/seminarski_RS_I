using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{

   
    public class MojKontext : DbContext
    {
        
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



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=localhost;Database=deploy1;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=;Password=");
    ***REMOVED***        

***REMOVED***

***REMOVED***
