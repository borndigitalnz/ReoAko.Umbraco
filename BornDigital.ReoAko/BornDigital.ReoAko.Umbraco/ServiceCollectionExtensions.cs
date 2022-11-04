using BornDigital.ReoAko.Api;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BornDigital.ReoAko.Umbraco
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddReoAkoServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IReoAkoService, ReoAkoService>();

            services.Configure<ReoAkoSettings>(configuration.GetSection("ReoAko"));
            return services;
        }
    }
}
