using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Account.Application.Contracts.Persistence;
using Account.Domain.Entities;
using Account.Infrastructure.Persistence;

namespace Account.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<AccountActivity>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<AccountActivity>> GetOrderByUsername(string userName)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.UserName == userName)
                                .ToListAsync();
            return orderList;
        }
    }
}