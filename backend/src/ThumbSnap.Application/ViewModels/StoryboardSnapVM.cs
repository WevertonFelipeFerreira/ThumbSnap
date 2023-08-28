using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Application.ViewModels
{
    public class StoryboardSnapVM
    {
        public Guid Id { get; set; }
        public TimeSpan Time { get; set; }
        public int Size { get; set; }
        public string Extension { get; set; }
        public string Path { set; get; }
    }
}
