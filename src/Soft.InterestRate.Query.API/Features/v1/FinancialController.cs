﻿namespace Soft.InterestRate.Query.API.Features.v1
{
    using System;
    using Domain;
    using Infrastructure.Logs;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/financas")]
    [Produces("application/json")]
    public class FinancialController : ControllerBase
    {
        private readonly ILogging _logging;

        public FinancialController(ILogging logging)
        {
            _logging = logging;
        }

        [HttpGet("taxajuros")]
        public FinancialContract Get()
        {
            var financial =
                new FinancialContract {Id = Guid.NewGuid(), InterestRate = Financial.InterestRate};

            _logging.Information(financial);
            return financial;
        }
    }
}