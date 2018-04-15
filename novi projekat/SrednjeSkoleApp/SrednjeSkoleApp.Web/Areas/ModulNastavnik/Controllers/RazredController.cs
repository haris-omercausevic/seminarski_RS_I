using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.Controllers
{
    [Area("ModulNastavnik")]
    [Autorizacija(superAdministrator: true, administrator: false, nastavnici: true)]
    public class RazredController:Controller
    {
        private MyContext _context;
        public RazredController(MyContext context)
        {
            _context = context;
    ***REMOVED***

        public IActionResult Index()
        {
            var model = new RazredIndexVM
            {
                rows = _context.Predaje.Where(y => y.Razrednik == true).Select(x => new RazredIndexVM.Row
                {
                    RazredId = x.RazredId,
                    Razred = x.Razred.Oznaka,
                    Razrednik = x.Nastavnik.Ime + x.Nastavnik.Prezime, 
                    SkolskaGodina = x.SkolskaGodina.Naziv
            ***REMOVED***).ToList()

        ***REMOVED***;

            return View("Index", model);
    ***REMOVED***

        
***REMOVED***
***REMOVED***
