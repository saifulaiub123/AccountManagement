using MediatR;

namespace Account.ConsoleApp
{
    public class AccountEndpoint
    {
        private readonly IMediator _mediator;

        public AccountEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
