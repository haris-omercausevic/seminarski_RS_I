﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulAdministrator.ViewModels;
using SrednjeSkoleApp.Web.Helper;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [Autorizacija(superAdministrator: true,administrator: true, nastavnici: false)]
    public class UcenikController : Controller
    {
        private MyContext _context;
        private IConfiguration _config;

        public UcenikController(MyContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
    ***REMOVED***

        public IActionResult Index()
        {
            var model = new UcenikIndexVM
            {
                rows = _context.Ucenici.Include(q => q.Kontakt).Select(x => new UcenikIndexVM.Row
                {
                    id = x.Id,
                    razred = _context.UceniciRazredi.Where(y => y.UcenikId == x.Id).Include(y => y.Razred).Select(y => y.Razred.Oznaka).FirstOrDefault(),
                    imePrezime = x.Ime + " " + x.Prezime,
                    email = x.Kontakt.Email,
                    smjer = _context.Ucenici.Where(q => q.Id == x.Id).Include(q => q.Smjer).Select(q => q.Smjer.Naziv).SingleOrDefault()
            ***REMOVED***).OrderBy(x => x.razred).ThenBy(x => x.imePrezime).ToList()
        ***REMOVED***;

            return View(model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            var model = new UcenikDodajVM
            {
                Grad = "Mostar",
                Prebivaliste = "Mostar",
                Aktivan = true,
                GodinaUpisa = DateTime.Now.Year,
                NazivOsnovneSkole = "Osnovna škola \"Zalik\", Mostar"
        ***REMOVED***;
            pripremiCmbStavke(model);

            return View("Dodaj", model);
    ***REMOVED***

        private void pripremiCmbStavke(UcenikDodajVM model)
        {
            model.smjerovi = _context.Smjerovi
                .Select(y => new SelectListItem
                {
                    Value = y.SmjerId.ToString(),
                    Text = y.Naziv
            ***REMOVED***)
                .OrderBy(x => x.Text).ToList();
            model.razredi = _context.Razred
                .Select(y => new SelectListItem
                {
                    Value = y.RazredId.ToString(),
                    Text = y.Oznaka
            ***REMOVED***)
                .OrderBy(x => x.Text).ToList();
    ***REMOVED***

        public IActionResult Detalji(int id)
        {
            Ucenik input = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
                var model = new UcenikDetaljiVM()
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

                UcenikRazredi u = _context.UceniciRazredi.FirstOrDefault(x => x.UcenikId == input.Id);
                if (u != null)
                    model.RazredId = u.RazredId;

                //var up = _context.UceniciPredmeti.Where(x => x.UcenikId == input.Id).ToList();
                //zavrsiti pregled detalja za ucenik predmet, znaci prikaz predmeta i ocjena
                // treba dodati za UcenikPredmet, koji nastavnik je dao tu ocjenu odnosno kod koga slusa taj predmet i sl.

                return View("Detalji", model);
    ***REMOVED***


        public IActionResult Snimi(UcenikDodajVM input)
        {
            if (!ModelState.IsValid)
            {
                pripremiCmbStavke(input);
                return View("Dodaj", input);
        ***REMOVED***

            Ucenik o2 = _context.Ucenici.Where(x => x.Id == input.Id).Include(x => x.Kontakt).Include(x => x.Smjer)
                .FirstOrDefault();
            UcenikRazredi o3 = _context.UceniciRazredi.Where(x => x.UcenikId == input.Id).Include(x => x.Razred)
                .FirstOrDefault();


            if (o2 == null)
            {
                o2 = new Ucenik
                {
                    Kontakt = new KorisnikKontakt()
            ***REMOVED***;

                _context.Ucenici.Add(o2);
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

            o2.ImeRoditelja = input.ImeRoditelja;
            o2.GodinaUpisa = input.GodinaUpisa;
            o2.NazivOsnovneSkole = input.NazivOsnovneSkole;
            o2.ProsjekOcjenaOsnovnaSkola = input.ProsjekOcjenaOsnovnaSkola;
            o2.Smjer = _context.Smjerovi.Where(x => x.SmjerId == input.SmjerId).Include(x => x.SkolskaGodina).FirstOrDefault();

            o2.Kontakt.Email = input.Email;
            o2.Kontakt.Telefon = input.Telefon;
            o2.Kontakt.Adresa = input.Adresa;
            o2.Kontakt.Grad = input.Grad;
            o2.Kontakt.Opstina = input.Opstina;

            if (o3 == null)
            {
                o3 = new UcenikRazredi();
                _context.UceniciRazredi.Add(o3);
        ***REMOVED***
            o3.RazredId = input.RazredId;
            o3.UcenikId = o2.Id;
            o3.RedniBroj = _context.UceniciRazredi.Count(x => x.RazredId == input.RazredId) + 1;
            if (o2.Smjer != null)
                o3.SkolskaGodina = o2.Smjer.SkolskaGodina.Naziv;

            _context.SaveChanges();


            string mail = _config["Mail"];
            string mailpass = _config["MailPass"];

            string mailTo = o2.Kontakt.Email;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(mail, mailpass);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(mail);
            mailMessage.To.Add(mailTo);
            mailMessage.Body = $"<h3>Poštovani,</h3>" +
                               $"vaši pristupni podaci su: " +
                               $"<p>Korisničko ime: {input.KorisnickoIme***REMOVED***</p>" +
                               $"<p>Lozinka: {input.Lozinka***REMOVED***</p>" +
                               $"<p>========================</p>" +
                               $"<p>SrednjeSkoleApp</p>";
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "SrednjeSkoleApp";
            client.Send(mailMessage);



            return RedirectToAction("Index", "Ucenik", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***

        public IActionResult Obrisi(int id)
        {
            Ucenik p1 = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
            UcenikRazredi p2 = _context.UceniciRazredi.FirstOrDefault(x => x.UcenikId == id);

            //PROMJENA
            //foreach (var up in _context.UceniciPredmeti.Where(x => x.UcenikId == id))
            //{
            //    foreach (var item in _context.UceniciOcjene.Where(x => x.UcenikPredmetId == up.UcenikPredmetId))
            //    {
            //        _context.Ocjene.Remove(item.Ocjena);
            //        _context.UceniciOcjene.Remove(item);
            //***REMOVED***
            //    _context.UceniciPredmeti.Remove(up);
            //***REMOVED***
            //END-PROMJENA
            //query example
            //SELECT AVG(O.Vrijednost)
            //    FROM UceniciPredmeti AS UP
            //      JOIN UceniciOcjene AS UO ON UP.UcenikPredmetId = UO.UcenikPredmetId
            //      JOIN Ocjene AS O ON UO.OcjenaId = O.OcjenaId
            //WHERE UP.UcenikId = 1

            if (p2 != null)
                _context.UceniciRazredi.Remove(p2);
            if (p1 != null)
                _context.Ucenici.Remove(p1);
            


            _context.SaveChanges();
            return RedirectToAction("Index", "Ucenik", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***

        public IActionResult Trazi(string ime, string prezime, string email)
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
                rows = _context.Ucenici
                    .Include(q => q.Kontakt)
                    .Where(y => (y.Ime.ToLower().Contains(ime) || String.IsNullOrEmpty(ime)) &&
                                (y.Prezime.ToLower().Contains(prezime) || String.IsNullOrEmpty(prezime)) &&
                                (y.Kontakt.Email.ToLower().Contains(email) || String.IsNullOrEmpty(email)))
                    .Select(x => new UcenikIndexVM.Row
                    {
                        id = x.Id,
                        razred = _context.UceniciRazredi.Where(y => y.UcenikId == x.Id).Include(y => y.Razred).Select(y => y.Razred.Oznaka)
                            .FirstOrDefault(),
                        imePrezime = x.Ime + " " + x.Prezime,
                        email = x.Kontakt.Email,
                        smjer = _context.Ucenici.Where(q => q.Id == x.Id).Include(q => q.Smjer).Select(q => q.Smjer.Naziv).FirstOrDefault()
                ***REMOVED***).ToList()
        ***REMOVED***;

            return View("Index", model);
    ***REMOVED***

     
***REMOVED***
***REMOVED***