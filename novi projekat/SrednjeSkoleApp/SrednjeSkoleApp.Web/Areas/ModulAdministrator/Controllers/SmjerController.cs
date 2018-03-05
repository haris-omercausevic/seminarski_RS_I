using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    public class SmjerController : Controller
    {
        private MyContext _context;

        public SmjerController(MyContext context)
        {
            _context = context;
    ***REMOVED***

        public IActionResult Index()
        {
            var model = new SmjerIndexVM
            {
                rows = _context.Smjerovi.Select(x => new SmjerIndexVM.Row
                {
                    SmjerId = x.SmjerId,
                    Naziv = x.Naziv,
                    Opis = x.Opis,
                    SkolskaGodina = x.SkolskaGodina.Naziv
            ***REMOVED***).ToList()

        ***REMOVED***;

            return View("Index", model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            var model = new SmjerDodajVM()
            {
                skolskeGodine = _context.SkolskaGodina
                    .Select(x => new SelectListItem
                    {
                        Value = x.SkolskaGodinaId.ToString(),
                        Text = x.Naziv
                ***REMOVED***)
                    .ToList(),
                predmeti = _context.Predmet
                    .Select(x => new CheckBoxVM
                    {
                        Id = x.PredmetId,
                        Name = x.Naziv,
                        Selected = false
                ***REMOVED***)
                    .ToList()
        ***REMOVED***;

            return View("Dodaj", model);
    ***REMOVED***

      public IActionResult Detalji(int id)
        {
            Smjer o1 = _context.Smjerovi.Where(x => x.SmjerId == id).Include(x => x.SkolskaGodina).FirstOrDefault();

            var model = new SmjerDodajVM
            {
                Naziv = o1.Naziv,
                Opis = o1.Opis,
                skolskaGodinaId = o1.SkolskaGodinaId,
                skolskeGodine = _context.SkolskaGodina
                    .Select(x => new SelectListItem
                    {
                        Value = x.SkolskaGodinaId.ToString(),
                        Text = x.Naziv
                ***REMOVED***)
                    .ToList(),
                predmeti = _context.PredmetiNaSmjeru.Where(x => x.SmjerId == id).Include(x => x.Predmet)
                    .Select(x => new CheckBoxVM
                    {
                        Id = x.PredmetId,
                        Name = x.Predmet.Naziv,
                        Selected = true
                ***REMOVED***)
                    .ToList()
        ***REMOVED***;


            return View("Detalji", model);
    ***REMOVED***
        public IActionResult Snimi(SmjerDodajVM input)
        {
            Smjer o1 = _context.Smjerovi.Where(x => x.SmjerId == input.id).Include(x => x.SkolskaGodina).FirstOrDefault();
            if (o1 == null) // ako se dodaje novi smjer
            {
                o1 = new Smjer();
                _context.Smjerovi.Add(o1);

                foreach (var item in input.predmeti)
                {
                    if (item.Selected)
                    {
                        _context.PredmetiNaSmjeru.Add(new PredmetiNaSmjeru
                        {
                            PredmetId = item.Id,
                            SmjerId = o1.SmjerId
                    ***REMOVED***);
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***

            o1.Naziv = input.Naziv;
            o1.Opis = input.Opis;
            o1.SkolskaGodinaId = input.skolskaGodinaId;


            _context.SaveChanges();


            return RedirectToAction("Index", "Smjer", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***
        public IActionResult Obrisi(int id)
        {
            Smjer r1 = _context.Smjerovi.FirstOrDefault(x => x.SmjerId == id);
            foreach (PredmetiNaSmjeru item in _context.PredmetiNaSmjeru.Where(x => x.SmjerId == id).ToList())
            {
                _context.PredmetiNaSmjeru.Remove(item);
        ***REMOVED***
            _context.Smjerovi.Remove(r1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Smjer", new { area = "ModulAdministrator" ***REMOVED***);

    ***REMOVED***
***REMOVED***
***REMOVED***