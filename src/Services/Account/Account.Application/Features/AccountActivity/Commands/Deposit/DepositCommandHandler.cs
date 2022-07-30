using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Account.Application.Model;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IService;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class DepositCommandHandler : IRequestHandler<DepositCommand, Unit>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<DepositCommandHandler> _logger;

        public DepositCommandHandler(IAccountService accountService, IMapper mapper, ILogger<DepositCommandHandler> logger)
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
