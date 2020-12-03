using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTableNetCore
{
    public static class CloudTableOperationExtension
    {

        public static Task<TEntity> InsertOrMergeAsync<TEntity>(this CloudTable table, TEntity entity) where TEntity : TableEntity
        {
            TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

            // Execute the operation.
            return table.ExecuteAsync(insertOrMergeOperation).ContinueWith(t =>
            {
                TableResult result = t.Result;
                // Get the request units consumed by the current operation. RequestCharge of a TableResult is only applied to Azure Cosmos DB
                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }
                return result.Result as TEntity;
            });
        }

        public static Task<TEntity> InsertOrReplaceAsync<TEntity>(this CloudTable table, TEntity entity) where TEntity : TableEntity
        {
            TableOperation insertOrMergeOperation = TableOperation.InsertOrReplace(entity);

            // Execute the operation.
            return table.ExecuteAsync(insertOrMergeOperation).ContinueWith(t =>
            {
                TableResult result = t.Result;
                // Get the request units consumed by the current operation. RequestCharge of a TableResult is only applied to Azure Cosmos DB
                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }
                return result.Result as TEntity;
            });
        }

        public static Task<TEntity> DeleteAsync<TEntity>(this CloudTable table, TEntity entity) where TEntity : TableEntity
        {
            TableOperation insertOrMergeOperation = TableOperation.Delete(entity);

            // Execute the operation.
            return table.ExecuteAsync(insertOrMergeOperation).ContinueWith(t =>
            {
                TableResult result = t.Result;
                // Get the request units consumed by the current operation. RequestCharge of a TableResult is only applied to Azure Cosmos DB
                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }
                return result.Result as TEntity;
            });
        }


        public static Task<CustomerEntity> QueryAsync(this CloudTable table, CustomerEntity customer)
        {
            var query = table.CreateQuery<CustomerEntity>();
            var cus = query.Where(x => x.PartitionKey == customer.PartitionKey && x.RowKey == customer.RowKey)
                .Select(x => new CustomerEntity
                {
                    PartitionKey = x.PartitionKey,
                    RowKey = x.RowKey,
                    Email = x.Email,
                    ETag = x.ETag,
                    PhoneNumber = x.PhoneNumber,
                    Timestamp = x.Timestamp
                }).FirstOrDefault();
            return Task.FromResult(cus);


        }

        public static CloudTable GetAzureTable(this string storageConnectionString, string tablename)
        {
            var storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            return tableClient.GetTableReference(tablename);

        }
    }
}
