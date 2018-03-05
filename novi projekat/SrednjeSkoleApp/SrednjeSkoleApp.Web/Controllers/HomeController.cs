using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SrednjeSkoleApp.Web.Models;

namespace SrednjeSkoleApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
    ***REMOVED***

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
    ***REMOVED***

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
    ***REMOVED***

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
