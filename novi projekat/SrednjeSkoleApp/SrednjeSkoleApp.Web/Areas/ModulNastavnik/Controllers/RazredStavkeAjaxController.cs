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

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.Controllers
{
    [Area("ModulNastavnik")]
    [Autorizacija(superAdministrator: true, administrator: true, nastavnici: true)]
    public class RazredStavkeAjaxController : Controller
    {
        MyContext _context;
        public RazredStavkeAjaxController(MyContext context)
        {
            _context = context;
    ***REMOVED***
        public IActionResult Index(int id)
        {
            var model = new RazredStavkeAjaxIndexVM
            {
                RazredId = id,
                //ProsjecnaOcjena = _context.UceniciPredmeti
                //        .Where(g =>
                //            _context.UceniciRazredi.Where(u => u.RazredId == id).Select(q => q.UcenikId).Contains(g.UcenikId))
                //        .Where(y => y.u)
                //        .Average(u => u.ZakljucnaOcjena)
                rows = _context.UceniciRazredi.Where(o => o.RazredId == id).Include(o => o.Ucenik).Select(x => new RazredStavkeAjaxIndexVM.Row
                {
                    RedniBroj = x.RedniBroj,
                    Ucenik = x.Ucenik.Ime + " " + x.Ucenik.Prezime,
                    UcenikRazredId = x.UcenikRazrediId,
                    UcenikId = x.UcenikId,
                    //ProsjecnaOcjena = _context.UceniciPredmeti.Where(y => y.UcenikId == x.UcenikId).Average(a => (int?)a.ZakljucnaOcjena) ?? 0
            ***REMOVED***).OrderBy(x => x.Ucenik).ToList()
        ***REMOVED***;


            return PartialView("Index", model);
    ***REMOVED***

        //NIJE ZAPOCETO
        //public IActionResult Uredi(int id)
        //{

        //    UcenikRazredi x = _context.UceniciRazredi.Where(y => y.UcenikRazrediId == id).Include(y => y.Ucenik).FirstOrDefault();

        //    RazredStavkeAjaxDodajVM model = new RazredStavkeAjaxDodajVM
        //    {
        //        RedniBroj = x.RedniBroj,
        //        RazredId = x.RazredId,
        //        UcenikRazredId = id,
        //        UcenikId = x.UcenikId,
        //        ucenici = _context.Ucenici.Select(w => new SelectListItem
        //        {
        //            Value = w.Id.ToString(),
        //            Text = w.Ime + " " + w.Prezime
        //    ***REMOVED***).ToList()
        //***REMOVED***;

        //    return PartialView("Dodaj", model);
        //***REMOVED***

        //public IActionResult Dodaj(int ucenikId, int nastavnikId, int razredId)
        //{
        //    //PROMJENA
        //    RazredStavkeAjaxDodajVM model = new RazredStavkeAjaxDodajVM
        //    {
        //        datum = DateTime.Now,
        //        ucenikId = ucenikId,
        //        nastavnikId = nastavnikId                
        //        //predmeti = _context.Predaje.Where(x => x.NastavnikId == nastavnikId).Include(x => x.SmjerPredmet).ThenInclude(x => x.Predmet).Select(x => new SelectListItem
        //        //{
        //        //    Value = x.SmjerPredmet.Predmet.PredmetId.ToString(),
        //        //    Text = x.SmjerPredmet.Predmet.Naziv
        //        //***REMOVED***).ToList()
        //***REMOVED***;

        //    return PartialView("Dodaj", model);
        //***REMOVED***

        //public IActionResult Snimi(int razredId, int ucenikId)
        //{
        //    //PROMJENA
        //    //_context.UceniciPredmeti.Add(new UcenikPredmet
        //    //{
        //        //RazredId = razredId,
        //        //UcenikId = ucenikId,
        //        //RedniBroj = 0,
        //        //SkolskaGodina = _context.Razred.Where(x => x.RazredId == razredId).Include(x => x.SkolskaGodina).FirstOrDefault()?.SkolskaGodina.Naziv
        //    //***REMOVED***);
        //    //END-PROMJENA
        //    //poredaj po prezimenu (broj u dnevniku)
        //    int brojac = 1;
        //    foreach (var item in _context.UceniciRazredi.Where(x => x.RazredId == razredId).Include(x => x.Ucenik).OrderBy(x => x.Ucenik.Prezime).ToList())
        //    {
        //        item.RedniBroj = brojac++;
        //        _context.Update(item);
        //***REMOVED***

        //    _context.SaveChanges();

        //    return Redirect("/ModulNastavnik/RazredStavkeAjax/Index?id=" + razredId);
        //***REMOVED***
***REMOVED***


***REMOVED***