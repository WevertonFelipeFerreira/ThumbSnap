using MediatR;
using Microsoft.AspNetCore.Mvc;
using ThumbSnap.Application.ViewModels;
using ThumbSnap.Domain.Models;

namespace ThumbSnap.Application.Queries.GetAllPaginatedVideoInformation
{
    public class GetAllVideoInformationsQuery : IRequest<PaginationResult<VideoInformationVM>>
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; } = 1;

        [FromQuery(Name = "pageSize")]
        public int PageSize { get; set; } = 3;

        [FromQuery(Name = "status")]
        public string? Status { get; set; }
    }
}
