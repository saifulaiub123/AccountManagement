using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Account.Application.Contracts.Infrastructure;
using Account.Application.Model;
using Account.Application.Features.Orders.Commands.CheckOutOrder;
using Account.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IRepository;
using Account.Application.Contracts.Persistence.IService;

namespace Account.Application.Features.Orders.Commands.CheckoutOrder
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, Unit>
    {
        private readonly IAcountActivityService _accountActivityService;
        private readonly IMapper _mapper;
        private readonly ILogger<DepositCommandHandler> _logger;

        public DepositCommandHandler(IAcountActivityService accountActivityService, IMapper mapper, ILogger<DepositCommandHandler> logger)
        {
            _accountActivityService = accountActivityService;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var accountActivityEntity = _mapper.Map<Amount>(request);
            await _accountActivityService.Deposit(accountActivityEntity);
            return Unit.Value;

        }
    }
}
