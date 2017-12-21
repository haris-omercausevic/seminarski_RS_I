using System;
using System.Collections.Generic;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class Obavijest
    {
        public int ObavijestID{ get; set; ***REMOVED***
        public string Naslov { get; set; ***REMOVED***
        public string Tekst { get; set; ***REMOVED***

        public int KorisnikID { get; set; ***REMOVED***
        public virtual Korisnik Korisnik { get; set; ***REMOVED***
***REMOVED***
***REMOVED***

//departments - obavijesti
//employees - korisnik

    //jedan korisnik moze postavljati vise obavijesti
    // jednu obavijest moze postaviti samo 1 korisnik

    //u jednom odjelu moze biti vise zaposlenika
    //jedan zaposlenik moze biti dio samo 1 odjela

    //korisnik === department
    // obavijest === employee