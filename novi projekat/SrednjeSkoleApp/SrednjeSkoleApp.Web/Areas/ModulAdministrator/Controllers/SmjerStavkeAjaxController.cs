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

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    public class SmjerStavkeAjaxController : Controller
    {
        MyContext _context;
        public SmjerStavkeAjaxController(MyContext context)
        {
            _context = context;
    ***REMOVED***
        public IActionResult Index(int id)
        {
            var model = new SmjerStavkeAjaxIndexVM
            {
                SmjerId = id,
                rows = _context.SmjerPredmet.Where(o => o.SmjerId == id).Select(x => new SmjerStavkeAjaxIndexVM.Row
                {
                    PredmetId = x.PredmetId,
                    Naziv = x.Predmet.Naziv,
                    Oznaka = x.Predmet.Oznaka
            ***REMOVED***).ToList()
        ***REMOVED***;


            return PartialView("Index", model);
    ***REMOVED***

        public IActionResult Uredi(int id)
        {

            UcenikRazredi x = _context.UceniciRazredi.Where(y => y.UcenikRazrediId == id).Include(y => y.Ucenik).FirstOrDefault();

            RazredStavkeAjaxDodajVM model = new RazredStavkeAjaxDodajVM
            {
                RedniBroj = x.RedniBroj,
                RazredId = x.RazredId,
                UcenikRazredId = id,
                UcenikId = x.UcenikId,
                ucenici = _context.Ucenici.Select(w => new SelectListItem
                {
                    Value = w.Id.ToString(),
                    Text = w.Ime + " " + w.Prezime
            ***REMOVED***).ToList()
        ***REMOVED***;

            return PartialView("Dodaj", model);
    ***REMOVED***

        public IActionResult Dodaj(int id)
        {
            RazredStavkeAjaxDodajVM model = new RazredStavkeAjaxDodajVM
            {
                RazredId = id,
                ucenici = _context.Ucenici.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Ime + " " + x.Prezime
            ***REMOVED***).ToList()
        ***REMOVED***;

            return PartialView("Dodaj", model);
    ***REMOVED***
        public IActionResult Obrisi(int id)
        {
            UcenikRazredi x = _context.UceniciRazredi.Find(id);
            int o = x.RazredId;

            _context.UceniciRazredi.Remove(_context.UceniciRazredi.Find(id));
            _context.SaveChanges();

            return Redirect("/ModulAdministrator/RazredStavkeAjax/Index?id=" + o);
    ***REMOVED***

        public IActionResult Snimi(int razredId, int ucenikId)
        {
            _context.UceniciRazredi.Add(new UcenikRazredi
            {
                RazredId = razredId,
                UcenikId = ucenikId,
                RedniBroj = 0,
                SkolskaGodina = _context.Razred.Where(x => x.RazredId == razredId).Include(x => x.SkolskaGodina).FirstOrDefault()?.SkolskaGodina.Naziv
        ***REMOVED***);

            //poredaj po prezimenu (broj u dnevniku)
            int brojac = 1;
            foreach (var item in _context.UceniciRazredi.Where(x => x.RazredId == razredId).Include(x => x.Ucenik).OrderBy(x => x.Ucenik.Prezime).ToList())
            {
                _context.Update(item);
                item.RedniBroj = brojac++;
        ***REMOVED***

            _context.SaveChanges();

            return Redirect("/ModulAdministrator/RazredStavkeAjax/Index?id=" + razredId);
    ***REMOVED***
***REMOVED***

***REMOVED***
