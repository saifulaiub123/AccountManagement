using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
