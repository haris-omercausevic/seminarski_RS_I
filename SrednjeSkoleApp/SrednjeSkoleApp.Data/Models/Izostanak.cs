using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SrednjeSkoleApp.Data.Models
{
    public class Izostanak
    {
        public int IzostanakId { get; set; ***REMOVED***
        public string Razlog { get; set; ***REMOVED***
        public string Komentar { get; set; ***REMOVED***
        public int CasId { get; set; ***REMOVED***
        public virtual Cas Cas { get; set; ***REMOVED***
        public int UcenikId { get; set; ***REMOVED***
        public virtual Ucenik Ucenik { get; set; ***REMOVED***

        //veza sa nastavnikom ne treba jer je sadržan u času
***REMOVED***
***REMOVED***