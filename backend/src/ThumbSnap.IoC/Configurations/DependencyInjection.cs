using Microsoft.Extensions.DependencyInjection;
using ThumbSnap.Application.Services;
using ThumbSnap.Domain.Repositories;
using ThumbSnap.Domain.Services;
using ThumbSnap.Infraestructure.Persistence.Repositories;
using ThumbSnap.Infraestructure.Storage;

namespace ThumbSnap.IoC.Configurations
{
    public static class DependencyInjection
    {
        public static void AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IVideoEngine, VideoEngine>();
            services.AddScoped<IVideoInformationRepository, VideoInformationRepository>();
            services.AddScoped<IStorageService, StorageService>();
        }
    }
}
