using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels;
using SrednjeSkoleApp.Web.Helper;
//using UcenikDetaljiVM = SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels.UcenikDetaljiVM;
//using UcenikIndexVM = SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels.UcenikIndexVM;


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

        //public IActionResult Obrisi(int id)
        //{
        //    Ucenik p1 = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
        //    UcenikRazredi p2 = _context.UceniciRazredi.FirstOrDefault(x => x.UcenikId == id);

        //    //PROMJENA
        //    //foreach (var up in _context.UceniciPredmeti.Where(x => x.UcenikId == id))
        //    //{
        //    //    foreach (var item in _context.UceniciOcjene.Where(x => x.UcenikPredmetId == up.UcenikPredmetId))
        //    //    {
        //    //        _context.Ocjene.Remove(item.Ocjena);
        //    //        _context.UceniciOcjene.Remove(item);
        //    //***REMOVED***
        //    //    _context.UceniciPredmeti.Remove(up);
        //    //***REMOVED***
        //    //END-PROMJENA

        //    if (p2 != null)
        //        _context.UceniciRazredi.Remove(p2);
        //    if (p1 != null)
        //        _context.Ucenici.Remove(p1);

        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Ucenik", new { area = "ModulAdministrator" ***REMOVED***);
        //***REMOVED***

        //public IActionResult Dodaj(int id, int nastavnikId) //ucenik id, nastavnikId preuzeti iz konteksta
        //{

        //    Ucenik u = _context.Ucenici.Where(x => x.Id == id).Include(x => x.Kontakt).FirstOrDefault();
        //    //PROMJENA
        //    var model = new UcenikDodajVM();
        //    //var model = new UcenikDodajVM()
        //    //{
        //    //    Datum = DateTime.Now,
        //    //    ImePrezime = u.Ime + " " + u.Prezime,
        //    //    Razred = _context.UceniciRazredi.Where(x => x.UcenikId == id).Include(x => x.Razred).Select(x => x.Razred.Oznaka).ToString(),
        //    //    predmeti = _context.UceniciPredmeti.Where(x => x.UcenikId == id && x.NastavnikId == nastavnikId)
        //    //    .Include(x => x.Predmet).Select(x => new SelectListItem
        //    //    {
        //    //        Value = x.PredmetId.ToString(),
        //    //        Text = x.Predmet.Naziv
        //    //***REMOVED***).ToList(),
        //    //    PredmetId = 0
        //    //***REMOVED***;
        //    //END PROMJENA
        //    return View(model);
        //***REMOVED***

        //public IActionResult Snimi(UcenikDodajVM input)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View("Dodaj", input);
        //***REMOVED***
        //    //PROMJENA
        //    //UcenikPredmet up = _context.UceniciPredmeti.Where(x => x.NastavnikId == input.Id && x.PredmetId == input.PredmetId && x.UcenikId == input.Id).FirstOrDefault();
        //    //if (up != null)
        //    //{
        //    //    UcenikOcjene uo = new UcenikOcjene()
        //    //    {
        //    //        UcenikPredmetId = up.UcenikPredmetId,
        //    //        Ocjena = new Ocjena()
        //    //        {
        //    //            Datum = input.Datum,
        //    //            Napomena = input.Napomena,
        //    //            TipOcjene = input.TipOcjene,
        //    //            Vrijednost = input.Vrijednost
        //    //    ***REMOVED***
        //    //***REMOVED***;
        //    //END-PROMJENA

        //    //    _context.Ocjene.Add(uo.Ocjena);
        //    //    //_context.UceniciOcjene.Add(uo);

        //        _context.SaveChanges();

        //    return RedirectToAction("Index", "Ucenik", new { area = "ModulNastavnik" ***REMOVED***);
        //***REMOVED***
***REMOVED***
***REMOVED***