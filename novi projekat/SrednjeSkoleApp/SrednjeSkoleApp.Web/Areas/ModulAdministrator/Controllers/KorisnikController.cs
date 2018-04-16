using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
    //[Autorizacija(superAdministrator:true,administrator: true,nastavnici: false)]
    public class KorisnikController : Controller
    {
        private MyContext _context;

        public KorisnikController(MyContext context)
        {
            _context = context;
    ***REMOVED***

        public IActionResult Index()
        {
            KorisnikIndexVM model = new KorisnikIndexVM()
            {
                uloge = _context.Uloge.Select(x => new SelectListItem
                {
                    Value = x.UlogaId.ToString(),
                    Text = x.Naziv
            ***REMOVED***
                ).ToList(),
                rows = _context.Korisnici.Include(q => q.Kontakt).Select(x => new KorisnikIndexVM.Row
                {
                    id = x.Id,
                    imePrezime = x.Ime + " " + x.Prezime,
                    email = x.Kontakt.Email,
                    uloga = _context.KorisniciUloge.Where(q => q.KorisnikID == x.Id).Include(q => q.Uloga).Select(q => q.Uloga.Naziv).SingleOrDefault()
            ***REMOVED***).ToList()
        ***REMOVED***;

            return View(model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            var model = new KorisnikDodajVM
            {
                uloge = _context.Uloge.Select(x => new RoleVm
                {
                    Id = x.UlogaId,
                    Naziv = x.Naziv
            ***REMOVED***).ToList()
        ***REMOVED***;

            return View(model);
    ***REMOVED***
        public IActionResult Snimi(KorisnikDodajVM input)
        {
            Korisnik k = new Korisnik
            {
                Ime = input.Ime,
                Prezime = input.Prezime,
                KorisnickoIme = input.KorisnickoIme
        ***REMOVED***;
            k.LozinkaSalt = MyMvc.GenerateSalt();
            k.LozinkaHash = MyMvc.GenerateHash(k.LozinkaSalt, input.Lozinka);

            _context.Korisnici.Add(k);
            _context.KorisniciUloge.Add(new KorisniciUloge
            {
                KorisnikID = k.Id,
                UlogaID = input.SelectedUloga
        ***REMOVED***);


            _context.SaveChanges();

            return RedirectToAction("Index");
    ***REMOVED***

        //testirati, napravit view, obratiti paznju na ulogaId jel dobija vrijednost sa viewa
        public IActionResult Trazi(string ime, string prezime, string email, int ulogaId)
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



            var model = new KorisnikIndexVM
            {
                uloge = _context.Uloge.Select(x => new SelectListItem
                {
                    Value = x.UlogaId.ToString(),
                    Text = x.Naziv
            ***REMOVED***
                ).ToList(),
                rows = _context.Korisnici
                    .Include(q => q.Kontakt)
                    .Where(y => (y.Ime.ToLower().Contains(ime) || String.IsNullOrEmpty(ime)) &&
                                (y.Prezime.ToLower().Contains(prezime) || String.IsNullOrEmpty(prezime)) &&
                                (y.Kontakt.Email.ToLower().Contains(email) || String.IsNullOrEmpty(email)))
                    .Select(x => new KorisnikIndexVM.Row
                    {
                        id = x.Id,
                        imePrezime = x.Ime + " " + x.Prezime,
                        email = x.Kontakt.Email,
                        uloga = _context.KorisniciUloge.Where(y => y.KorisnikID == x.Id).Select(y => y.Uloga.Naziv).SingleOrDefault()
                ***REMOVED***).ToList()
        ***REMOVED***;

            Uloga uloga = _context.Uloge.FirstOrDefault(y => y.UlogaId == ulogaId);
            if (uloga != null)
            {
                for (int i = model.rows.Count - 1; i >= 0; i--)
                {
                    if (model.rows[i].uloga != uloga.Naziv)
                        model.rows.RemoveAt(i);
            ***REMOVED***
        ***REMOVED***


            return View("Index", model);
    ***REMOVED***

        public IActionResult ProvjeriKorisnickoIme(string korisnickoIme)
        {
            if (_context.Korisnici.Any(x => x.KorisnickoIme == korisnickoIme))
                return Json($"Korisnicko ime {korisnickoIme***REMOVED*** je zauzeto.");

            return Json(true);
    ***REMOVED***
***REMOVED***
***REMOVED***