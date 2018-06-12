using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Helper;
using SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels;

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
                rows = _context.Razred.Select(x => new RazredIndexVM.Row
                {
                    RazredId = x.RazredId,
                    Razred = x.Oznaka,
                    Razrednik = x.Razrednik.Ime + " " +x.Razrednik.Prezime, 
                    SkolskaGodina = x.SkolskaGodina.Naziv
            ***REMOVED***).OrderBy(x => x.Razred).ToList()

        ***REMOVED***;

            return View("Index", model);
    ***REMOVED***

        public IActionResult Detalji(int id)
        {
            Razred o1 = _context.Razred.Where(x => x.RazredId == id).Include(x => x.Razrednik).Include(x => x.SkolskaGodina).FirstOrDefault();
            var model = new RazredDetaljiVM()
            {
                id = o1.RazredId,
                oznaka = o1.Oznaka,
                skolskaGodina = o1.SkolskaGodina.Naziv,
                razrednik = o1.Razrednik.Ime + " " + o1.Razrednik.Prezime
        ***REMOVED***;

            return View("Detalji", model);
    ***REMOVED***

***REMOVED***
***REMOVED***
