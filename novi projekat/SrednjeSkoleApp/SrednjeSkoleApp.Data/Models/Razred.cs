using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class Razred
    {
        public int RazredId { get; set; ***REMOVED***
        public int RazredBrojcano { get; set; ***REMOVED***
        public string Odjeljenje { get; set; ***REMOVED***
        public string Oznaka { get; set; ***REMOVED***
        public int SkolskaGodinaId { get; set; ***REMOVED***
        public virtual SkolskaGodina SkolskaGodina { get; set; ***REMOVED***
        
        //razrednik
        [ForeignKey("Nastavnik")]
        public int RazrednikId { get; set; ***REMOVED***
        public virtual Nastavnik Razrednik { get; set; ***REMOVED***

        public int SmjerId { get; set; ***REMOVED***
        public Smjer Smjer { get; set; ***REMOVED***


***REMOVED***
***REMOVED***
