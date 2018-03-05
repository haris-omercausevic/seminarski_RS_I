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
                    .ToList()
        ***REMOVED***;

            return View("Dodaj", model);
    ***REMOVED***

        public IActionResult Snimi(SmjerDodajVM input)
        {

            Smjer o1 = _context.Smjerovi.Where(x => x.SmjerId == input.id).Include(x => x.SkolskaGodina).FirstOrDefault();
            if (o1 == null)
            {
                o1 = new Smjer();
                _context.Smjerovi.Add(o1);
        ***REMOVED***

            o1.Naziv = input.Naziv;
            o1.Opis = input.Opis;
            o1.SkolskaGodinaId = input.skolskaGodinaId;
            _context.SaveChanges();


            return RedirectToAction("Index", "Smjer", new { area = "ModulAdministrator" ***REMOVED***);
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
                    .ToList()
        ***REMOVED***;


            return View("Detalji", model);
    ***REMOVED***

        public IActionResult Obrisi(int id)
        {
            Smjer r1 = _context.Smjerovi.FirstOrDefault(x => x.SmjerId == id);
            _context.Smjerovi.Remove(r1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Smjer", new { area = "ModulAdministrator" ***REMOVED***);

    ***REMOVED***
***REMOVED***
***REMOVED***