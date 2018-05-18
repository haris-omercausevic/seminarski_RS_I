using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.Controllers
{
    [Area("ModulNastavnik")]
    [Autorizacija(superAdministrator: true, administrator: false, nastavnici: true)]
    public class UcenikStavkeAjaxController : Controller
    {
        MyContext _context;
        public UcenikStavkeAjaxController(MyContext context)
        {
            _context = context;
    ***REMOVED***
        public IActionResult Index(int id)
        {
            UcenikPredmet up = _context.UceniciPredmeti.Where(x => x.UcenikId == id).Include(x => x.Predmet).Include(x => x.Nastavnik).FirstOrDefault();
            var model = new UcenikStavkeAjaxIndexVM
            {

                Id = id,
                rows = _context.UceniciPredmeti.Where(x => x.UcenikId == id).Include(x => x.Predmet).Include(x => x.Nastavnik).Select(x => new UcenikStavkeAjaxIndexVM.Row
                {
                    Naziv = x.Predmet.Naziv,
                    PredmetId = x.PredmetId,
                    prosjek = _context.UceniciOcjene.Where(y => y.UcenikPredmetId == x.UcenikPredmetId).Include(y => y.Ocjena).Average(a => (int?)a.Ocjena.Vrijednost) ?? 0,
                    ocjene = _context.UceniciOcjene.Where(y => y.UcenikPredmetId == x.UcenikPredmetId).Include(y => y.Ocjena).Select(y => y.Ocjena.Vrijednost).ToString()
            ***REMOVED***).ToList()

                //RazredId = id,
                //rows = _context.UceniciRazredi.Where(o => o.RazredId == id).Include(o => o.Ucenik).Select(x => new UcenikStavkeAjaxIndexVM.Row
                //{
                //    RedniBroj = x.RedniBroj,
                //    Ucenik = x.Ucenik.Ime + x.Ucenik.Prezime,
                //    UcenikRazredId = x.UcenikRazrediId,
                //    UcenikId = x.UcenikId
                //***REMOVED***).OrderBy(x => x.Ucenik).ToList()
        ***REMOVED***;

            return PartialView("Index",model);
    ***REMOVED***
***REMOVED***
***REMOVED***