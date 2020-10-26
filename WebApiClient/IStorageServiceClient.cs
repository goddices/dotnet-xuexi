using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace WebApiClient
{
    public interface IStorageServiceClient
    {
        [Put("/v1/storage/{groupName}")]
        Task<ApiResponse<string>> CreateGroup(string groupName, CancellationToken token);
    }
}
