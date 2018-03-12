using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Web.Models;

namespace SrednjeSkoleApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext db)
        {
            _context = db;
    ***REMOVED***

        public IActionResult Index()
        {
            return View();
    ***REMOVED***

        public IActionResult TestDB()
        {
            if (!_context.Ucenici.Any())
                MojDBInitializer.Izvrsi(_context);

            return View(_context);
    ***REMOVED***

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
