using ThumbSnap.Domain.Entities.Common;

namespace ThumbSnap.Domain.Entities
{
    public class StoryboardSnap : EntityBase
    {
        public StoryboardSnap(long size, string extension, TimeSpan time)
        {
            Size = size;
            Extension = extension;
            Time = time;

            SetCreatedDate();
        }

        public override Guid Id { get; set; }
        public Guid VideoId { get; set; }
        public TimeSpan Time { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public string Path { set; get; }
        public VideoInformation VideoInformation { get; set; }
    }
}
