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
        public DbSet<Ucenik> Ucenici { get; set; ***REMOVED***
        public DbSet<Smjer> Smjerovi { get; set; ***REMOVED***
        public DbSet<Nastavnik> Nastavnici { get; set; ***REMOVED***
        public DbSet<Izostanak> Izostanci { get; set; ***REMOVED***
        public DbSet<Cas> Casovi { get; set; ***REMOVED***
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=localhost;Database=deploy1;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=;Password=");
    ***REMOVED***        

***REMOVED***

***REMOVED***
