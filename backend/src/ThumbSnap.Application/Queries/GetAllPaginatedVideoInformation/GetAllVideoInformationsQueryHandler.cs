using AutoMapper;
using MediatR;
using ThumbSnap.Application.ViewModels;
using ThumbSnap.Domain.Enums;
using ThumbSnap.Domain.Models;
using ThumbSnap.Domain.Repositories;

namespace ThumbSnap.Application.Queries.GetAllPaginatedVideoInformation
{
    public class GetAllVideoInformationsQueryHandler : IRequestHandler<GetAllVideoInformationsQuery, PaginationResult<VideoInformationVM>>
    {
        private readonly IVideoInformationRepository _videoInformationRepository;
        private readonly IMapper _mapper;
        public GetAllVideoInformationsQueryHandler(IVideoInformationRepository videoInformationRepository, IMapper mapper)
        {
            _videoInformationRepository = videoInformationRepository;
            _mapper = mapper;
        }

        public async Task<PaginationResult<VideoInformationVM>> Handle(GetAllVideoInformationsQuery request, CancellationToken cancellationToken)
        {
            int? status = null;
            if (Enum.TryParse(typeof(StoryboardProcessingStatus), request.Status, out object? parsedResult))
                status = (int)parsedResult;

            var paginatedVideoInformations = await _videoInformationRepository.GetAllPaginatedAsync(status, request.Page, request.PageSize);

            return new PaginationResult<VideoInformationVM>(
                paginatedVideoInformations.Page,
                paginatedVideoInformations.TotalPages,
                paginatedVideoInformations.PageSize,
                paginatedVideoInformations.ItemsCount,
                _mapper.Map<List<VideoInformationVM>>(paginatedVideoInformations.Data)
                );
        }
    }
}
