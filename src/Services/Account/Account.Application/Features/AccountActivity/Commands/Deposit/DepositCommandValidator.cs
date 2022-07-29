using FluentValidation;
using Account.Application.Features.Orders.Commands.CheckOutOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features.Orders.Commands.CheckoutOrder
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
