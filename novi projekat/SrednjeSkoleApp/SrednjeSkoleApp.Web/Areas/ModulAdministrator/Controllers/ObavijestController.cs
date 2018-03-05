using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    public class ObavijestController : Controller
    {
        private MyContext _context;

        public ObavijestController(MyContext context)
        {
            _context = context;
    ***REMOVED***
        public IActionResult Index()
        {
            return View();
    ***REMOVED***

        public IActionResult Dodaj()
        {
            Obavijest t = new Obavijest
            {
        ***REMOVED***;
            return View();
    ***REMOVED***
        
***REMOVED***
***REMOVED***