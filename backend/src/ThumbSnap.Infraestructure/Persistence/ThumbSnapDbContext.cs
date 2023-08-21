using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ThumbSnap.Domain.Entities;

namespace ThumbSnap.Infraestructure.Persistence
{
    public class ThumbSnapDbContext : DbContext
    {
        public ThumbSnapDbContext(DbContextOptions<ThumbSnapDbContext> options) : base(options)
        {

        }
        public DbSet<VideoInformation> VideoInformations { get; set; }
        public DbSet<StoryboardSnap> StoryboardSnaps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
