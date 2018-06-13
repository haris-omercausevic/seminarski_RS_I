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
using SrednjeSkoleApp.Web.Helper;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    [Autorizacija(superAdministrator: true, administrator: true, nastavnici: false)]
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
                rows = _context.UceniciRazredi.Where(o => o.RazredId == id).Include(o => o.Ucenik).Select(x => new RazredStavkeAjaxIndexVM.Row
                {
                    RedniBroj = x.RedniBroj,
                    Ucenik = x.Ucenik.Ime + x.Ucenik.Prezime,
                    UcenikRazredId = x.UcenikRazrediId,
                    UcenikId = x.UcenikId
            ***REMOVED***).OrderBy(x => x.Ucenik).ToList()
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
                ucenici = _context.UceniciRazredi.Include(x => x.Ucenik)
                    .Where(x => x.RazredId != id)
                    .Select(x => new SelectListItem
                    {
                        Value = x.Ucenik.Id.ToString(),
                        Text = x.Ucenik.Ime + " " + x.Ucenik.Prezime
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
                RedniBroj = _context.UceniciRazredi.Count(x => x.RazredId == razredId) + 1,
                SkolskaGodina = _context.Razred.Where(x => x.RazredId == razredId).Include(x => x.SkolskaGodina).FirstOrDefault()?.SkolskaGodina.Naziv
        ***REMOVED***);

            //poredaj po prezimenu (broj u dnevniku)
            //PoredajUDnevniku(razredId);

            _context.SaveChanges();

            return Redirect("/ModulAdministrator/RazredStavkeAjax/Index?id=" + razredId);
    ***REMOVED***

        private void PoredajUDnevniku(int razredId)
        {
            int brojac = 0;
            foreach (var item in _context.UceniciRazredi.Where(x => x.RazredId == razredId)
                .Include(x => x.Ucenik).OrderBy(x => x.Ucenik.Prezime).ToList())
            {
                item.RedniBroj = ++brojac;
                _context.Update(item);
        ***REMOVED***
    ***REMOVED***
***REMOVED***
***REMOVED***