using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels
{
    public class SmjerDodajVM
    {
        public int id { get; set; ***REMOVED***
        [Required]
        public string Naziv { get; set; ***REMOVED***
        [Required]
        public string Opis { get; set; ***REMOVED***
        public int skolskaGodinaId { get; set; ***REMOVED***
        public List<SelectListItem> skolskeGodine { get; set; ***REMOVED***
        public List<CheckBoxVM> predmeti { get; set; ***REMOVED***

        //public SmjerDodajVM()
        //{
        //    predmeti = new List<CheckBoxVM>();
        //***REMOVED***
***REMOVED***
***REMOVED***
