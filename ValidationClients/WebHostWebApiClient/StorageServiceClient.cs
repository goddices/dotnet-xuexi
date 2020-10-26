using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebHostWebApiClient
{
    public interface IStorageServiceClient
    {
        Task CreateGroup(string name, CancellationToken token);
    }

    public class StorageServiceClient : IStorageServiceClient
    {
        private readonly HttpClient _client;

        public StorageServiceClient(IHttpClientFactory clientFactory)
        {
            this._client = clientFactory.CreateClient("storage");
        }

        public async Task CreateGroup(string name, CancellationToken token)
        {
            try
            {
                var response = await this._client.PutAsync($"v1/storage/{name}", null, token);
                await this.EnsureSuccessResponseAsync(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        private async Task EnsureSuccessResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                try
                {
                    var errorString = await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw e;
                }
            }
        }
    }

}
