namespace Soft.InterestRate.Query.API.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class FinancialController : ControllerBase
    {
        private readonly ILogger<FinancialController> _logger;

        public FinancialController(ILogger<FinancialController> logger)
        {
            _logger = logger;
        }

        [HttpGet("taxajuros")]
        public IEnumerable<InterestRate> Get()
        {
            return new[] {new InterestRate()};
        }
    }
}