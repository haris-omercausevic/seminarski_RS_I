using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class Korisnik
    {
        public int Id { get; set; ***REMOVED***
        [Required]
        public string Ime { get; set; ***REMOVED***
        [Required]
        public string Prezime { get; set; ***REMOVED***
        [Required]
        public string KorisnickoIme { get; set; ***REMOVED***
        public string LozinkaHash { get; set; ***REMOVED***
        public string LozinkaSalt { get; set; ***REMOVED***
        public bool Aktivan { get; set; ***REMOVED***
        public string Spol { get; set; ***REMOVED***
        public DateTime DatumRodjenja { get; set; ***REMOVED***
        public string MjestoRodjenja { get; set; ***REMOVED***
        [MaxLength(13)]
        public string JMBG { get; set; ***REMOVED***
        public string Prebivaliste { get; set; ***REMOVED***
            
        public virtual KorisnikKontakt Kontakt { get; set; ***REMOVED***
        //public virtual List<KorisniciUloge> KorisniciUloge { get; set; ***REMOVED***
        //public virtual List<Obavijest> Obavijesti { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
