namespace ThumbSnap.Infraestructure.Storage
{
    public class StorageConfig
    {
        public const string STORAGE_CONFIG = "Storage";
        public string? AccessKey { get; set; }
        public string? SecretKey { get; set; }
        public string? BucketName { get; set; }
    }
}
