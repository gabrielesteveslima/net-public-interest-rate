﻿namespace Soft.InterestRate.API.Features.v1
{
    using System.Threading.Tasks;
    using Application.CalculateInterest;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/financas")]
    [Produces("application/json")]
    public class FinancialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("calculajuros")]
        public async Task<IActionResult> CalculateInterest([FromQuery] FinancialQueryParams queryParams)
        {
            var result =
                await _mediator.Send(new CalculateInterestCommand(queryParams.Amount, queryParams.Months,
                    queryParams.Currency));

            return Ok(result);
        }
    }
}