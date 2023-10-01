namespace ThumbSnap.Domain.Services
{
    public interface IStorageService
    {
        public Task<string> UploadFile(Stream file, string prefix, string fileName, string extension);
    }
}
