using Account.Domain.Common;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<AccountActivity>
    {
        Task<IEnumerable<AccountActivity>> GetOrderByUsername(string userName);
    }
}
