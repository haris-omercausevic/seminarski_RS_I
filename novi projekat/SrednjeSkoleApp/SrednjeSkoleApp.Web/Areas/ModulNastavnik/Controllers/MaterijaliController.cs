using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
using SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels;
using SrednjeSkoleApp.Web.Helper;
using SrednjeSkoleApp.Web.Helper.Files;
using static SrednjeSkoleApp.Web.Areas.ModulNastavnik.ViewModels.MaterijaliIndexVM;

namespace SrednjeSkoleApp.Web.Areas.ModulNastavnik.Controllers
{
    [Area("ModulNastavnik")]
    [Autorizacija(superAdministrator: true, administrator: false, nastavnici: true)]
    public class MaterijaliController : Controller
    {
        private MyContext _context;
        private IAzureBlobStorage _blobStorage;

        public MaterijaliController(MyContext context, IAzureBlobStorage blobStorage)
        {
            _context = context;
            _blobStorage = blobStorage;
    ***REMOVED***
        public IActionResult Index()
        {
            var model = new MaterijaliIndexVM()
            {
                predmeti = _context.Predmet.Select(x => new SelectListItem
                {
                    Value = x.PredmetId.ToString(),
                    Text = x.Naziv
            ***REMOVED***).ToList()
        ***REMOVED***;

            return View(model);
    ***REMOVED***  

        public IActionResult Trazi(int predmetId)
        {
            var model = new MaterijaliIndexVM
            {
                predmetId = predmetId,
                predmeti = _context.Predmet.Select(x => new SelectListItem
                {
                    Value = x.PredmetId.ToString(),
                    Text = x.Naziv
            ***REMOVED***).ToList()
        ***REMOVED***;
            //&& x.NastavnikId == 
            int nasid = HttpContext.GetLogiraniKorisnik().Id;
            List<Materijal> materijali = _context.Materijali.Where(x => x.PredmetId == predmetId && x.NastavnikId == nasid).ToList();

            foreach (var item in materijali)
            {
                model.Files.Add(
                    new FileDetails { Name = item.Naziv, BlobName = item.BlobName ***REMOVED***);
        ***REMOVED***

            return View("Index", model);
    ***REMOVED***



        [HttpPost]
        public async Task<IActionResult> UploadFile(int predmetId, FileInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new MaterijaliIndexVM());
        ***REMOVED***
            if (inputModel == null)
                return Content("Argument null");

            if (inputModel.File == null || inputModel.File.Length == 0)
                return Content("file not selected");

            if (predmetId == 0)
                return Content("Predmet not selected");

            var naziv = inputModel.File.GetFilename();
            var blobName = Guid.NewGuid().ToString();
            var fileStream = await inputModel.File.GetFileStream();
                       

            await _blobStorage.UploadAsync(blobName, fileStream);

            var blobUri = await _blobStorage.GetBlobByName(blobName);

            Materijal m = new Materijal()
            {
                DateCreated = DateTime.Now,
                Url = blobUri,
                BlobName = blobName,
                Naziv = naziv,
                NastavnikId = HttpContext.GetLogiraniKorisnik().Id,
                PredmetId = predmetId                
        ***REMOVED***;

            _context.Materijali.Add(m);
            _context.SaveChanges();

            return RedirectToAction("Index");
    ***REMOVED***
        public async Task<IActionResult> Download(string blobName, string name)
        {
            if (string.IsNullOrEmpty(blobName))
                return Content("Blob Name not present");

            var stream = await _blobStorage.DownloadAsync(blobName);
            return File(stream.ToArray(), "application/octet-stream", name);
    ***REMOVED***

        public async Task<IActionResult> Delete(string blobName)
        {
            if (string.IsNullOrEmpty(blobName))
                return Content("Blob Name not present");

            await _blobStorage.DeleteAsync(blobName);
            _context.Materijali.Remove(_context.Materijali.Where(x => x.BlobName == blobName).FirstOrDefault());

            return RedirectToAction("Index");
    ***REMOVED***

***REMOVED***
***REMOVED***