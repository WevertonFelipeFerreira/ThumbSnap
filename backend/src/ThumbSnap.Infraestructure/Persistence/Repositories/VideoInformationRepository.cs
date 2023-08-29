using ThumbSnap.Domain.Entities;
using ThumbSnap.Domain.Enums;
using ThumbSnap.Domain.Models;
using ThumbSnap.Domain.Repositories;

namespace ThumbSnap.Infraestructure.Persistence.Repositories
{
    public class VideoInformationRepository : IVideoInformationRepository
    {
        private readonly ThumbSnapDbContext _dbContext;
        public VideoInformationRepository(ThumbSnapDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(VideoInformation entity)
        {
            await _dbContext.VideoInformations.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PaginationResult<VideoInformation>> GetAllPaginatedAsync(int? status, int page, int pageSize)
        {
            IQueryable<VideoInformation> videoInformations = _dbContext.VideoInformations;

            if (status is not null)
                videoInformations = videoInformations.Where(x => x.StoryboardProcessingStatus == (StoryboardProcessingStatus)status);

            return await videoInformations.GetPaged(page, pageSize);
        }

        public Task UpdateAsync(VideoInformation entity)
        {
            throw new NotImplementedException();
        }
    }
}
