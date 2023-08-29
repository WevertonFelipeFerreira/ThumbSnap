using ThumbSnap.Domain.Entities;
using ThumbSnap.Domain.Models;

namespace ThumbSnap.Domain.Repositories
{
    public interface IVideoInformationRepository
    {
        Task AddAsync(VideoInformation entity);
        Task<PaginationResult<VideoInformation>> GetAllPaginatedAsync(int? status, int page, int pageSize);
        Task UpdateAsync(VideoInformation entity);
    }
}