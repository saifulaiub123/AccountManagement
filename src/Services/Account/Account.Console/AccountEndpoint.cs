using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
