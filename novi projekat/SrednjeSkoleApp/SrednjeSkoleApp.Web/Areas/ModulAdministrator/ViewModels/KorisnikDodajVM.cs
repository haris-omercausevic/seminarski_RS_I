using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels
{
    public class KorisnikDodajVM
    {
        public int? Id { get; set; ***REMOVED***
        [Required]
        public string Ime { get; set; ***REMOVED***
        [Required]
        public string Prezime { get; set; ***REMOVED***
        [Required]
        [Remote(action: nameof(KorisnikController.ProvjeriKorisnickoIme), controller: "Korisnik")]
        public string KorisnickoIme { get; set; ***REMOVED***
        [Required]
        public string Lozinka { get; set; ***REMOVED***
        public int SelectedUloga { get; set; ***REMOVED***

        public List<RoleVm> uloge;
***REMOVED***
    public class RoleVm
    {
        public int Id { set; get; ***REMOVED***
        public string Naziv { set; get; ***REMOVED***
***REMOVED***
***REMOVED***
