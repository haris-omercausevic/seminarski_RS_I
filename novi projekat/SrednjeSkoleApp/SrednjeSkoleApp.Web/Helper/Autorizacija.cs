using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQLitePCL;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web.Helper
{
    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool superAdministrator, bool administrator, bool nastavnici)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { administrator, nastavnici ***REMOVED***;
    ***REMOVED***
***REMOVED***

    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool superAdministrator, bool administrator, bool nastavnici)
        {
            _superAdministrator = superAdministrator;
            _administrator = administrator;
            _nastavnici = nastavnici;
    ***REMOVED***
        private readonly bool _superAdministrator;
        private readonly bool _administrator;
        private readonly bool _nastavnici;

        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            Korisnik k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["error_poruka"] = "Niste logirani";
            ***REMOVED***

                filterContext.Result = new RedirectToActionResult("Index", "Autentifikacija", new { @area = "" ***REMOVED***);
                return;
        ***REMOVED***

            //Preuzimamo DbContext preko app services
            MyContext context = filterContext.HttpContext.RequestServices.GetService<MyContext>();
            List<KorisniciUloge> korisniciUloge = context.KorisniciUloge.Where(x => x.KorisnikID == k.Id).Include(x => x.Uloga).ToList();



            if (_superAdministrator)
            {
                foreach (var item in korisniciUloge)
                {
                    if (item.Uloga.Naziv == "SuperAdministrator")
                    {
                        await next(); //ok - ima pravo pristupa
                        return;
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***

            if (_administrator)
            {
                foreach (var item in korisniciUloge)
                {
                    if (item.Uloga.Naziv == "Administrator")
                    {
                        await next(); //ok - ima pravo pristupa
                        return;
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***

            if (_nastavnici)
            {
                foreach (var item in korisniciUloge)
                {
                    if (item.Uloga.Naziv == "Nastavnik")
                    {
                        await next(); //ok - ima pravo pristupa
                        return;
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***

            if (filterContext.Controller is Controller c1)
                {
                    c1.TempData["error_poruka"] = "Nemate pravo pristupa";
            ***REMOVED***
            filterContext.Result = new RedirectToActionResult("Index", "Home", new { @area = "" ***REMOVED***);
        ***REMOVED***

            public void OnActionExecuted(ActionExecutedContext context)
{
    // throw new NotImplementedException();
***REMOVED***
    ***REMOVED***
***REMOVED***
