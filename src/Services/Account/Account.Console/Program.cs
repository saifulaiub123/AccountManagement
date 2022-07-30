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
using System.Reflection;
using AutoMapper;
using Account.Application.Mapping;
using System.Linq;

namespace Account.ConsoleApp
{
    public class Program
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;


        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
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
                    services.AddAutoMapper(typeof(MappingProfile));
                    services.AddTransient<Program>();
                    services.AddScoped<IAccountService, AccountService>();
                    services.AddDbContext<AccountContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("AccountConnectionString")));
                    services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
                    services.AddScoped<IAccountActivityRepository, AccountActivityRepository>();
                });
        }
        public Program(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
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
                    Console.WriteLine("Deposited {0}", amount);
                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter Amount");
                    amount = int.Parse(Console.ReadLine());
                    Task.Run(async () => await _accountService.Withdraw(new Amount() { TransactionAmount = amount }));
                    Console.WriteLine("Withdrawn {0}", amount);
                }
                else if (input == 3)
                {
                    var result = Task.Run(async () => await _accountService.Statement()).Result;
                    var statement = _mapper.Map<List<Statement>>(result);
                    ShowStatement(statement);
                }
                else if (input == 4)
                {
                    break;
                }
            }
            
            
        }

       
        private void ShowStatement(List<Statement> statements)
        {
            if(statements.Count > 8)
            {
                var st = statements.First();
                Console.WriteLine("{0}  || {1}  || {2}", nameof(st.Date), nameof(st.Amount), nameof(st.Balance));
                foreach(var statement in statements)
                {
                    Console.WriteLine("{0}  || {1}  || {2}", statement.Date.ToShortDateString(), statement.Amount, statement.Balance);
                }    
            }
            else
            {
                Console.WriteLine("No transaction found");
            }
            
        }
    }
}