using System;
using System.Collections.Generic;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class UcenikPredmet
    {
        public int UcenikPredmetId { get; set; ***REMOVED***
        public double? ZakljucnaOcjena { get; set; ***REMOVED***
        public int PredmetId { get; set; ***REMOVED***
        public virtual Predmet Predmet { get; set; ***REMOVED***
        public int NastavnikId { get; set; ***REMOVED***
        public virtual Nastavnik Nastavnik { get; set; ***REMOVED***

        public int UcenikId { get; set; ***REMOVED***
        public virtual Ucenik Ucenik { get; set; ***REMOVED***

        public virtual List<Ocjena> Ocjene { get; set; ***REMOVED***
        
***REMOVED***
***REMOVED***
