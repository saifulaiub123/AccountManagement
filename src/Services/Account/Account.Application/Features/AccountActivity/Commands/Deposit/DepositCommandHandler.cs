using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Account.Application.Model;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IRepository;
using Account.Application.Contracts.Persistence.IService;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, Unit>
    {
        private readonly IAcountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<DepositCommandHandler> _logger;

        public DepositCommandHandler(IAcountService accountService, IMapper mapper, ILogger<DepositCommandHandler> logger)
        {
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var accountActivityEntity = _mapper.Map<Amount>(request);
            await _accountService.Deposit(accountActivityEntity);
            return Unit.Value;

        }
    }
}
