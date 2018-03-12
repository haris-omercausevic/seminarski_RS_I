using System;
using System.Collections.Generic;
using System.Linq;

using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Data.EF
{
    public class MojDBInitializer
    {
        public static void Izvrsi(MyContext _context)
        {
            // Look for any students.
            if (_context.Ucenici.Any())
            {
                return;   // DB has been seeded
        ***REMOVED***

            var ucenici = new List<Ucenik>();
            var predmeti = new List<Predmet>();
            var razredi = new List<Razred>();
            var nastavniks = new List<Nastavnik>();
            var smjerovi = new List<Smjer>();
            var skolskeGodine = new List<SkolskaGodina>();
            var smjerpredmeti = new List<SmjerPredmet>();
            var predaje = new List<Predaje>();

            skolskeGodine.Add(new SkolskaGodina { Naziv = "2015/16" ***REMOVED***);
            skolskeGodine.Add(new SkolskaGodina { Naziv = "2016/17" ***REMOVED***);
            skolskeGodine.Add(new SkolskaGodina { Naziv = "2017/18" ***REMOVED***);
            foreach (var item in skolskeGodine)
            {
                _context.SkolskaGodina.Add(item);
        ***REMOVED***
           
            for (int i = 0; i < 48; i++)
            {
                predmeti.Add(new Predmet { Naziv = "Predmet " + Guid.NewGuid().ToString().Substring(0, 3), Oznaka = "P" + Guid.NewGuid().ToString().Substring(0, 2) ***REMOVED***);
                _context.Predmet.Add(predmeti[i]);

        ***REMOVED***
            for (int i = 1; i <= 4; i++)
            {
                razredi.Add(new Razred() { SkolskaGodina = skolskeGodine[1], Oznaka = i + "-a", RazredBrojcano = i, Odjeljenje = "a" ***REMOVED***);
                razredi.Add(new Razred() { SkolskaGodina = skolskeGodine[2], Oznaka = i + "-b", RazredBrojcano = i, Odjeljenje = "b" ***REMOVED***);
        ***REMOVED***
            foreach (var item in razredi)
            {
                _context.Razred.Add(item);
        ***REMOVED***
            for (int i = 1; i <= 4; i++)
            {
                smjerovi.Add(new Smjer() { SkolskaGodina = skolskeGodine[1], Naziv = "Smjer: " + Guid.NewGuid().ToString().Substring(0, 3), Opis = "Opis: " + Guid.NewGuid().ToString().Substring(0, 3) ***REMOVED***);
                smjerovi.Add(new Smjer() { SkolskaGodina = skolskeGodine[2], Naziv = "Smjer: " + Guid.NewGuid().ToString().Substring(0, 3), Opis = "Opis: " + Guid.NewGuid().ToString().Substring(0, 3) ***REMOVED***);

        ***REMOVED***
            foreach (var item in smjerovi)
            {
                _context.Smjerovi.Add(item);
        ***REMOVED***

            for (int i = 0; i < 20; i++)
            {
                nastavniks.Add(new Nastavnik
                {
                    Ime = "nastavnik: " + Guid.NewGuid().ToString().Substring(0, 3),
                    Prezime = Guid.NewGuid().ToString().Substring(0, 3),
                    GodinaZaposlenja = DateTime.Now.Year,
                    NaucnaOblast = "informatika: " + Guid.NewGuid().ToString().Substring(0, 3),
                    DatumRodjenja = DateTime.Now.Date,
                    Aktivan = true,
                    Kontakt = new KorisnikKontakt
                    {
                        Email = Guid.NewGuid().ToString().Substring(0, 3) + "@fit.ba",
                        Grad = "Mostar"
                ***REMOVED***,
                    DatumIzboraUZvanje = DateTime.Now.Date
            ***REMOVED***);
                _context.Nastavnici.Add(nastavniks[i]);

        ***REMOVED***


            for (int i = 0; i < 120; i++)
            {
                ucenici.Add(new Ucenik
                {
                    Ime = "ucenik: " + Guid.NewGuid().ToString().Substring(0, 3),
                    Prezime = Guid.NewGuid().ToString().Substring(0, 3),
                    Smjer = smjerovi[i % smjerovi.Count],
                    GodinaUpisa = DateTime.Now.Year,
                    DatumRodjenja = DateTime.Now.Date,
                    Aktivan = true,
                    Kontakt = new KorisnikKontakt
                    {
                        Email = Guid.NewGuid().ToString().Substring(0, 3) + "@fit.ba",
                        Grad = "Mostar"
                ***REMOVED***
            ***REMOVED***);
                _context.Ucenici.Add(ucenici[i]);
                _context.UceniciRazredi.Add(new UcenikRazredi
                {
                    Ucenik = ucenici[i],
                    Razred = razredi[i % razredi.Count],
                    RedniBroj = 0,
                    SkolskaGodina = skolskeGodine[i % skolskeGodine.Count].Naziv
            ***REMOVED***);

                var ocjene = new List<Ocjena>();
                for (int j = 0; j < 5; j++)
                {
                    var ucenikPredmet = new UcenikPredmet
                    {
                        Ucenik = ucenici[i],
                        Predmet = predmeti[j % predmeti.Count]
                ***REMOVED***;

                    _context.UceniciPredmeti.Add(ucenikPredmet);

                    _context.Ocjene.Add(new Ocjena
                    {
                        Vrijednost = dajOcjenu(),
                        Datum = DateTime.Now,
                        UcenikPredmet = ucenikPredmet
                ***REMOVED***);

            ***REMOVED***
               
        ***REMOVED***

            for (int i = 0; i < 40; i++)
            {
                smjerpredmeti.Add(new SmjerPredmet
                {
                    Smjer = smjerovi[i % smjerovi.Count],
                    Predmet = predmeti[i % predmeti.Count],
                    BrojCasova = 0,
                    ProsjecnaOcjena = 0
            ***REMOVED***);
                _context.SmjerPredmet.Add(smjerpredmeti[i]);
        ***REMOVED***

            for (int i = 0; i < 40; i++)
            {
                predaje.Add(new Predaje
                {
                    Nastavnik = nastavniks[i % nastavniks.Count],
                    SkolskaGodina = skolskeGodine[i % skolskeGodine.Count],
                    Razred = razredi[i % razredi.Count],
                    SmjerPredmet = smjerpredmeti[i % smjerpredmeti.Count],
                    Razrednik = i % 5 == 0
            ***REMOVED***);

                _context.Add(predaje[i]);
        ***REMOVED***
            
            _context.SaveChanges();
    ***REMOVED***
        static Random random = new Random();
        private static int dajOcjenu()
        {
            int x = random.Next(1, 20);
            if (x > 1)
                x = x % 4 + 2;
            return x;
    ***REMOVED***
***REMOVED***
***REMOVED***
