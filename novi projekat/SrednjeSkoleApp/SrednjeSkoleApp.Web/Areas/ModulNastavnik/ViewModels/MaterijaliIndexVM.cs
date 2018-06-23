using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels
{
    public class MaterijaliIndexVM
    {
        public List<FileDetails> Files { get; set; ***REMOVED*** = new List<FileDetails>();
        public int predmetId { get; set; ***REMOVED***
        public List<SelectListItem> predmeti;
        public class FileDetails
        {
            public string Name { get; set; ***REMOVED***
            public string BlobName { get; set; ***REMOVED***
    ***REMOVED***       
***REMOVED***
***REMOVED***
