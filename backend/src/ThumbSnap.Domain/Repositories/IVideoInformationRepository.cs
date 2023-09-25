using System.Linq.Expressions;
using ThumbSnap.Domain.Entities;
using ThumbSnap.Domain.Models;

namespace ThumbSnap.Domain.Repositories
{
    public interface IVideoInformationRepository
    {
        Task AddAsync(VideoInformation entity);
        Task<PaginationResult<VideoInformation>> GetAllPaginatedAsync(int? status, int page, int pageSize);
        Task<IEnumerable<VideoInformation>> GetAsync(Expression<Func<VideoInformation, bool>> predicate, string? navigationPropertyPath = null);
        Task UpdateAsync(VideoInformation entity);
    }
}