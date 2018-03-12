using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels
{
    public class RazredDodajVM
    {
        public int id { get; set; ***REMOVED***
        [Range(1,4)]
        public int razredBrojcano { get; set; ***REMOVED***
        [Required]
        [RegularExpression("[a-z]")]
        public string odjeljenje { get; set; ***REMOVED***
        public string oznaka { get; set; ***REMOVED***
        public int nastavnikId { get; set; ***REMOVED***
        public List<SelectListItem> nastavnici { get; set; ***REMOVED***
        public int skolskaGodinaId { get; set; ***REMOVED***
        public List<SelectListItem> skolskeGodine { get; set; ***REMOVED***


***REMOVED***
***REMOVED***
