using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
