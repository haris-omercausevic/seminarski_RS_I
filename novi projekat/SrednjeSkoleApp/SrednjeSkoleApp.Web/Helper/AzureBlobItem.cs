using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SrednjeSkoleApp.Web.Helper
{
    public class AzureBlobItem
    {
        public AzureBlobItem(IListBlobItem item)
        {
            this.Item = item;
    ***REMOVED***

        public IListBlobItem Item { get; ***REMOVED***

        public bool IsBlockBlob => Item.GetType() == typeof(CloudBlockBlob);
        public bool IsPageBlob => Item.GetType() == typeof(CloudPageBlob);
        public bool IsDirectory => Item.GetType() == typeof(CloudBlobDirectory);

        public string BlobName => IsBlockBlob ? ((CloudBlockBlob)Item).Name :
                                  IsPageBlob ? ((CloudPageBlob)Item).Name :
                                  IsDirectory ? ((CloudBlobDirectory)Item).Prefix :
                                  "";

        public string Folder => BlobName.Contains("/") ?
                         BlobName.Substring(0, BlobName.LastIndexOf("/")) : "";

        public string Name => BlobName.Contains("/") ?
                         BlobName.Substring(BlobName.LastIndexOf("/") + 1) : BlobName;
***REMOVED***
***REMOVED***
