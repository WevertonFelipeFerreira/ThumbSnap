using ThumbSnap.Domain.Enums;

namespace ThumbSnap.Application.ViewModels
{
    public class VideoInformationVM
    {
        public Guid Id { get; set; }
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
        public IEnumerable<StoryboardSnapVM> StoryboardSnaps { get; set; } = new List<StoryboardSnapVM>();
    }
}
