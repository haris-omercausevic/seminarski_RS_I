using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SrednjeSkoleApp.Data.Models
{
    public class AutorizacijskiToken
    {
        public int Id { get; set; ***REMOVED***
        public string Vrijednost { get; set; ***REMOVED***
        [ForeignKey(nameof(KorisnickiNalog))]
        public int KorisnickiNalogId { get; set; ***REMOVED***
        public Korisnik KorisnickiNalog { get; set; ***REMOVED***
        public DateTime VrijemeEvidentiranja { get; set; ***REMOVED***
        public string IpAdresa { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
