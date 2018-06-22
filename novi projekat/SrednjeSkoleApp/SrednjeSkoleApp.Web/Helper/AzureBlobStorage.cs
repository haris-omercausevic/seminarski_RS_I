using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SrednjeSkoleApp.Web.Helper
{
    public class AzureBlobStorage: IAzureBlobStorage
    {
        //AzureBlobSetings settings = new AzureBlobSetings("srednjeskole", "Wh8zk+437uReFvE/M1+Q8g9/3AttRTJUIyCbUWs+iKM5MpcftwhMReWRSxDOa+jzII4CrFmeK3H5grDPEpWIhg==", "srednjeskole");
        private readonly AzureBlobSetings settings;
        public AzureBlobStorage(AzureBlobSetings settings)
        {
            this.settings = settings;
    ***REMOVED***
             

        public async Task UploadAsync(string blobName, string filePath)
        {
            //Blob
            CloudBlockBlob blockBlob = await GetBlockBlobAsync(blobName);

            //Upload
            using (var fileStream = System.IO.File.Open(filePath, FileMode.Open))
            {
                fileStream.Position = 0;
                await blockBlob.UploadFromStreamAsync(fileStream);
        ***REMOVED***
    ***REMOVED***

        public async Task UploadAsync(string blobName, Stream stream)
        {
            //Blob
            CloudBlockBlob blockBlob = await GetBlockBlobAsync(blobName);

            //Upload
            stream.Position = 0;
            await blockBlob.UploadFromStreamAsync(stream);
    ***REMOVED***

        public async Task<MemoryStream> DownloadAsync(string blobName)
        {
            //Blob
            CloudBlockBlob blockBlob = await GetBlockBlobAsync(blobName);

            //Download
            using (var stream = new MemoryStream())
            {
                await blockBlob.DownloadToStreamAsync(stream);
                return stream;
        ***REMOVED***
    ***REMOVED***

        public async Task DownloadAsync(string blobName, string path)
        {
            //Blob
            CloudBlockBlob blockBlob = await GetBlockBlobAsync(blobName);

            //Download
            await blockBlob.DownloadToFileAsync(path, FileMode.Create);
    ***REMOVED***

        public async Task DeleteAsync(string blobName)
        {
            //Blob
            CloudBlockBlob blockBlob = await GetBlockBlobAsync(blobName);

            //Delete
            await blockBlob.DeleteAsync();
    ***REMOVED***

        public async Task<List<AzureBlobItem>> ListAsync()
        {
            return await GetBlobListAsync();
    ***REMOVED***

        private async Task<CloudBlobContainer> GetContainerAsync()
        {
            //Account
            CloudStorageAccount storageAccount = new CloudStorageAccount(
         new StorageCredentials(settings.StorageAccount, settings.StorageKey), false);

            //Client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Container
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(settings.ContainerName);
            await blobContainer.CreateIfNotExistsAsync();

            return blobContainer;
    ***REMOVED***

        private async Task<CloudBlockBlob> GetBlockBlobAsync(string blobName)
        {
            //Container
            CloudBlobContainer blobContainer = await GetContainerAsync();

            //Blob
            CloudBlockBlob blockBlob = blobContainer.GetBlockBlobReference(blobName);

            return blockBlob;
    ***REMOVED***

        private async Task<List<AzureBlobItem>> GetBlobListAsync(bool useFlatListing = true)
        {
            //Container
            CloudBlobContainer blobContainer = await GetContainerAsync();

            //List
            var list = new List<AzureBlobItem>();
            BlobContinuationToken token = null;
            do
            {
                BlobResultSegment resultSegment =
                    await blobContainer.ListBlobsSegmentedAsync("", useFlatListing,
                          new BlobListingDetails(), null, token, null, null);
                token = resultSegment.ContinuationToken;

                foreach (IListBlobItem item in resultSegment.Results)
                {
                    list.Add(new AzureBlobItem(item));
            ***REMOVED***
        ***REMOVED*** while (token != null);

            return list.OrderBy(i => i.Folder).ThenBy(i => i.Name).ToList();
    ***REMOVED***

       
***REMOVED***
***REMOVED***
