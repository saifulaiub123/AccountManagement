using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Account.Domain.Entities;
using Account.Infrastructure.Persistence;
using Account.Application.Model;
using Account.Application.Contracts.Persistence.IRepository;

namespace Account.Infrastructure.Repositories
{
    public class AccountActivityRepository : RepositoryBase<AccountActivity>, IAccountActivityRepository
    {
        public AccountActivityRepository(AccountContext dbContext) : base(dbContext)
        {
        }
        public async Task Deposit(AccountActivity accountActivity)
        {
            await _dbContext.AddAsync(accountActivity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task Withdraw(AccountActivity accountActivity)
        {
            await _dbContext.AccountActivity.AddAsync(accountActivity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AccountActivity>> Statement()
        {
            return await _dbContext.AccountActivity.Where(x => x.UserId == 1).OrderByDescending(x => x.CreatedDate).ToListAsync();
        }
        public async Task<AccountActivity> GetLatestActivity()
        {
            return await _dbContext.AccountActivity.Where(x => x.UserId == 1).OrderByDescending(y => y.CreatedDate).FirstOrDefaultAsync();
        }
    }
}