using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Account.Application.Model;

namespace Account.Application.Contracts.Persistence.IService
{
    public interface IAcountService
    {
        Task Deposit(Amount amount);
        Task Withdraw(Amount amount);
        Task Statement();
    }
}
