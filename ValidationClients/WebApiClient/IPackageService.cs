using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiClient
{
    public interface IPackageService
    {
        [Post("/v1/preloadedVersionFiles")]
        Task<ApiResponse<object>> CreatePreploadedVersionFilesAsync(
            [Header("tenantId")] Guid tenantId,
            [Header("resourceGroupId")] Guid resourceGroupId,
            [Header("userid")] Guid userid,
            [Header("Name")] string username,
            CancellationToken token);
    }
}
