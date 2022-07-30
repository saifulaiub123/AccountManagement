using FluentValidation;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class WithdrawCommandValidator : AbstractValidator<WithdrawCommand>
    {
        public WithdrawCommandValidator()
        {
            RuleFor(x => x.TransactionAmount)
                .NotNull().WithMessage("Transaction amount is required.");
               
        }
    }
}
