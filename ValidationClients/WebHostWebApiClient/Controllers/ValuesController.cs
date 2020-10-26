using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebHostWebApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IStorageServiceClient client;
        public ValuesController(IStorageServiceClient client)
        {
            this.client = client;
        }

        public async Task Get([FromQuery] string q, CancellationToken token)
        {
            try
            {
                await client.CreateGroup("groupname" + q, token);
            }
            catch (Exception e)
            {
                Console.WriteLine("test polly ", e);
                throw;
            }
        }

        IEnumerable<Task> GetTasks(CancellationToken token)
        {
            foreach (var iter in Enumerable.Range(0, 1000))
            {
                yield return client.CreateGroup("client" + iter, token);
            }
        }
    }
}
