using MediatR;
using ThumbSnap.Application.ViewModels;
using ThumbSnap.Domain.Repositories;

namespace ThumbSnap.Application.Commands.CreateVideoInformation
{
    public class CreateVideoInformationCommandHandler : IRequestHandler<CreateVideoInformationCommand, VideoInformationVM>
    {
        private readonly IVideoInformationRepository _videoInformationRepository;
        public CreateVideoInformationCommandHandler(IVideoInformationRepository videoInformationRepository)
        {
            _videoInformationRepository = videoInformationRepository;
        }

        public async Task<VideoInformationVM> Handle(CreateVideoInformationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
