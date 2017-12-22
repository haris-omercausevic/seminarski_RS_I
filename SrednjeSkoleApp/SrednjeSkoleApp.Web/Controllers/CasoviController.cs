using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web.Controllers
{
    public class CasoviController : Controller
    {
        private readonly MojKontext _context;

        public CasoviController(MojKontext context)
        {
            _context = context;
    ***REMOVED***

        // GET: Casovi
        public async Task<IActionResult> Index()
        {
            var mojKontext = _context.Casovi.Include(c => c.Nastavnik);
            return View(await mojKontext.ToListAsync());
    ***REMOVED***

        // GET: Casovi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
        ***REMOVED***

            var cas = await _context.Casovi
                .Include(c => c.Nastavnik)
                .SingleOrDefaultAsync(m => m.CasId == id);
            if (cas == null)
            {
                return NotFound();
        ***REMOVED***

            return View(cas);
    ***REMOVED***

        // GET: Casovi/Create
        public IActionResult Create()
        {
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnici, "KorisnikId", "Discriminator");
            return View();
    ***REMOVED***

        // POST: Casovi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CasId,Datum,Naslov,opis,NastavnikId")] Cas cas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        ***REMOVED***
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnici, "KorisnikId", "Discriminator", cas.NastavnikId);
            return View(cas);
    ***REMOVED***

        // GET: Casovi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
        ***REMOVED***

            var cas = await _context.Casovi.SingleOrDefaultAsync(m => m.CasId == id);
            if (cas == null)
            {
                return NotFound();
        ***REMOVED***
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnici, "KorisnikId", "Discriminator", cas.NastavnikId);
            return View(cas);
    ***REMOVED***

        // POST: Casovi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CasId,Datum,Naslov,opis,NastavnikId")] Cas cas)
        {
            if (id != cas.CasId)
            {
                return NotFound();
        ***REMOVED***

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cas);
                    await _context.SaveChangesAsync();
            ***REMOVED***
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasExists(cas.CasId))
                    {
                        return NotFound();
                ***REMOVED***
                    else
                    {
                        throw;
                ***REMOVED***
            ***REMOVED***
                return RedirectToAction(nameof(Index));
        ***REMOVED***
            ViewData["NastavnikId"] = new SelectList(_context.Nastavnici, "KorisnikId", "Discriminator", cas.NastavnikId);
            return View(cas);
    ***REMOVED***

        // GET: Casovi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
        ***REMOVED***

            var cas = await _context.Casovi
                .Include(c => c.Nastavnik)
                .SingleOrDefaultAsync(m => m.CasId == id);
            if (cas == null)
            {
                return NotFound();
        ***REMOVED***

            return View(cas);
    ***REMOVED***

        // POST: Casovi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cas = await _context.Casovi.SingleOrDefaultAsync(m => m.CasId == id);
            _context.Casovi.Remove(cas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
    ***REMOVED***

        private bool CasExists(int id)
        {
            return _context.Casovi.Any(e => e.CasId == id);
    ***REMOVED***
***REMOVED***
***REMOVED***
