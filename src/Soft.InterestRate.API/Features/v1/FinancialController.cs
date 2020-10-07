﻿namespace Soft.InterestRate.API.Features.v1
{
    using System.Threading.Tasks;
    using Application.CalculateInterest;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class FinancialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FinancialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("calculajuros")]
        public async Task<IActionResult> CalculateInterest([FromQuery] FinancialContract request)
        {
            var result = await _mediator.Send(new CalculateInterestCommand(request.Amount, request.Months));

            return Ok(result);
        }
    }
}