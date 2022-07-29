using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Account.Application.Exceptions;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IRepository;
using Account.Application.Contracts.Persistence.IService;
using Account.Application.Model;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, Unit>
    {
        private readonly IAcountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<WithdrawCommandHandler> _logger;

        public WithdrawCommandHandler(IAcountService accountService, IMapper mapper, ILogger<WithdrawCommandHandler> logger)
        {
            _accountService = accountService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(WithdrawCommand request, CancellationToken cancellationToken)
        {
            var accountActivityEntity = _mapper.Map<Amount>(request);
            await _accountService.Withdraw(accountActivityEntity);
            return Unit.Value;
        }
    }
}
