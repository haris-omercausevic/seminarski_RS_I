using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext httpContext, Korisnik korisnik, bool snimiUCookie = false)
        {

            MyContext context = httpContext.RequestServices.GetService<MyContext>();

            string stariToken = httpContext.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken != null)
            {
                AutorizacijskiToken obrisati = context.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken);
                if (obrisati != null)
                {
                    context.AutorizacijskiToken.Remove(obrisati);
                    context.SaveChanges();
            ***REMOVED***
        ***REMOVED***

            if (korisnik != null)
            {

                string token = Guid.NewGuid().ToString();
                context.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisnikId = korisnik.Id,
                    VrijemeEvidentiranja = DateTime.Now
            ***REMOVED***);
                context.SaveChanges();
                httpContext.Response.SetCookieJson(LogiraniKorisnik, token);
        ***REMOVED***
    ***REMOVED***

        public static string GetTrenutniToken(this HttpContext httpContext)
        {
            return httpContext.Request.GetCookieJson<string>(LogiraniKorisnik);
    ***REMOVED***

        public static Korisnik GetLogiraniKorisnik(this HttpContext httpContext)
        {
            MyContext context = httpContext.RequestServices.GetService<MyContext>();

            string token = httpContext.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (token == null)
                return null;

            return context.AutorizacijskiToken
                .Where(x => x.Vrijednost == token)
                .Select(s => s.Korisnik)
                .SingleOrDefault();

    ***REMOVED***
***REMOVED***
***REMOVED***
