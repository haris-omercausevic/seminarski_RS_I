using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [Autorizacija(superAdministrator: true,administrator: true, nastavnici: false)]
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
                rows = _context.Razred.Include(x => x.Razrednik).Include(x => x.Smjer).Select(x => new RazredIndexVM.Row
                {
                    RazredId = x.RazredId,
                    Razred = x.Oznaka,
                    SkolskaGodina = x.SkolskaGodina.Naziv,
                    Razrednik = x.Razrednik.Ime + " " + x.Razrednik.Prezime,
                    Smjer = x.Smjer.Naziv
            ***REMOVED***).ToList()

        ***REMOVED***;

            return View("Index", model);
    ***REMOVED***

        public IActionResult Dodaj()
        {

            var model = new RazredDodajVM()
            {
                nastavnici = _context.Nastavnici
                                .Select(x => new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Ime + " " + x.Prezime
                            ***REMOVED***)
                    .ToList(),
                skolskeGodine = _context.SkolskaGodina
                    .Select(x => new SelectListItem
                    {
                        Value = x.SkolskaGodinaId.ToString(),
                        Text = x.Naziv
                ***REMOVED***)
                    .ToList(),
                 smjerovi = _context.Smjerovi.Select(x => new SelectListItem
                 {
                     Value = x.SmjerId.ToString(),
                     Text = x.Naziv
             ***REMOVED***).ToList()
                
        ***REMOVED***;

            return View("Dodaj", model);
    ***REMOVED***
       

        public IActionResult Detalji(int id)
        {
            Razred o1 = _context.Razred.Where(x => x.RazredId == id).Include(x => x.Razrednik).Include(x => x.SkolskaGodina).FirstOrDefault();
            var model = new RazredDetaljiVM
            {
                id = id,
                razredBrojcano = o1.RazredBrojcano,
                oznaka = o1.Oznaka,
                odjeljenje = o1.Odjeljenje,
                skolskaGodina = o1.SkolskaGodina.Naziv,
                nastavnik = o1.Razrednik.Ime + " " + o1.Razrednik.Prezime
        ***REMOVED***;


            return View("Detalji", model);
    ***REMOVED***

        public IActionResult Snimi(RazredDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                input.skolskeGodine = _context.SkolskaGodina
                   .Select(x => new SelectListItem
                   {
                       Value = x.SkolskaGodinaId.ToString(),
                       Text = x.Naziv
               ***REMOVED***)
                   .ToList();
                               
                //PROMJENA
                input.nastavnici = _context.Nastavnici                                
                                .Select(x => new SelectListItem
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Ime + " " + x.Prezime
                            ***REMOVED***)
                    .ToList();
                //END-PROMJENA


                        return View("Dodaj", input);
        ***REMOVED***


            Razred o1 = _context.Razred.Where(x => x.RazredId == input.id).Include(x => x.SkolskaGodina).FirstOrDefault();
            if (o1 == null)
            {
                o1 = new Razred();
        ***REMOVED***
            _context.Razred.Add(o1);
            o1.Oznaka = input.razredBrojcano + "-" + input.odjeljenje;
            o1.RazredBrojcano = input.razredBrojcano;
            o1.SkolskaGodinaId = input.skolskaGodinaId;
            o1.Odjeljenje = input.odjeljenje;
            o1.RazrednikId = input.nastavnikId;
            o1.SmjerId = input.smjerId;
            
            _context.SaveChanges();


            return RedirectToAction("Index", "Razred", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***
        
        public IActionResult Obrisi(int id)
        {
            Razred r1 = _context.Razred.FirstOrDefault(x => x.RazredId == id);

            foreach (var item in _context.UceniciRazredi.Where(x => x.RazredId == id).ToList())
            {
                _context.UceniciRazredi.Remove(item);
        ***REMOVED***
            _context.Razred.Remove(r1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Razred", new { area = "ModulAdministrator" ***REMOVED***);

    ***REMOVED***

***REMOVED***
***REMOVED***