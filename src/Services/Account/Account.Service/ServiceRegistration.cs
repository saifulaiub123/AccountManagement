using Account.Application.Contracts.Persistence.IService;
using Account.Service.CoreServices;
using Microsoft.Extensions.DependencyInjection;

namespace Account.Service
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAcountService, AccountService>();
            return services;
        }
    }
}
