using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels
{
    public class UcenikDodajVM
    {
        //korisnik
        public int? Id { get; set; ***REMOVED***
        public string Ime { get; set; ***REMOVED***
        public string Prezime { get; set; ***REMOVED***
        public string KorisnickoIme { get; set; ***REMOVED***
        public string Lozinka { get; set; ***REMOVED***
        public bool Aktivan { get; set; ***REMOVED***
        public string Spol { get; set; ***REMOVED***
        public DateTime DatumRodjenja { get; set; ***REMOVED***
        public string MjestoRodjenja { get; set; ***REMOVED***
        public string JMBG { get; set; ***REMOVED***
        public string Prebivaliste { get; set; ***REMOVED***

        //korisnik kontakt
        public int? KorisnikKontaktId { get; set; ***REMOVED***
        public string Email { get; set; ***REMOVED***
        public string Telefon { get; set; ***REMOVED***
        public string Adresa { get; set; ***REMOVED***
        public string Grad { get; set; ***REMOVED***
        public string Opstina { get; set; ***REMOVED***

        //ucenik
        public string ImeRoditelja { get; set; ***REMOVED***
        public int GodinaUpisa { get; set; ***REMOVED***
        public int SmjerId { get; set; ***REMOVED***
        public List<SelectListItem> smjerovi { get; set; ***REMOVED***
        public int RazredId { get; set; ***REMOVED***
        public List<SelectListItem> razredi { get; set; ***REMOVED***
        public string NazivOsnovneSkole { get; set; ***REMOVED***
        public double? ProsjekOcjenaOsnovnaSkola { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
