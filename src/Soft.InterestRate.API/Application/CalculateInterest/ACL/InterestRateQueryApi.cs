namespace Soft.InterestRate.API.Application.CalculateInterest.ACL
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Flurl;
    using Flurl.Http;
    using Flurl.Http.Configuration;
    using Infrastructure.Logs;
    using JsonApiSerializer;
    using Microsoft.Extensions.Options;

    public class InterestRateQueryApi : IInterestRateQueryApi
    {
        private readonly InterestRateApiQueryConfig _interestRateApiQueryConfig;
        private readonly ILogging _logging;

        public InterestRateQueryApi(IOptions<InterestRateApiQueryConfig> interestRateApiQueryConfig, ILogging logging)
        {
            _interestRateApiQueryConfig = interestRateApiQueryConfig.Value;
            _logging = logging;
        }

        public async Task<decimal> GetInterestRateAsync()
        {
            try
            {
                InterestRateResponse response = await _interestRateApiQueryConfig.Host
                    .AppendPathSegment(_interestRateApiQueryConfig.Path)
                    .ConfigureRequest(setup =>
                    {
                        setup.JsonSerializer = new NewtonsoftJsonSerializer(new JsonApiSerializerSettings());
                        setup.BeforeCall = call =>
                        {
                            _logging.Information(new
                            {
                                details = "calling InterestRateApiQuery",
                                request = new {requestUri = call.Request.RequestUri, boby = call.Request.Content}
                            });
                        };
                    })
                    .GetAsync()
                    .ReceiveJson<InterestRateResponse>();

                return response.InterestRate;
            }
            catch (Exception e)
            {
                _logging.Error(new
                {
                    details = "get interest rate", exception = new {inner = e.InnerException, message = e.Message}
                });

                throw;
            }
        }
    }
}