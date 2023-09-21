namespace ThumbSnap.Domain.Entities
{
    public interface IStorageService
    {
        public Task<string> UploadFile(Stream file, string fileName, string extension);
    }
}
