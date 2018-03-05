﻿using System;
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
                rows = _context.Ucenici.Include(q => q.Kontakt).Select(x => new UcenikIndexVM.Row
                {
                    id = x.Id,
                    razred = _context.UceniciRazredi.Where(y => y.UcenikId == x.Id).Include(y => y.Razred).FirstOrDefault().Razred.Oznaka,
                    imePrezime = x.Ime + " " + x.Prezime,
                    email = x.Kontakt.Email,
                    smjer = _context.Ucenici.Where(q => q.Id == x.Id).Include(q => q.Smjer).FirstOrDefault().Smjer.Naziv
            ***REMOVED***).ToList()
        ***REMOVED***;

            return View(model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            var model = new UcenikDodajVM();
            model.Grad = "Mostar";
            model.Prebivaliste = "Mostar, Zalik";
            model.Aktivan = true;
            model.GodinaUpisa = DateTime.Now.Year;
            model.NazivOsnovneSkole = "Osnovna škola \"Zalik\", Mostar";
            model.smjerovi = _context.Smjerovi
                .Select(y => new SelectListItem
                {
                    Value = y.SmjerId.ToString(),
                    Text = y.Naziv
            ***REMOVED***)
                .ToList();
            model.razredi = _context.Razred
                .Select(y => new SelectListItem
                {
                    Value = y.RazredId.ToString(),
                    Text = y.Oznaka
            ***REMOVED***)
                .ToList();

            return View("Dodaj", model);
    ***REMOVED***

        public IActionResult Detalji(int id)
        {
            Ucenik input = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
            var model = new UcenikDodajVM()
            {
                Ime = input.Ime,
                Prezime = input.Prezime,
                KorisnickoIme = input.KorisnickoIme,
                Lozinka = input.Lozinka,
                Aktivan = input.Aktivan,
                Spol = input.Spol,
                DatumRodjenja = input.DatumRodjenja,
                MjestoRodjenja = input.MjestoRodjenja,
                JMBG = input.JMBG,
                Prebivaliste = input.Prebivaliste,

                ImeRoditelja = input.ImeRoditelja,
                GodinaUpisa = input.GodinaUpisa,
                ProsjekOcjenaOsnovnaSkola = input.ProsjekOcjenaOsnovnaSkola,
                NazivOsnovneSkole = input.NazivOsnovneSkole,
                SmjerId = input.SmjerId,
                smjerovi = _context.Smjerovi
                    .Select(y => new SelectListItem
                    {
                        Value = y.SmjerId.ToString(),
                        Text = y.Naziv
                ***REMOVED***)
                    .ToList(),
                RazredId = _context.UceniciRazredi.Where(x => x.UcenikId == input.Id).FirstOrDefault().RazredId,
                razredi = _context.Razred
                    .Select(y => new SelectListItem
                    {
                        Value = y.RazredId.ToString(),
                        Text = y.Oznaka
                ***REMOVED***)
                    .ToList(),

                Email = input.Kontakt.Email,
                Telefon = input.Kontakt.Telefon,
                Adresa = input.Kontakt.Adresa,
                Grad = input.Kontakt.Grad,
                Opstina = input.Kontakt.Opstina
        ***REMOVED***;


            return View("Detalji", model);
    ***REMOVED***


        public IActionResult Snimi(UcenikDodajVM input)
        {
            Ucenik o2 = _context.Ucenici.Where(x => x.Id == input.Id).Include(x => x.Kontakt).Include(x => x.Smjer).FirstOrDefault();
            UcenikRazredi o3 = _context.UceniciRazredi.Where(x => x.UcenikId == input.Id).Include(x => x.Razred).FirstOrDefault();

            if (o2 == null)
            {
                o2 = new Ucenik
                {
                    Kontakt = new KorisnikKontakt(),
                    Smjer = new Smjer()
            ***REMOVED***;
               
                _context.Ucenici.Add(o2);
        ***REMOVED***

            o2.Ime = input.Ime;
            o2.Prezime = input.Prezime;
            o2.KorisnickoIme = input.KorisnickoIme;
            o2.Lozinka = input.Lozinka;
            o2.Aktivan = input.Aktivan;
            o2.Spol = input.Spol;
            o2.DatumRodjenja = input.DatumRodjenja;
            o2.MjestoRodjenja = input.MjestoRodjenja;
            o2.JMBG = input.JMBG;
            o2.Prebivaliste = input.Prebivaliste;

            o2.ImeRoditelja = input.ImeRoditelja;
            o2.GodinaUpisa = input.GodinaUpisa;
            o2.NazivOsnovneSkole = input.NazivOsnovneSkole;
            o2.ProsjekOcjenaOsnovnaSkola = input.ProsjekOcjenaOsnovnaSkola;
            o2.SmjerId = input.SmjerId;

            o2.Kontakt.Email = input.Email;
            o2.Kontakt.Telefon = input.Telefon;
            o2.Kontakt.Adresa = input.Adresa;
            o2.Kontakt.Grad = input.Grad;
            o2.Kontakt.Opstina = input.Opstina;

            _context.SaveChanges();

            if (o3 == null)
            {
                o3 = new UcenikRazredi();
                _context.UceniciRazredi.Add(o3);
        ***REMOVED***
            o3.RazredId = input.RazredId;
            o3.UcenikId = o2.Id;
            o3.RedniBroj = _context.UceniciRazredi.Count(x => x.RazredId == input.RazredId) + 1;

            _context.SaveChanges();


            return RedirectToAction("Index", "Ucenik", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***

        public IActionResult Obrisi(int id)
        {
            Ucenik p1 = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
            UcenikRazredi p2 = _context.UceniciRazredi.FirstOrDefault(x => x.UcenikId == id);
            _context.Ucenici.Remove(p1);
            _context.UceniciRazredi.Remove(p2);
            _context.SaveChanges();
            return RedirectToAction("Index", "Ucenik", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***