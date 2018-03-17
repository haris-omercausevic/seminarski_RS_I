using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels
{
    public class NastavnikDodajVM
    {
        //korisnik
        public int? Id { get; set; ***REMOVED***
        [Required]
        public string Ime { get; set; ***REMOVED***
        [Required]
        public string Prezime { get; set; ***REMOVED***
        [Required]
        public string KorisnickoIme { get; set; ***REMOVED***
        [Required]
        public string Lozinka { get; set; ***REMOVED***
        public bool Aktivan { get; set; ***REMOVED***
        public string Spol { get; set; ***REMOVED***
        public DateTime DatumRodjenja { get; set; ***REMOVED***
        public string MjestoRodjenja { get; set; ***REMOVED***
        [Required]
        public string JMBG { get; set; ***REMOVED***
        public string Prebivaliste { get; set; ***REMOVED***

        //korisnik kontakt
        public int? KorisnikKontaktId { get; set; ***REMOVED***
        [Required]
        [EmailAddress]
        public string Email { get; set; ***REMOVED***
        [Required]
        [RegularExpression("[0-9]{3***REMOVED***-[0-9]{3***REMOVED***-[0-9]{3***REMOVED***")]
        public string Telefon { get; set; ***REMOVED***
        [Required]
        public string Adresa { get; set; ***REMOVED***
        [Required]
        public string Grad { get; set; ***REMOVED***
        public string Opstina { get; set; ***REMOVED***

        //nastavnik
        [Required]
        public string Zvanje { get; set; ***REMOVED***
        [Required]
        public DateTime DatumIzboraUZvanje { get; set; ***REMOVED***
        [Required]
        public string NaucnaOblast { get; set; ***REMOVED***
        public int GodinaZaposlenja { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
