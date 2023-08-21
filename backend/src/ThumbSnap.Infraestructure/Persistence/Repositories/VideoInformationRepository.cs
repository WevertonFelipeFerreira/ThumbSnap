using ThumbSnap.Domain.Entities;
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

        public Task UpdateAsync(VideoInformation entity)
        {
            throw new NotImplementedException();
        }
    }
}
