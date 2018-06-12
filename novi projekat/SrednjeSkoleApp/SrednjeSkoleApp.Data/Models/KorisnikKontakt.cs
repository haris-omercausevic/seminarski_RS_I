using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class KorisnikKontakt
    {
        [ForeignKey("Korisnik")]
        public int KorisnikKontaktId { get; set; ***REMOVED***
        public string Email {get; set;***REMOVED***
        public string Telefon {get; set;***REMOVED***
        public string Adresa {get; set;***REMOVED***
        public string Grad {get; set;***REMOVED***
        public string Opstina {get; set;***REMOVED***
        public virtual Korisnik Korisnik { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
