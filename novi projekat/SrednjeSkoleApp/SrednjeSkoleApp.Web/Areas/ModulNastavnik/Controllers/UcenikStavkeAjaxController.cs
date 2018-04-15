using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.Controllers
{
    public class UcenikStavkeAjaxController : Controller
    {
        [Area("ModulNastavnik")]
        [Autorizacija(superAdministrator: true, administrator: false, nastavnici: true)]

        public IActionResult Index(int id)
        {
            return View();
    ***REMOVED***
***REMOVED***
***REMOVED***