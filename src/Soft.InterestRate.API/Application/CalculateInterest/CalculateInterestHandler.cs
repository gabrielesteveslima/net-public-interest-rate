namespace Soft.InterestRate.API.Application.Commands
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain;
    using Features;
    using Flurl;
    using Flurl.Http;
    using Infrastructure.Logs;
    using Microsoft.Extensions.Options;

    public class CalculateInterestHandler : ICommandHandler<CalculateInterestCommand, FinancialContract>
    {
        private readonly InterestRateApiQueryConfig _interestRateApiQueryConfig;
        private readonly ILogging _logging;

        public CalculateInterestHandler(IOptions<InterestRateApiQueryConfig> interestRateApiQueryConfig,
            ILogging logging)
        {
            _interestRateApiQueryConfig = interestRateApiQueryConfig.Value;
            _logging = logging;
        }


        public async Task<FinancialContract> Handle(CalculateInterestCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                _logging.Information(new {details = "calculate interest", entity = request});

                Financial financial = new Financial(request.Amount, request.Months);

                double interestRate = (double)await _interestRateApiQueryConfig.Host
                    .AppendPathSegment(_interestRateApiQueryConfig.Path)
                    .ConfigureRequest(setup =>
                    {
                        setup.BeforeCall = call =>
                        {
                            _logging.Information(new
                            {
                                details = "calling InterestRateApiQuery",
                                request = new {requestUri = call.Request.RequestUri, boby = call.Request.Content}
                            });
                        };
                    })
                    .GetAsync(cancellationToken)
                    .ReceiveJson<object>();

                decimal interestResult = financial.CalculateInterest(interestRate);

                return new FinancialContract
                {
                    Id = financial.Id,
                    Amount = financial.Amount,
                    Months = financial.Months,
                    SimpleInterest = interestResult
                };
            }
            catch (Exception e)
            {
                _logging.Error(new
                {
                    details = "calculate interest",
                    entity = request,
                    exception = new {inner = e.InnerException, message = e.Message}
                });

                throw;
            }
        }
    }
}