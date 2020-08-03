using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using Microsoft.WindowsAzure.Storage;

namespace AzureTableNetCore
{
    public class BatchDeleteBlob
    {
        public static async Task Execute()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=consolestoragedev;AccountKey=XQNWqzcB3P35wq4gd+Xi3bmHn2zz4g1MYmZXEWg5E2NfmqYxTI93e1XbIiNmbZAkagd9relaRLP3tMUPbOVW2g==;EndpointSuffix=core.chinacloudapi.cn";
            var account = CloudStorageAccount.Parse(storageConnectionString);
            var cloudBlob = account.CreateCloudBlobClient();
            var result = await cloudBlob.ListContainersSegmentedAsync(null, new BlobContinuationToken());
            var list = result.Results;
            foreach (var item in list)
            {
                await item.DeleteIfExistsAsync();
            }
        }
    }
}
