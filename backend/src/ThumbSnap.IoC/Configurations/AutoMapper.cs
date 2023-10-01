using Microsoft.Extensions.DependencyInjection;
using ThumbSnap.Application.Mappers;

namespace ThumbSnap.IoC.Configurations
{
    public static class AutoMapper
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services is null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(cfg => cfg.ShouldUseConstructor = ci => !ci.IsPrivate,
                                          typeof(ModelToEntityProfile),
                                          typeof(EntityToModelProfile),
                                          typeof(DtoToEntityModelProfile)
                                          );
            return services;
        }
    }
}
