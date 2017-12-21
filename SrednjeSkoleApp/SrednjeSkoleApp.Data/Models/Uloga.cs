using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class Uloga
    {
        public int UlogaId { get; set; ***REMOVED***
        public string Naziv { get; set; ***REMOVED***
        public bool Administrator { get; set; ***REMOVED***
        public bool Nastavnik { get; set; ***REMOVED***        
        public bool Ucenik{ get; set; ***REMOVED***
        public bool Roditelj { get; set; ***REMOVED***

        public virtual List<KorisnikUloga> KorisniciUloge { get; set; ***REMOVED***

***REMOVED***
***REMOVED***
