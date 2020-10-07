namespace Soft.InterestRate.Query.API.Features.v1
{
    using System;
    using Infrastructure.Logs;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
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
            var financial = new FinancialContract {Id = Guid.NewGuid(), InterestRate = InterestRate.Tax};

            _logging.Information(financial);
            return financial;
        }
    }
}