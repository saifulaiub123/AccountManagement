using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Account.Application.Contracts.Persistence.IService;

namespace Account.Application.Features.AccountActivity.Queries.GetStatement
{
    public class GetStatementQueryHandler : IRequestHandler<GetStatementQuery, List<StatementVm>>
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public GetStatementQueryHandler(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<List<StatementVm>> Handle(GetStatementQuery request, CancellationToken cancellationToken)
        {
            var statement = await _accountService.Statement();
            var accountActivityEntity = _mapper.Map<List<StatementVm>>(statement);
            
            return accountActivityEntity;
        }
    }
}
