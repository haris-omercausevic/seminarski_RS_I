using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.Controllers
{
    public class MaterijaliController : Controller
    {

        public IActionResult Index()
        {
            return View();

    ***REMOVED***

        public IActionResult Upload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formFile.CopyToAsync(stream);
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***


            return View();
    ***REMOVED***


***REMOVED***
***REMOVED***