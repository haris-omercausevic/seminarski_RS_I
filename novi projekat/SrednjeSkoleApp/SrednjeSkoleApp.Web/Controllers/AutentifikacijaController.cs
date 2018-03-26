using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Helper;
using SrednjeSkoleApp.Web.ViewModels;

namespace SrednjeSkoleApp.Web.Controllers
{
    public class AutentifikacijaController : Controller
    {
        private readonly MyContext _context;

        public AutentifikacijaController(MyContext context)
        {
            _context = context;
    ***REMOVED***

        public IActionResult Index()
        {
            return View(new LoginVM()
            {
                ZapamtiPassword = false
        ***REMOVED***);
    ***REMOVED***

        public IActionResult Login(LoginVM input)
        {
            Korisnik korisnik = _context.Korisnici
                .SingleOrDefault(x => x.KorisnickoIme == input.username && MyMvc.GenerateHash(x.LozinkaSalt,input.password) == x.LozinkaHash);

            if (korisnik == null)
            {
                TempData["error_poruka"] = "pogrešan username ili password";
                return View("Index", input);
        ***REMOVED***

            HttpContext.SetLogiraniKorisnik(korisnik, input.ZapamtiPassword);

            List<KorisniciUloge> korisniciUloge = _context.KorisniciUloge.Where(x => x.KorisnikID == korisnik.Id).Include(x => x.Uloga).ToList();
            foreach (var item in korisniciUloge)
            {
                if(item.Uloga.Naziv.Equals("Administrator") || item.Uloga.Naziv.Equals("SuperAdministrator"))
                    return RedirectToAction("Index", "Nastavnik", new {area="ModulAdministrator"***REMOVED***);

                if (item.Uloga.Naziv.Equals("Nastavnik"))
                    return RedirectToAction("Index", "Razred", new { area = "ModulNastavnik" ***REMOVED***);
        ***REMOVED***


            return RedirectToAction("Index", "Home", new {area=""***REMOVED***);
    ***REMOVED***

        public IActionResult Logout()
        {

            return RedirectToAction("Index");
    ***REMOVED***


***REMOVED***
***REMOVED***