using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiClient
{
    public interface ITestService
    {
        [Put("/api/values")]
        Task<IApiResponse> CreateGroup([Query] string q, CancellationToken token);
    }
}
