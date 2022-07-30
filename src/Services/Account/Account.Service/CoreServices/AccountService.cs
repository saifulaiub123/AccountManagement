using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IRepository;
using Account.Application.Contracts.Persistence.IService;
using Account.Application.Model;
using Account.Domain.Entities;

namespace Account.Service.CoreServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountActivityRepository _accountActivityRepository;
        public AccountService(IAccountActivityRepository accountActivityRepository)
        {
            _accountActivityRepository = accountActivityRepository;
        }
        public async Task Deposit(Amount amount)
        {
            try
            {
                var accountActivity = new AccountActivity
                {
                    TransactionAmount = amount.TransactionAmount,
                    Balance = amount.TransactionAmount,
                    UserId = 1
                };
                var latestActivity = await _accountActivityRepository.GetLatestActivity();

                if (latestActivity != null)
                {
                    accountActivity.Balance += latestActivity.Balance;
                }

                await _accountActivityRepository.AddAsync(accountActivity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task Withdraw(Amount amount)
        {
            var accountActivity = new AccountActivity
            {
                TransactionAmount = -amount.TransactionAmount,
                Balance = amount.TransactionAmount,
                UserId = 1
            };
            var latestActivity = await _accountActivityRepository.GetLatestActivity();

            if (latestActivity != null)
            {
                accountActivity.Balance = latestActivity.Balance - accountActivity.Balance;
            }

            await _accountActivityRepository.AddAsync(accountActivity);
        }


        public async Task<List<AccountActivity>> Statement()
        {
            return await _accountActivityRepository.Statement();
        }

        
    }
}
