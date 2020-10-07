namespace Soft.InterestRate.API.Application.CalculateInterest
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using ACL;
    using Domain;
    using Features;
    using Infrastructure.Logs;

    public class CalculateInterestHandler : ICommandHandler<CalculateInterestCommand, FinancialContract>
    {
        private readonly ILogging _logging;
        private readonly IInterestRateQueryApi _interestRateQueryApi;
        
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
            
                Financial financial = new Financial(request.Amount, request.Months);
            
                var interestRate = await _interestRateQueryApi.GetInterestRate(cancellationToken);
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