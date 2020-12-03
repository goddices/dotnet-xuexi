using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AzureTableNetCore
{
    public static class ProgrameClient
    {
        public static async Task RunAsync()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=consolestoragedev;AccountKey=XQNWqzcB3P35wq4gd+Xi3bmHn2zz4g1MYmZXEWg5E2NfmqYxTI93e1XbIiNmbZAkagd9relaRLP3tMUPbOVW2g==;EndpointSuffix=core.chinacloudapi.cn";


            CloudTable table = storageConnectionString.GetAzureTable("customer");
            await table.CreateIfNotExistsAsync();

            var entity = new CustomerEntity("test11", "test12")
            {
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            };

            var entity2 = new CustomerEntity("zzz", "fff")
            {
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            };
            await table.InsertOrMergeAsync(entity2);

            var result1 = await table.InsertOrMergeAsync(entity);
            var etag = result1.ETag;


            entity.Email = "asdfadfadsf";
            var result2 = await table.InsertOrMergeAsync(entity);
            var etag2 = result1.ETag;

            entity.ETag = etag;
            entity.Email = "aaaa";
            var result3 = await table.InsertOrReplaceAsync(entity);


            var re = await table.QueryAsync(entity2);

            Console.WriteLine("Heeloworld");


        }
    }
}
