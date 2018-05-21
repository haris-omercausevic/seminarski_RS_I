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
            var uloge = new List<Uloga>();

            uloge.Add(new Uloga { Naziv = "SuperAdministrator", SuperAdministrator = true, Administrator = true, Nastavnik = true, Ucenik = true, Roditelj = true ***REMOVED***);
            uloge.Add(new Uloga { Naziv = "Administrator", Administrator = true ***REMOVED***);
            uloge.Add(new Uloga { Naziv = "Nastavnik", Nastavnik = true ***REMOVED***);
            foreach (var item in uloge)
            {
                _context.Uloge.Add(item);
        ***REMOVED***


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
                    DatumIzboraUZvanje = DateTime.Now.Date,
                    JMBG = Guid.NewGuid().ToString().Substring(0, 13),
                    Zvanje = "doc.dr"
            ***REMOVED***);
                nastavniks[i].KorisnickoIme = nastavniks[i].Kontakt.Email;
                _context.Nastavnici.Add(nastavniks[i]);
        ***REMOVED***


            int brojac = 0;
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
                //var ocjene = new List<Ocjena>();
                for (int j = 0; j < 5; j++)
                {
                    _context.UceniciPredmeti.Add(new UcenikPredmet
                    {
                        Ucenik = ucenici[i],
                        Predmet = predmeti[j % predmeti.Count],
                        ZakljucnaOcjena = 0,

                        //Nastavnik =  
                ***REMOVED***);

                    _context.Ocjene.Add(new Ocjena
                    {
                        Vrijednost = dajOcjenu(),
                        Datum = DateTime.Now
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

            int broj = 1;
            foreach (var item in nastavniks)
            {
                _context.KorisniciUloge.Add(new KorisniciUloge()
                {
                    KorisnikID = item.Id,
                    UlogaID = uloge.Where(x => x.Naziv == "Nastavnik").Select(x => x.UlogaId).SingleOrDefault()
            ***REMOVED***);

                _context.Obavijesti.Add(new Obavijest
                {
                    Datum = DateTime.Now,
                    KorisnikId = item.Id,
                    Naslov = "Vijest br " + broj,
                    Tekst = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
            ***REMOVED***);
                broj++;
        ***REMOVED***

            foreach (var predajeItem in predaje)
            {
                // za svaki predmet kojem predaje daj ocjenu

                foreach (var item in _context.UceniciRazredi.Where(x => x.RazredId == predajeItem.RazredId))
                {
                   // item.
            ***REMOVED***
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
