using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Account.Domain.Entities;

namespace Account.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<AccountActivity> GetPreconfiguredOrders()
        {
            return new List<AccountActivity>
            {
                new AccountActivity() {UserName = "saiful", FirstName = "saiful", LastName = "Islam", EmailAddress = "saiful@gmail.com", AddressLine = "Bahcelievler", Country = "Bangladesh", TotalPrice = 350 }
            };
        }
    }
}
