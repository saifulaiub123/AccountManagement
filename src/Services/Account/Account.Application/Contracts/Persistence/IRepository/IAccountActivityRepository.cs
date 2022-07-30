using Account.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Account.Application.Contracts.Persistence.IRepository
{
    public interface IAccountActivityRepository : IAsyncRepository<AccountActivity>
    {
        Task<List<AccountActivity>> Statement();
        Task<AccountActivity> GetLatestActivity();
    }
}
