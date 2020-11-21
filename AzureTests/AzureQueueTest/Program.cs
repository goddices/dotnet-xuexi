using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AzureQueueTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TestAsync().Wait();
        }

        static async Task TestAsync()
        {
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=zhufengtest;AccountKey=dgurDnEjLa1FWkSztRlxcQJwadLre7nnaY7ZnxsOYUQHZaVRTnbrxUt7LXTY03nuWMbzxPrU6LF/LydUIDUcOw==;EndpointSuffix=core.chinacloudapi.cn";
            var queueName = "123";
            QueueClient queue = new QueueClient(connectionString, queueName);
            await queue.CreateIfNotExistsAsync();
            var msg = await queue.ReceiveMessagesAsync();
            var value = msg.Value;
            foreach (QueueMessage message in value)
            {
                
            } 

        }
    }
}
