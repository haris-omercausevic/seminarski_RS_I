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
    public class ObavijestController : Controller
    {
        MyContext _context;
        public ObavijestController(MyContext context)
        {
            _context = context;
    ***REMOVED***
        //http://haneefputtur.com/wysiwyg-bootstrap-asp-net-mvc-image-upload-feature.html
        //https://summernote.org/getting-started/#integration
        public IActionResult Index()
        {
            var model = new ObavijestIndexVM()
            {
                rows = _context.Obavijesti.Include(x => x.Korisnik).Select(x => new ObavijestIndexVM.Row
                {
                    KorisnikId = x.KorisnikId,
                    Korisnik = x.Korisnik.Ime + " " + x.Korisnik.Prezime,
                    Naslov = x.Naslov,
                    ObavijestId = x.ObavijestId,
                    Tekst = x.Tekst,
                    Datum = x.Datum
            ***REMOVED***).ToList()
        ***REMOVED***;
            return View(model);
    ***REMOVED***
        public IActionResult Dodaj()
        {
            var model = new ObavijestDodajVM()
            {
                Datum = DateTime.Now
        ***REMOVED***;
            
            return View(model);
    ***REMOVED***

        public IActionResult Snimi(ObavijestDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("Dodaj", input);
        ***REMOVED***

            _context.Obavijesti.Add(new Obavijest
            {
                KorisnikId = input.KorisnikId,
                Naslov = input.Naslov,
                Tekst = input.Tekst
        ***REMOVED***);
            _context.SaveChanges();

            return RedirectToAction("Index", "Obavijest", new { area = "ModulNastavnik" ***REMOVED***);
    ***REMOVED***

        public IActionResult Obrisi(int id)
        {
            Obavijest p1 = _context.Obavijesti.Where(x => x.ObavijestId == id).Include(x => x.Korisnik).FirstOrDefault();
            if (p1 != null)
                _context.Obavijesti.Remove(p1);


            _context.SaveChanges();
            return RedirectToAction("Index", "Obavijest", new { area = "ModulNastavnik" ***REMOVED***);
    ***REMOVED***
               
***REMOVED***

***REMOVED***
