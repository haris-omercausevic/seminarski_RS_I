using System;
using System.Collections.Generic;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web.Helper
{
    public class Autentifikacija
    {
        //private const string LogiraniKorisnik = "logirani_korisnik";

        //public static void PokreniNovuSesiju(Korisnik korisnik, HttpContextBase context, bool zapamtiPassword)
        //{
        //    context.Session.Add(LogiraniKorisnik, korisnik);

        //    if (zapamtiPassword)
        //    {
        //        HttpCookie cookie = new HttpCookie("_mvc_session", korisnik != null ? korisnik.Id.ToString() : "");
        //        cookie.Expires = DateTime.Now.AddDays(10);
        //        context.Response.Cookies.Add(cookie);
        //***REMOVED***
        //***REMOVED***

        //public static Korisnik GetLogiraniKorisnik(HttpContextBase context)
        //{
        //    Korisnik korisnik = (Korisnik) context.Session[LogiraniKorisnik];

        //    if (korisnik != null)
        //        return korisnik;

        //    HttpCookie cookie = context.Request.Cookies.Get("_mvc_session");

        //    if (cookie == null)
        //        return null;

        //    long userId;
        //    try
        //    {
        //        userId = Int64.Parse(cookie.Value);
        //***REMOVED***
        //    catch 
        //    {
        //        return null;
        //***REMOVED***


        //    using (MojContext db = new MojContext())
        //    {
        //       Korisnik k = db.Korisniks
        //            .Include(x => x.Students.Select(y => y.Studiranjes))
        //            .Include(x => x.Zaposleniks.Select(y => y.Zaposlenja))
        //            .SingleOrDefault(x => x.Id == userId);

        //        PokreniNovuSesiju(k, context, true);
        //        return k;
        //***REMOVED***
        //***REMOVED***


        //public static List<Zaposlenje> getZaposlenjes(HttpContextBase context)
        //{
        //    Korisnik k = GetLogiraniKorisnik(context);
        //    if (k == null || k.Zaposlenik == null)
        //        return null;

        //    MojContext ctx = new MojContext();

        //    int id = k.Zaposlenik.Id;
        //    return ctx.Zaposlenjes.Where(x => x.ZaposlenikId == id).ToList();
        //***REMOVED***



        //public static List<Studiranje> getStudiranjes(HttpContextBase context)
        //{
        //    Korisnik k = GetLogiraniKorisnik(context);
        //    if (k == null || k.Student == null)
        //        return null;

        //    MojContext ctx = new MojContext();
        //    return ctx.Studiranjes.Where(x => x.StudentId == k.Student.Id).ToList();
        //***REMOVED***

       
***REMOVED***
***REMOVED***