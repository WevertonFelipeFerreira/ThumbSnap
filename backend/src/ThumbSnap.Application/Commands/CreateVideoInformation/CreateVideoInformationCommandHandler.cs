using AutoMapper;
using MediatR;
using ThumbSnap.Application.ViewModels;
using ThumbSnap.Domain.Entities;
using ThumbSnap.Domain.Repositories;

namespace ThumbSnap.Application.Commands.CreateVideoInformation
{
    public class CreateVideoInformationCommandHandler : IRequestHandler<CreateVideoInformationCommand, VideoInformationVM>
    {
        private readonly IVideoInformationRepository _videoInformationRepository;
        private readonly IMapper _mapper;
        public CreateVideoInformationCommandHandler(IVideoInformationRepository videoInformationRepository, IMapper mapper)
        {
            _videoInformationRepository = videoInformationRepository;
            _mapper = mapper;
        }

        public async Task<VideoInformationVM> Handle(CreateVideoInformationCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<VideoInformation>(request);
            await _videoInformationRepository.AddAsync(entity);

            return _mapper.Map<VideoInformationVM>(entity);
        }
    }
}
