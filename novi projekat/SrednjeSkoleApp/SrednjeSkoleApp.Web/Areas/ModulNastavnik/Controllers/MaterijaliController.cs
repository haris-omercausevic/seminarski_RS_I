using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;
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
        public async Task<IActionResult> Index()
        {
            var model = new FilesViewModel();
            foreach (var item in await _blobStorage.ListAsync())
            {
                model.Files.Add(
                    new FileDetails { Name = item.Name, BlobName = item.BlobName ***REMOVED***);
        ***REMOVED***
            return View(model);
    ***REMOVED***

        [HttpPost]
        public async Task<IActionResult> UploadFile(FileInputModel inputModel)
        {
            if (inputModel == null)
                return Content("Argument null");

            if (inputModel.File == null || inputModel.File.Length == 0)
                return Content("file not selected");

            var blobName = inputModel.File.GetFilename();
            var fileStream = await inputModel.File.GetFileStream();

            if (!string.IsNullOrEmpty(inputModel.Folder))
                blobName = string.Format(@"{0***REMOVED***\{1***REMOVED***", inputModel.Folder, blobName);

            await _blobStorage.UploadAsync(blobName, fileStream);

            var blobUri = await _blobStorage.GetBlobUri(blobName);
            Korisnik korisnik = HttpContext.GetLogiraniKorisnik();
            Materijal m = new Materijal()
            {
                DateCreated = DateTime.Now,
                Url = blobUri,
                Naziv = blobName,
                NastavnikId = korisnik.Id,
                
        ***REMOVED***;

            _context.Materijali.Add(new Materijal()
            {
                DateCreated = DateTime.Now                
        ***REMOVED***);

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

            return RedirectToAction("Index");
    ***REMOVED***

***REMOVED***
***REMOVED***