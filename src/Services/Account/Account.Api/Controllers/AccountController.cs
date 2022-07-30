using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Account.Application.Features.AccountActivity.Commands.Withdraw;
using Account.Application.Features.AccountActivity.Queries.GetStatement;

namespace Account.Api.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Deposit")]
        public async Task<ActionResult<int>> Deposit([FromBody] DepositCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("Withdraw")]
        public async Task<ActionResult> Withdraw([FromBody] WithdrawCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("Statement")]
        public async Task<ActionResult> Statement()
        {
            var command = new GetStatementQuery();
            var result =  await _mediator.Send(command);
            return Ok(result);
        }
    }
}
