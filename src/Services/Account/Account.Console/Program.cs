//using System;
//using Microsoft.Extensions.DependencyInjection;
//using AutoMapper;
//using Account.Application.Features.AccountActivity.Commands.Withdraw;
//using Account.Application.Features.AccountActivity.Queries.GetStatement;
//using Account.Application.Model;
//using Account.Domain.Entities;
//using System.Reflection;
//using Account.Application;
//using Account.Service;
//using Account.Infrastructure;
//using Microsoft.Extensions.Configuration;
//using Account.Application.Contracts.Persistence.IService;
//using Account.Service.CoreServices;
//using Account.Infrastructure.Persistence;
//using Microsoft.EntityFrameworkCore;
//using Account.Application.Contracts.Persistence.IRepository;
//using Account.Infrastructure.Repositories;

//namespace Account.ConsoleApp
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            try
//            {
//                Console.WriteLine("Hello World!");
//                IConfiguration Configuration = new ConfigurationBuilder()
//                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//                    .AddEnvironmentVariables()
//                    .AddCommandLine(args)
//                    .Build();
//                ;



//                RegisterServices(Configuration);
//                //var serviceProvider = new ServiceCollection()
//                //    .AddApplicationServices()
//                var services = new ServiceCollection();

//                //services.AddAutoMapper(Assembly.GetExecutingAssembly());
//                //services.AddApplicationServices();
//                //services.AddServices();
//                //services.AddInfrastructureServices(Configuration);


//                IServiceProvider serviceProvider = services.BuildServiceProvider();

//                var accountService = serviceProvider.GetService<IAcountService>();

//                accountService.Deposit(new Amount() { TransactionAmount = 500 });

//                Initialize();
//            }
//            catch(Exception ex)
//            {
//                var p = ex.Message;
//            }

//        }
//        static void Initialize()
//        {
//            Console.WriteLine("What");

//            //AutoMapper.Mapper.CreateMap<DepositCommand, Amount>().ReverseMap();
//            //CreateMap<WithdrawCommand, Amount>().ReverseMap();
//            //CreateMap<StatementVm, AccountActivity>().ReverseMap();
//        }

//        private static void RegisterServices(IConfiguration Configuration)
//        {


//            var services = new ServiceCollection();
//            services.AddAutoMapper(Assembly.GetExecutingAssembly());
//            services.AddScoped<IAcountService, AccountService>();

//            services.AddDbContext<AccountContext>(options =>
//                options.UseSqlServer(Configuration.GetConnectionString("AccountConnectionString")));
//            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
//            services.AddScoped<IAccountActivityRepository, AccountActivityRepository>();

//            IServiceProvider serviceProvider = services.BuildServiceProvider();
//            serviceProvider = services.BuildServiceProvider(true);
//        }


//    }
//}



using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using Account.Application.Contracts.Persistence.IService;
using Account.Service.CoreServices;
using Account.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Account.Application.Contracts.Persistence.IRepository;
using Account.Infrastructure.Repositories;
using Account.Application.Model;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Account.Domain.Entities;
using System.Collections.Generic;

namespace Account.ConsoleApp
{
    public class Program
    {
        private readonly IAccountService _accountService;


        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        public Program(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public void Run()
        {
            int amount = 0;
            int input = 0;
            while(true)
            {
                Console.WriteLine("\n\nPlease select the action");
                Console.WriteLine("1.Deposit Amount");
                Console.WriteLine("2.Withdraw Amount");
                Console.WriteLine("3.Get Statement");
                Console.WriteLine("4.Exit");

                input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    Console.WriteLine("Enter Amount");
                    amount = int.Parse(Console.ReadLine());
                    Task.Run(async () => await _accountService.Deposit(new Amount() { TransactionAmount = amount }));
                    //_accountService.Deposit(new Amount() { TransactionAmount = amount }).Wait();
                    Console.WriteLine("Deposited {0}", amount);
                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter Amount");
                    amount = int.Parse(Console.ReadLine());
                    Task.Run(async () => await _accountService.Withdraw(new Amount() { TransactionAmount = amount }));
                    //_accountService.Withdraw(new Amount() { TransactionAmount = amount }).Wait();
                    Console.WriteLine("Withdrawn {0}", amount);
                }
                else if (input == 3)
                {
                    var accountActivities = Task.Run(async () => await _accountService.Statement()).Result;
                    ShowStatement(accountActivities);
                }
                else if (input == 4)
                {
                    break;
                }
            }
            
            
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    IConfiguration Configuration = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .AddEnvironmentVariables()
                        .AddCommandLine(args)
                        .Build();
                    services.AddTransient<Program>();
                    services.AddScoped<IAccountService, AccountService>();
                    services.AddDbContext<AccountContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("AccountConnectionString")));
                    services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
                    services.AddScoped<IAccountActivityRepository, AccountActivityRepository>();
                });
        }
        private void ShowStatement(List<AccountActivity> accountActivity)
        {
            Console.WriteLine();
        }
    }
}