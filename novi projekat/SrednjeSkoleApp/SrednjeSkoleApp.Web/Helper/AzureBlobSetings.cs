using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SrednjeSkoleApp.Web.Helper
{
    public class AzureBlobSetings
    {
        public AzureBlobSetings(string storageAccount,
                                       string storageKey,
                                       string containerName)
        {
            if (string.IsNullOrEmpty(storageAccount))
                throw new ArgumentNullException("StorageAccount");

            if (string.IsNullOrEmpty(storageKey))
                throw new ArgumentNullException("StorageKey");

            if (string.IsNullOrEmpty(containerName))
                throw new ArgumentNullException("ContainerName");

            this.StorageAccount = storageAccount;
            this.StorageKey = storageKey;
            this.ContainerName = containerName;
    ***REMOVED***

        public string StorageAccount { get; ***REMOVED***
        public string StorageKey { get; ***REMOVED***
        public string ContainerName { get; ***REMOVED***
***REMOVED***
***REMOVED***
