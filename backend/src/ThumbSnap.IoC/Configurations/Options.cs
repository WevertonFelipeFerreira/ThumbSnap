using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThumbSnap.Infraestructure.Storage;

namespace ThumbSnap.IoC.Configurations
{
    public static class Options
    {
        public static IServiceCollection AddOptionsConfiguration(this IServiceCollection services, IConfiguration cfg)
        {
            services.Configure<StorageConfig>(cfg.GetSection(StorageConfig.STORAGE_CONFIG));

            return services;
        }
    }
}
