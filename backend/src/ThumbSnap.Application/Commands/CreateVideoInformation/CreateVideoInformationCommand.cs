using MediatR;
using ThumbSnap.Application.ViewModels;

namespace ThumbSnap.Application.Commands.CreateVideoInformation
{
    public class CreateVideoInformationCommand : IRequest<VideoInformationVM>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int SnapWidth { get; set; }
        public int SnapHeight { get; set; }
        public int SnapTakenEverySeconds { get; set; }
    }
}
