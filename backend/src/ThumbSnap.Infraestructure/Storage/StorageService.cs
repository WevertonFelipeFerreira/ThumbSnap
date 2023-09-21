using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;
using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Infraestructure.Storage
{
    public class StorageService : IStorageService
    {
        private readonly AmazonS3Client _s3Client;
        private readonly StorageConfig _cfg;
        public StorageService(IOptions<StorageConfig> cfg)
        {
            _cfg = cfg.Value;

            var credential = new BasicAWSCredentials(_cfg.AccessKey, _cfg.SecretKey);
            var config = new AmazonS3Config
            {
                RegionEndpoint = Amazon.RegionEndpoint.USEast1
            };
            _s3Client = new AmazonS3Client(credential, config);
        }

        public async Task<string> UploadFile(Stream file, string fileName, string extension)
        {
            var key = $"{fileName}.{extension.ToLower()}";
            var bucketName = _cfg.BucketName;

            var uploadRequest = new TransferUtilityUploadRequest()
            {
                InputStream = file,
                Key = key,
                BucketName = bucketName,
                CannedACL = S3CannedACL.NoACL
            };
            var transferUtillity = new TransferUtility(_s3Client);
            await transferUtillity.UploadAsync(uploadRequest);

            return $"https://{bucketName}.s3.amazonaws.com/{key}";
        }
    }
}
