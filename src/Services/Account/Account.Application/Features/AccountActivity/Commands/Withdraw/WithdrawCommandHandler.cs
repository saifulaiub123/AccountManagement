using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IService;
using Account.Application.Model;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class WithdrawCommandHandler : IRequestHandler<WithdrawCommand, Unit>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly ILogger<WithdrawCommandHandler> _logger;

        public WithdrawCommandHandler(IAccountService accountService, IMapper mapper, ILogger<WithdrawCommandHandler> logger)
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
