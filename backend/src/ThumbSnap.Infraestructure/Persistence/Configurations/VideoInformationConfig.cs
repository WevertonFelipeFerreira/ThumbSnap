using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Infraestructure.Persistence.Configurations
{
    public class VideoInformationConfig : IEntityTypeConfiguration<VideoInformation>
    {
        public void Configure(EntityTypeBuilder<VideoInformation> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
