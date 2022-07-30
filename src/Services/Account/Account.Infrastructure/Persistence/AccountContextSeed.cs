using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Account.Domain.Entities;

namespace Account.Infrastructure.Persistence
{
    public class AccountContextSeed
    {
        public static async Task SeedAsync(AccountContext accountContext, ILogger<AccountContextSeed> logger)
        {
            if (!accountContext.AccountActivity.Any())
            {
                accountContext.Users.AddRange(GetPreconfiguredUsers());
                await accountContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(AccountContext).Name);
            }
        }

        private static Users GetPreconfiguredUsers()
        {
            return new Users
            {
                UserName = "saiful", 
                Name = "saiful",
                Email = "saiful@gmail.com", 
                Mobile = "015455555"
            };
        }
    }
}
