using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using Polly;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Newtonsoft.Json;

namespace WebApiClient
{
    public static class SerializeExtension
    {
        public static T DeserializeObject<T>(this string jsonText) => JsonConvert.DeserializeObject<T>(jsonText);
    }

    public class StorageServiceClient : IStorageServiceClient
    {
        private readonly HttpClient _client;

        public StorageServiceClient(IHttpClientFactory clientFactory)
        {
            this._client = clientFactory.CreateClient("storage");
        }
        public async Task<ApiResponse<string>> CreateGroup(string name, CancellationToken token)
        {
            var response = await this._client.PutAsync($"v1/storage/{name}", null, token);
            await this.EnsureSuccessResponseAsync(response);
            return new ApiResponse<string>(response, await response.Content.ReadAsStringAsync());
        }

        private async Task EnsureSuccessResponseAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var errorString = await response.Content.ReadAsStringAsync();

                //if not BusinessErrorDTO content: get stream from sasurl
                throw new Exception(errorString);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a1 = "​/v1​/LicenseBindings​/bindTo​";
            a1.Split('/').ToList().ForEach(e =>
            {
                Console.WriteLine(e);
            });

            Console.WriteLine("Hello World!");
            Run().Wait();
            Console.WriteLine("按回车结束");
            Console.ReadLine();
            Console.WriteLine("End");
        }

        static IEnumerable<Task> GetTasks(IPackageService service, CancellationToken token)
        {
            var id = Guid.NewGuid();
            foreach (var iter in Enumerable.Range(0, 1000))
            {
                yield return service
                    .CreatePreploadedVersionFilesAsync(id, id, id, "emh1ZmVuZw==", CancellationToken.None)
                 ;
                ;
            }

        }

        static IEnumerable<Task> GetTasks(ServiceProvider serviceProvider, CancellationToken token)
        {
            foreach (var iter in Enumerable.Range(0, 1000))
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var service = scope.ServiceProvider.GetRequiredService<IStorageServiceClient>();
                    yield return service
                        .CreateGroup("client" + iter, CancellationToken.None)
                        .ContinueWith(t =>
                        {
                            var response = t.Result;
                            if (response.IsSuccessStatusCode)
                            {
                                Console.WriteLine($"date time: {DateTime.Now}, status code: {response.StatusCode}, response text: {response.Content}");
                            }
                            else
                            {
                                Console.WriteLine($"date time: {DateTime.Now}, status code: {response.StatusCode}, error: {response.Error?.Content}");
                            }
                        });
                }
            }
        }

        static async Task Run()
        {

            try
            {
                var id = Guid.NewGuid();
                var service = RestService.For<IPackageService>("http://localhost:11000");
                //var tasks = GetTasks(service, CancellationToken.None).ToArray();
                var a = await service.CreatePreploadedVersionFilesAsync(id, id, id, "emh1ZmVuZw==", CancellationToken.None);
                var tasks = GetTasks(service, CancellationToken.None).ToArray();
                await Task.WhenAll(tasks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
