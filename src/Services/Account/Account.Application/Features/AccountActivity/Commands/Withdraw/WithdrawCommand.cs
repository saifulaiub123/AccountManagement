using MediatR;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class WithdrawCommand : IRequest<Unit>
    {
        public int TransactionAmount { get; set; }
    }
}
