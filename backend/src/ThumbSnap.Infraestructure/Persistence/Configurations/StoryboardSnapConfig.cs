using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Infraestructure.Persistence.Configurations
{
    public class StoryboardSnapConfig : IEntityTypeConfiguration<StoryboardSnap>
    {
        public void Configure(EntityTypeBuilder<StoryboardSnap> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.VideoInformation)
                   .WithMany(x => x.Snaps)
                   .HasForeignKey(x => x.VideoId);

            builder.HasQueryFilter(x => !x.DeletedAt.HasValue);
        }
    }
}
