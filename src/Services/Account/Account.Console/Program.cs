using System;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Account.Application.Features.AccountActivity.Commands.Withdraw;
using Account.Application.Features.AccountActivity.Queries.GetStatement;
using Account.Application.Model;
using Account.Domain.Entities;
using System.Reflection;
using Account.Application;
using Account.Service;
using Account.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Account.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var serviceProvider = new ServiceCollection()
            //    .AddApplicationServices()
            var services = new ServiceCollection();
            IConfiguration Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
            ;
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddApplicationServices();
            services.AddServices();
            services.AddInfrastructureServices(Configuration);

            Initialize();

        }
        static void Initialize()
        {
            Console.WriteLine("What");
            //AutoMapper.Mapper.CreateMap<DepositCommand, Amount>().ReverseMap();
            //CreateMap<WithdrawCommand, Amount>().ReverseMap();
            //CreateMap<StatementVm, AccountActivity>().ReverseMap();
        }


    }
}
