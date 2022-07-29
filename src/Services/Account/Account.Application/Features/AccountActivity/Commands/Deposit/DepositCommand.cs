using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.Orders.Commands.CheckOutOrder
{
    public class DepositCommand : IRequest<Unit>
    {
        public int TransactionAmount { get; set; }
    }
}
