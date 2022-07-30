using FluentValidation;

namespace Account.Application.Features.AccountActivity.Commands.Withdraw
{
    public class DepositCommandValidator : AbstractValidator<DepositCommand>
    {
        public DepositCommandValidator()
        {
            RuleFor(x => x.TransactionAmount)
                .NotNull().WithMessage("Transaction amount is required.");
        }
    }
}
