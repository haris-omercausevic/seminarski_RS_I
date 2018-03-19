using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            return View(new LoginVM());
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

            return RedirectToAction("Index", "Home");
    ***REMOVED***

        public IActionResult Logout()
        {

            return RedirectToAction("Index");
    ***REMOVED***


***REMOVED***
***REMOVED***