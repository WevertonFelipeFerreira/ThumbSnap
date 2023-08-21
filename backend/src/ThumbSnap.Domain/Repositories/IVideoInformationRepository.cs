using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Domain.Repositories
{
    public interface IVideoInformationRepository
    {
        Task AddAsync(VideoInformation entity);
        Task UpdateAsync(VideoInformation entity);
    }
}