using ThumbSnap.Domain.Entities.Common;

namespace ThumbSnap.Domain.Entities
{
    public class StoryboardSnap : EntityBase
    {
        public StoryboardSnap(int size, string path, string extension)
        {
            Size = size;
            Path = path;
            Extension = extension;

            SetCreatedDate();
        }

        public override Guid Id { get; set; }
        public Guid VideoId { get; set; }
        public TimeSpan Time { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public string Path { set; get; }
        public VideoInformation VideoInformation { get; set; }
    }
}
