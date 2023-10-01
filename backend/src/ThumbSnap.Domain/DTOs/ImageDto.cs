namespace ThumbSnap.Domain.DTOs
{
    public class ImageDto
    {
        public TimeSpan Time { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public byte[] Bytes { get; set; }
    }
}
