using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class Ucenik:Korisnik
    {
        [Key, ForeignKey("KorisnikId")]
        public int UcenikId { get; set; ***REMOVED***
        public string ImeRoditelja { get; set; ***REMOVED***
        public int SmjerId { get; set; ***REMOVED***
        public virtual Smjer Smjer { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
