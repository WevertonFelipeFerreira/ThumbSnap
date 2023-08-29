using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ThumbSnap.Application.Validators;

namespace ThumbSnap.IoC.Configurations
{
    public static class FluentValidation
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining(typeof(CreateVideoInformationCommandValidator));

            return services;
        }
    }
}
