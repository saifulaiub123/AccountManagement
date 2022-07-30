using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Account.Infrastructure.Persistence;
using Account.Infrastructure.Repositories;
using Account.Application.Contracts.Persistence.IRepository;

namespace Account.Infrastructure
{
    public static class InfraStructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AccountConnectionString")));
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IAccountActivityRepository, AccountActivityRepository>();

            return services;
        }
    }
}
