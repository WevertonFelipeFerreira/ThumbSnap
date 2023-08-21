using ThumbSnap.Domain.Entities.Common;
using ThumbSnap.Domain.Enums;

namespace ThumbSnap.Domain.Entities
{
    public class VideoInformation : EntityBase
    {
        public VideoInformation(string name, string path, int width, int height, int snapWidth, int snapHeight, int size, TimeSpan duration, int snapTakenEverySeconds)
        {
            Name = name;
            Path = path;
            Width = width;
            Height = height;
            SnapWidth = snapWidth;
            SnapHeight = snapHeight;
            Size = size;
            Duration = duration;
            SnapTakenEverySeconds = snapTakenEverySeconds;
            StoryboardProcessingStatus = StoryboardProcessingStatus.InQueue;

            SetCreatedDate();
        }

        public override Guid Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int SnapWidth { get; set; }
        public int SnapHeight { get; set; }
        public int Size { get; set; }
        public TimeSpan Duration { get; set; }
        public int SnapTakenEverySeconds { get; set; }
        public string? RejectionMessage { get; set; } = null;
        public StoryboardProcessingStatus StoryboardProcessingStatus { get; set; }
        public IEnumerable<StoryboardSnap> Snaps { get; set; } = new List<StoryboardSnap>();
    }
}
