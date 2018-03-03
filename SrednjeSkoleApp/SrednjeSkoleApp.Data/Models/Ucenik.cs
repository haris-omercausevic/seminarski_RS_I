using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class Ucenik:Korisnik
    {
        public string ImeRoditelja { get; set; ***REMOVED***
        public int GodinaUpisa { get; set; ***REMOVED***

        public int SmjerId { get; set; ***REMOVED***
        public virtual Smjer Smjer { get; set; ***REMOVED***
        //public virtual List<UcenikRazredi> UcenikRazredi { get; set; ***REMOVED***
        //public virtual List<UcenikPredmet> UcenikPredmeti { get; set; ***REMOVED***
        //public virtual List<UcenikCasovi> UcenikCasovi { get; set; ***REMOVED***
        //public virtual List<Izostanak> Izostanci { get; set; ***REMOVED***

***REMOVED***
***REMOVED***
