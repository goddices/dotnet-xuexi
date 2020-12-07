using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.S3;
using MinioTest.Models;
using Amazon.S3.Model;
using Amazon.Runtime;
using Microsoft.Extensions.Options;

namespace MinioTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinIoController : ControllerBase
    {
        private readonly string bucketName = "test";
        private readonly MinIoServiceOptions minioServiceOptions;
        private readonly AmazonS3Client s3Client;
        public MinIoController(IOptionsMonitor<MinIoServiceOptions> optionsMonitor)
        {
            minioServiceOptions = optionsMonitor.CurrentValue;
            this.s3Client = new AmazonS3Client(
                new BasicAWSCredentials(minioServiceOptions.AppId, minioServiceOptions.AppSecret),
                new AmazonS3Config
                {
                    ServiceURL = minioServiceOptions.BaseAddress,
                    UseHttp = false,
                    ForcePathStyle = true
                });
        }

        [HttpGet("{fileName}")]
        public async Task<AS3Uri> UploadUri(string fileName, [FromQuery] long fileSize, [FromQuery] string contentType = "application/octet-stream")
        {
            try
            {
                await s3Client.PutBucketAsync(bucketName);
            }
            catch (AmazonS3Exception ex) when (ex.ErrorCode.Equals("BucketAlreadyOwnedByYou"))
            {
                //return sucess if the bucket is already exists
            }

            string uri = s3Client.GetPreSignedURL(new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                ContentType = contentType,
                Key = fileName,
                Verb = HttpVerb.PUT,
                Expires = DateTime.Now.AddDays(1),
                Protocol = Protocol.HTTP
            });
            return new AS3Uri
            {
                Headers = new Dictionary<string, string>
                {
                    ["Content-Type"] = contentType
                },
                Uri = uri
            };
        }
    }
}
