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
using SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels;
using SrednjeSkoleApp.Web.Helper;
using UcenikDetaljiVM = SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels.UcenikDetaljiVM;
using UcenikIndexVM = SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels.UcenikIndexVM;


namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.Controllers
{
    [Area("ModulNastavnik")]
    [Autorizacija(superAdministrator: true, administrator: false, nastavnici: true)]
    public class UcenikController : Controller
    {
        private MyContext _context;

        public UcenikController(MyContext context)
        {
            _context = context;
    ***REMOVED***

        public IActionResult Index()
        {
            var model = new UcenikIndexVM
            {
                rows = _context.Ucenici.Include(q => q.Kontakt).Include(q => q.Smjer).Select(x => new UcenikIndexVM.Row
                {
                    id = x.Id,
                    imePrezime = x.Ime + " " + x.Prezime,
                    email = x.Kontakt.Email,
                    razred = _context.UceniciRazredi.Where(y => y.UcenikId == x.Id).Include(y => y.Razred).Select(y => y.Razred.Oznaka).FirstOrDefault(),
                    smjer = x.Smjer.Naziv
            ***REMOVED***).OrderBy(x => x.razred).ThenBy(x => x.imePrezime).ToList(),
                razredi = _context.Razred.Select(x => new SelectListItem
                    {
                        Value = x.RazredId.ToString(),
                        Text = x.Oznaka
                ***REMOVED***
                ).ToList(),
                smjerovi = _context.Smjerovi.Select(x => new SelectListItem
                    {
                        Value = x.SmjerId.ToString(),
                        Text = x.Naziv
                ***REMOVED***
                ).ToList()
        ***REMOVED***;

            return View(model);
    ***REMOVED***
        
        public IActionResult Detalji(int id)
        {
            Ucenik input = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).Include(x => x.Smjer).FirstOrDefault();
            UcenikRazredi ucenikRazredi = _context.UceniciRazredi.Where(x => x.UcenikId == input.Id).Include(x => x.Razred).FirstOrDefault();

                var model = new UcenikDetaljiVM()
                {
                    imePrezime = input.Ime + " " + input.Prezime,
                    smjer = input.Smjer.Naziv,
                    razred = ucenikRazredi.Razred.Oznaka,
                    brojUDnevniku = ucenikRazredi.RedniBroj,
                    email = input.Kontakt.Email,
            ***REMOVED***;

            return View("Detalji", model);
    ***REMOVED***


        public IActionResult Trazi(string ime, string prezime, string email, int smjerId, int razredId)
        {
            if (!String.IsNullOrEmpty(ime))
                ime = ime.ToLower();
            if (!String.IsNullOrEmpty(prezime))
                prezime = prezime.ToLower();
            if (!String.IsNullOrEmpty(email))
                email = email.ToLower();

            ViewData["imeFilter"] = ime;
            ViewData["prezimeFilter"] = prezime;
            ViewData["emailFilter"] = email;



            var model = new UcenikIndexVM
            {
                razredi = _context.Razred.Select(x => new SelectListItem
                    {
                        Value = x.RazredId.ToString(),
                        Text = x.Oznaka
                ***REMOVED***
                ).ToList(),
                smjerovi = _context.Smjerovi.Select(x => new SelectListItem
                    {
                        Value = x.SmjerId.ToString(),
                        Text = x.Naziv
                ***REMOVED***
                ).ToList(),
                rows = _context.Ucenici
                    .Include(q => q.Kontakt).Include(q => q.Smjer)
                    .Where(y => (y.Ime.ToLower().Contains(ime) || String.IsNullOrEmpty(ime)) &&
                                (y.Prezime.ToLower().Contains(prezime) || String.IsNullOrEmpty(prezime)) &&
                                (y.Kontakt.Email.ToLower().Contains(email) || String.IsNullOrEmpty(email)))
                    .Select(x => new UcenikIndexVM.Row
                    {
                        id = x.Id,
                        imePrezime = x.Ime + " " + x.Prezime,
                        email = x.Kontakt.Email,
                        razred = _context.UceniciRazredi.Where(y => y.UcenikId == x.Id).Include(y => y.Razred).Select(y => y.Razred.Oznaka).SingleOrDefault(),
                        smjer = x.Smjer.Naziv
                ***REMOVED***).OrderBy(x => x.razred).ThenBy(x => x.imePrezime).ToList()
        ***REMOVED***;

            Smjer smjer = _context.Smjerovi.FirstOrDefault(y => y.SmjerId == smjerId);
            if (smjer != null)
            {
                for (int i = model.rows.Count - 1; i >= 0; i--)
                {
                    if (model.rows[i].smjer != smjer.Naziv)
                        model.rows.RemoveAt(i);
            ***REMOVED***
        ***REMOVED***
            Razred razred = _context.Razred.FirstOrDefault(y => y.RazredId == razredId);
            if (razred != null)
            {
                for (int i = model.rows.Count - 1; i >= 0; i--)
                {
                    if (model.rows[i].razred != razred.Oznaka)
                        model.rows.RemoveAt(i);
            ***REMOVED***
        ***REMOVED***

            return View("Index", model);
    ***REMOVED***

        public IActionResult Obrisi(int id)
        {
            Ucenik p1 = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
            UcenikRazredi p2 = _context.UceniciRazredi.FirstOrDefault(x => x.UcenikId == id);

            foreach (var up in _context.UceniciPredmeti.Where(x => x.UcenikId == id))
            {
                foreach (var item in _context.Ocjene.Where(x => x.UcenikPredmetId == up.UcenikPredmetId).ToList())
                {
                    _context.Ocjene.Remove(item);
            ***REMOVED***
                _context.UceniciPredmeti.Remove(up);
        ***REMOVED***
            if (p2 != null)
                _context.UceniciRazredi.Remove(p2);
            if (p1 != null)
                _context.Ucenici.Remove(p1);



            _context.SaveChanges();
            return RedirectToAction("Index", "Ucenik", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***

***REMOVED***
***REMOVED***