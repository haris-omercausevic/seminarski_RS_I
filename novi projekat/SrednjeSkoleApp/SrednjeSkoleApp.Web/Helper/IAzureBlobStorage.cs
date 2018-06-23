using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;


//https://github.com/TahirNaushad/Fiver.Azure.Blob

namespace SrednjeSkoleApp.Web.Helper
{
    public interface IAzureBlobStorage
    {
        Task UploadAsync(string blobName, string filePath);
        Task UploadAsync(string blobName, Stream stream);
        Task<MemoryStream> DownloadAsync(string blobName);
        Task DownloadAsync(string blobName, string path);
        Task<List<AzureBlobItem>> ListAsync();
        Task<string> GetBlobUriByName(string blobName);
        Task DeleteAsync(string blobName);
***REMOVED***
***REMOVED***