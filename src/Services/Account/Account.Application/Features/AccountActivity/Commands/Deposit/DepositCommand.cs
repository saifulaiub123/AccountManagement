using MediatR;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class DepositCommand : IRequest<Unit>
    {
        public int TransactionAmount { get; set; }
    }
}
