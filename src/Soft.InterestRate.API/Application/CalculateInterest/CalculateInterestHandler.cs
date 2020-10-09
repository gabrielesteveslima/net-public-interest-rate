namespace Soft.InterestRate.API.Application.CalculateInterest
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ACL;
    using Domain;
    using Infrastructure.Logs;

    public class CalculateInterestHandler : ICommandHandler<CalculateInterestCommand, FinancialContract>
    {
        private readonly IInterestRateQueryApi _interestRateQueryApi;
        private readonly ILogging _logging;

        public CalculateInterestHandler(ILogging logging, IInterestRateQueryApi interestRateQueryApi)
        {
            _logging = logging;
            _interestRateQueryApi = interestRateQueryApi;
        }

        public async Task<FinancialContract> Handle(CalculateInterestCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                _logging.Information(new {details = "calculate interest", entity = request});

                var financial = new Financial(request.Amount, request.Months);
                var interestResult = await financial.CalculateInterest(_interestRateQueryApi);

                var currencyType = request.CurrencyDisplay ?? CurrencyDisplay.PtBr;

                return new FinancialContract
                {
                    Id = financial.Id,
                    Amount = financial.Amount,
                    Months = financial.Months,
                    SimpleInterest = interestResult,
                    ValuesInCurrency = new DisplayValuesContract
                    {
                        Type = currencyType.ToString(),
                        AmountCurrency =
                            financial.Amount.FormatToCurrency(currencyType),
                        SimpleInterestCurrency = interestResult.FormatToCurrency(currencyType)
                    }
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