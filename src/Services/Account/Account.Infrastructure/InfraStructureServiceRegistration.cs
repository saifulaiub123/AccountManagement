using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Account.Application.Contracts.Infrastructure;
using Account.Application.Model;
using Account.Infrastructure.Mail;
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

            services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));

            return services;
        }
    }
}
