using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels
{
    public class UcenikIndexVM
    {
        public int razredId { get; set; ***REMOVED***
        public List<SelectListItem> razredi { get; set; ***REMOVED***
        public int smjerId { get; set; ***REMOVED***
        public List<SelectListItem> smjerovi { get; set; ***REMOVED***
        public List<Row> rows { get; set; ***REMOVED***
        public class Row
        {
            public int id { get; set; ***REMOVED***
            public string imePrezime { get; set; ***REMOVED***
            public string email { get; set; ***REMOVED***
            public string razred { get; set; ***REMOVED***
            public string smjer { get; set; ***REMOVED***

    ***REMOVED***
***REMOVED***
***REMOVED***
