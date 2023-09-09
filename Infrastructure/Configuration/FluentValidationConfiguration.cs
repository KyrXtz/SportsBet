
namespace SportsBet.Infrastructure.Configuration
{
    public static class FluentValidationConfiguration
    {
        public static IServiceCollection AddFluentValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(DefaultApplicationModule).Assembly);
            
            return services;
        }
    }
}

