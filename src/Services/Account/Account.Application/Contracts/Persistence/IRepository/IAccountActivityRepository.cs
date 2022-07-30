using Account.Application.Model;
using Account.Domain.Common;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Contracts.Persistence.IRepository
{
    public interface IAccountActivityRepository : IAsyncRepository<AccountActivity>
    {
        Task<List<AccountActivity>> Statement();
        Task<AccountActivity> GetLatestActivity();
    }
}
