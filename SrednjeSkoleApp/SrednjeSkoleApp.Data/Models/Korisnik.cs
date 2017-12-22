using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class Korisnik
    {
        public int KorisnikId { get; set; ***REMOVED***
        public string Ime { get; set; ***REMOVED***
        public string Prezime { get; set; ***REMOVED***
        public string Lozinka { get; set; ***REMOVED***
        public bool Aktivan { get; set; ***REMOVED***
        public char Spol { get; set; ***REMOVED***
        public DateTime DatumRodjenja { get; set; ***REMOVED***
        public string MjestoRodjenja { get; set; ***REMOVED***
        public string JMBG { get; set; ***REMOVED***
        public string Prebivaliste { get; set; ***REMOVED***

        public virtual KorisnikKontakt Kontakt { get; set; ***REMOVED***
        public virtual List<KorisniciUloge> KorisniciUloge { get; set; ***REMOVED***
        public virtual List<Obavijest> Obavijesti { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
