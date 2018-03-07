using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    public class RazredController : Controller
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
                    Razrednik = _context.Predaje.Where(y => y.Razrednik && y.RazredId == x.RazredId).Include(y=> y.Nastavnik).FirstOrDefault().Nastavnik.Ime,
                    SkolskaGodina = x.SkolskaGodina.Naziv
            ***REMOVED***).ToList()

        ***REMOVED***;

            return View("Index", model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            var model = new RazredDodajVM()
            {
                //nastavnici = _context.Predaje
                //    .Where(y => !y.Razrednik).Include(y => y.Nastavnik)
                //    .Select(x => new SelectListItem
                //    {
                //        Value = x.NastavnikId.ToString(),
                //        Text = x.Nastavnik.Ime + " " + x.Nastavnik.Prezime
                //***REMOVED***)
                //    .ToList(),
                skolskeGodine = _context.SkolskaGodina
                    .Select(x => new SelectListItem
                    {
                        Value = x.SkolskaGodinaId.ToString(),
                        Text = x.Naziv
                ***REMOVED***)
                    .ToList()
        ***REMOVED***;

            return View("Dodaj", model);
    ***REMOVED***

        public IActionResult Snimi(RazredDodajVM input)
        {

            Razred o1 = _context.Razred.Where(x => x.RazredId == input.id).Include(x => x.SkolskaGodina).FirstOrDefault();
            if (o1 == null)
            {
                o1 = new Razred();
                _context.Razred.Add(o1);
        ***REMOVED***

            o1.Oznaka = input.razredBrojcano + "-" + input.odjeljenje;
            o1.RazredBrojcano = input.razredBrojcano;
            o1.SkolskaGodinaId = input.skolskaGodinaId;
            o1.Odjeljenje = input.odjeljenje;
            _context.SaveChanges();


            return RedirectToAction("Index", "Razred", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***

        public IActionResult Detalji(int id)
        {
            Razred o1 = _context.Razred.Where(x => x.RazredId == id).Include(x => x.SkolskaGodina).FirstOrDefault();

            //int NastavnikId = _context.Predaje.Where(x => x.RazredId == id && x.Razrednik == true)
            //    .Include(y => y.Nastavnik).FirstOrDefault().NastavnikId;

            var model = new RazredDodajVM
            {
                id = id,
                razredBrojcano = o1.RazredBrojcano,
                oznaka = o1.Oznaka,
                odjeljenje = o1.Odjeljenje,
                skolskaGodinaId = o1.SkolskaGodinaId,
                skolskeGodine = _context.SkolskaGodina
                    .Select(x => new SelectListItem
                    {
                        Value = x.SkolskaGodinaId.ToString(),
                        Text = x.Naziv
                ***REMOVED***)
                    .ToList()

            //nastavnici = _context.Predaje
            //    .Where(y => !y.Razrednik).Include(y => y.Nastavnik)
            //    .Select(x => new SelectListItem
            //    {
            //        Value = x.NastavnikId.ToString(),
            //        Text = x.Nastavnik.Ime + " " + x.Nastavnik.Prezime
            //***REMOVED***)
            //    .ToList(),
        ***REMOVED***;


            return View("Detalji", model);
    ***REMOVED***

        public IActionResult Obrisi(int id)
        {
            Razred r1 = _context.Razred.FirstOrDefault(x => x.RazredId == id);
            _context.Razred.Remove(r1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Razred", new { area = "ModulAdministrator" ***REMOVED***);

    ***REMOVED***
      
***REMOVED***
***REMOVED***