using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels
{
    public class UcenikDodajVM
    {
        //korisnik
        public int? Id { get; set; ***REMOVED***
        [Required]
        public string Ime { get; set; ***REMOVED***
        [Required]
        public string Prezime { get; set; ***REMOVED***
        [Required]
        [Remote(action:nameof(KorisnikController.ProvjeriKorisnickoIme),controller:"Korisnik")]
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

        //ucenik
        [Required]
        public string ImeRoditelja { get; set; ***REMOVED***
        [Required]
        public int GodinaUpisa { get; set; ***REMOVED***
        public int SmjerId { get; set; ***REMOVED***
        public List<SelectListItem> smjerovi { get; set; ***REMOVED***
        public int RazredId { get; set; ***REMOVED***
        public List<SelectListItem> razredi { get; set; ***REMOVED***
        public string NazivOsnovneSkole { get; set; ***REMOVED***
        public double? ProsjekOcjenaOsnovnaSkola { get; set; ***REMOVED***
***REMOVED***
***REMOVED***
