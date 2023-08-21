using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ThumbSnap.Infraestructure.Persistence;

namespace ThumbSnap.IoC.Configurations
{
    public static class DbContext
    {
        public static void AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionsString = configuration.GetConnectionString("ThumbSnapCs");
            if (string.IsNullOrEmpty(connectionsString))
                throw new InvalidOperationException("Connection string not found");

            services.AddDbContext<ThumbSnapDbContext>(options => options.UseSqlServer(connectionsString));
        }
    }
}
