using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class DepositCommand : IRequest<Unit>
    {
        public int TransactionAmount { get; set; }
    }
}
