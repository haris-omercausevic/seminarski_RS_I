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
    [Autorizacija(administrator: true, nastavnici: true)]
    public class SesijaController : Controller
    {
        private MyContext _context;

        public SesijaController(MyContext context)
        {
            _context = context;
    ***REMOVED***

        public IActionResult Index()
        {
            SesijaIndexVM model = new SesijaIndexVM();
            model.Rows = _context.AutorizacijskiToken.Select(s => new SesijaIndexVM.Row
            {
                VrijemeLogiranja = s.VrijemeEvidentiranja,
                token = s.Vrijednost,
                IpAdresa = s.IpAdresa
        ***REMOVED***).ToList();
            model.TrenutniToken = HttpContext.GetTrenutniToken();

            return View(model);
    ***REMOVED***

        public IActionResult Obrisi(string token)
        {
            AutorizacijskiToken obrisati = _context.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == token);
            if (obrisati != null)
            {
                _context.AutorizacijskiToken.Remove(obrisati);
                _context.SaveChanges();
        ***REMOVED***
            return RedirectToAction("Index");
    ***REMOVED***
***REMOVED***
***REMOVED***