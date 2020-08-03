using Microsoft.Azure.Cosmos.Table;
using System;

namespace AzureTableNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BatchDeleteBlob.Execute().Wait();

            Console.WriteLine("Hello World!");
        }
        public static void Test1()
        {
            string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=consolestoragedev;AccountKey=XQNWqzcB3P35wq4gd+Xi3bmHn2zz4g1MYmZXEWg5E2NfmqYxTI93e1XbIiNmbZAkagd9relaRLP3tMUPbOVW2g==;EndpointSuffix=core.chinacloudapi.cn";
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("test");
            table.CreateIfNotExistsAsync();

            var entity = new CustomerEntity("tet1", "test2")
            {
                Email = "Walter@contoso.com",
                PhoneNumber = "425-555-0101"
            };


            // Create the InsertOrReplace table operation
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

            // Execute the operation.
            var t = table.ExecuteAsync(insertOrMergeOperation);
            t.Wait();
            TableResult result = t.Result;
            CustomerEntity insertedCustomer = result.Result as CustomerEntity;

            // Get the request units consumed by the current operation. RequestCharge of a TableResult is only applied to Azure Cosmos DB
            if (result.RequestCharge.HasValue)
            {
                Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
            }

            var a = insertedCustomer;
        }

    }


    public class CustomerEntity : TableEntity
    {
        public CustomerEntity()
        {
        }

        public CustomerEntity(string lastName, string firstName)
        {
            PartitionKey = lastName;
            RowKey = firstName;
        }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }

}