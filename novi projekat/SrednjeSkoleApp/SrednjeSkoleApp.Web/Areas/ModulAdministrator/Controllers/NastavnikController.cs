using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels;
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    public class NastavnikController : Controller
    {
        private MyContext _context;

        public NastavnikController(MyContext context)
        {
            _context = context;
    ***REMOVED***

        public IActionResult Index() 
        {
            var model = new NastavnikIndexVM

            {
                rows = _context.Nastavnici.Select(x => new NastavnikIndexVM.Row
                {
                    id = x.Id,
                    naucnaOblast = x.NaucnaOblast,
                    imePrezime = x.Ime + " " + x.Prezime,
                    email = x.Kontakt.Email
            ***REMOVED***).ToList()
        ***REMOVED***;

            return View(model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            var model = new NastavnikDodajVM();
            model.Grad = "Mostar";
            model.Prebivaliste = "Mostar, Zalik";
            model.Aktivan = true;

            return View("Dodaj",model);
    ***REMOVED***

        public IActionResult Detalji(int id)
        {
            Nastavnik input = _context.Nastavnici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
            var model = new NastavnikDodajVM()
            {
                Ime = input.Ime,
                Prezime = input.Prezime,
                KorisnickoIme = input.KorisnickoIme,
                Aktivan = input.Aktivan,
                Spol = input.Spol,
                DatumRodjenja = input.DatumRodjenja,
                MjestoRodjenja = input.MjestoRodjenja,
                JMBG = input.JMBG,
                Prebivaliste = input.Prebivaliste,
                Zvanje = input.Zvanje,
                DatumIzboraUZvanje = input.DatumIzboraUZvanje,
                NaucnaOblast = input.NaucnaOblast,
                GodinaZaposlenja = input.GodinaZaposlenja,
                Email = input.Kontakt.Email,
                Telefon = input.Kontakt.Telefon,
                Adresa = input.Kontakt.Adresa,
                Grad = input.Kontakt.Grad,
                Opstina = input.Kontakt.Opstina
        ***REMOVED***;
            

            return View("Detalji", model);
    ***REMOVED***


        public IActionResult Snimi(NastavnikDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                return View("Dodaj",input);
        ***REMOVED***

            Nastavnik o2 = _context.Nastavnici.Where(x => x.Id == input.Id).Include(x => x.Kontakt).FirstOrDefault();

            if (o2 == null)
            {
                o2 = new Nastavnik
                {
                    Kontakt = new KorisnikKontakt()
            ***REMOVED***;
                _context.Nastavnici.Add(o2);
        ***REMOVED***
            
            o2.Ime = input.Ime;
            o2.Prezime = input.Prezime;
            o2.KorisnickoIme = input.KorisnickoIme;

            o2.LozinkaSalt = MyMvc.GenerateSalt();
            o2.LozinkaHash = MyMvc.GenerateHash(o2.LozinkaSalt, input.Lozinka);

            o2.Aktivan = input.Aktivan;
            o2.Spol = input.Spol;
            o2.DatumRodjenja = input.DatumRodjenja;
            o2.MjestoRodjenja = input.MjestoRodjenja;
            o2.JMBG = input.JMBG;
            o2.Prebivaliste = input.Prebivaliste;

            o2.Zvanje = input.Zvanje;
            o2.DatumIzboraUZvanje = input.DatumIzboraUZvanje;
            o2.NaucnaOblast = input.NaucnaOblast;
            o2.GodinaZaposlenja = input.GodinaZaposlenja;

            o2.Kontakt.Email = input.Email;
            o2.Kontakt.Telefon = input.Telefon;
            o2.Kontakt.Adresa = input.Adresa;
            o2.Kontakt.Grad = input.Grad;
            o2.Kontakt.Opstina = input.Opstina;

            _context.SaveChanges();
            

            return RedirectToAction("Index", "Nastavnik", new {area ="ModulAdministrator"***REMOVED***);
    ***REMOVED***

        public IActionResult Obrisi(int id)
        {
            Nastavnik p1 = _context.Nastavnici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
            _context.Nastavnici.Remove(p1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Nastavnik", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***

***REMOVED***
***REMOVED***