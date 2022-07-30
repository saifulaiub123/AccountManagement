using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Application.Model;
using Account.Domain.Entities;

namespace Account.Application.Contracts.Persistence.IService
{
    public interface IAccountService
    {
        Task Deposit(Amount amount);
        Task Withdraw(Amount amount);
        Task<List<AccountActivity>>Statement();
    }
}
