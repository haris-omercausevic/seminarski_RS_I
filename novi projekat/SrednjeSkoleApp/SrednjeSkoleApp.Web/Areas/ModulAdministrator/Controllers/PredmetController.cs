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
    [Autorizacija(superAdministrator: true,administrator: true, nastavnici: false)]
    public class PredmetController : Controller
    {
        private MyContext _context;
        public PredmetController(MyContext context)
        {
            _context = context;
    ***REMOVED***
        public IActionResult Index()
        {
            List<Predmet> model = new List<Predmet>();

            foreach (Predmet item in _context.Predmet)
            {
                model.Add(item);   
        ***REMOVED***

            model.OrderBy(x => x.Naziv);


            return View(model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            if (!ModelState.IsValid)
            {
                return View("Dodaj");
        ***REMOVED***

            return View("Dodaj");
    ***REMOVED***

        public IActionResult Detalji(int id)
        {
            Predmet model = _context.Predmet.Find(id);

            return View("Detalji", model);
    ***REMOVED***
        public IActionResult Snimi(int predmetid, string naziv, string oznaka)
        {

            if (!ModelState.IsValid)
            {
                return View("Dodaj");
        ***REMOVED***

                Predmet p;
            if (predmetid != 0)
            {
                p = _context.Predmet.Find(predmetid);
        ***REMOVED***
            else
            {
                p = new Predmet();
                _context.Predmet.Add(p);
        ***REMOVED***

            p.Naziv = naziv;
            p.Oznaka = oznaka;
            _context.SaveChanges();

            return RedirectToAction("Index", "Predmet", new {area="ModulAdministrator"***REMOVED***);
    ***REMOVED***
        public IActionResult Obrisi(int id)
        {
            Predmet p1 = _context.Predmet.FirstOrDefault(x => x.PredmetId == id);
            _context.Predmet.Remove(p1);
            _context.SaveChanges();
            return RedirectToAction("Index", "Predmet", new { area = "ModulAdministrator" ***REMOVED***);
    ***REMOVED***

***REMOVED***
***REMOVED***