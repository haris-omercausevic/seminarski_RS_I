using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web.Areas.ModulAdministrator.Controllers
{
    [Area("ModulAdministrator")]
    public class PredmetController : Controller
    {
        private MojKontext _db = new MojKontext();
        public IActionResult Index()
        {
            var model = _db.Predmet.ToList();

            return View(model);
    ***REMOVED***

        public IActionResult Dodaj()
        {
            var model = new Predmet();
            return View("Edit",model);
    ***REMOVED***

        public IActionResult Edit(int id)
        {
            Predmet model = _db.Predmet.Find(id);
            return View("Edit",model);
    ***REMOVED***
        public IActionResult Snimi(int predmetid, string naziv, string oznaka)
        {
            Predmet p;
            if (predmetid != 0)
            {
                p = _db.Predmet.Find(predmetid);
        ***REMOVED***
            else
            {
                p = new Predmet();
                _db.Predmet.Add(p);
        ***REMOVED***

            p.Naziv = naziv;
            p.Oznaka = oznaka;
            _db.SaveChanges();

            return RedirectToAction("Index");
    ***REMOVED***
        public IActionResult Obrisi(int id)
        {
            Predmet p1 = _db.Predmet.Where(x => x.PredmetId == id).FirstOrDefault();
            _db.Predmet.Remove(p1);
            _db.SaveChanges();
            return RedirectToAction("Index");
    ***REMOVED***

***REMOVED***
***REMOVED***