namespace Soft.InterestRate.API.Tests.UnitTests
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.CalculateInterest.ACL;
    using Flurl.Http.Testing;
    using Infrastructure.Logs;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class InterestRateQueryApiShould
    {
        private IInterestRateQueryApi _interestRateQueryApi;
        private Mock<IOptions<InterestRateApiQueryConfig>> _interestRateApiQueryConfigMock;
        private Mock<ILogging> _loggingMock;

        [SetUp]
        public void Setup()
        {
            _loggingMock = new Mock<ILogging>();
            _interestRateApiQueryConfigMock = new Mock<IOptions<InterestRateApiQueryConfig>>();

            _interestRateQueryApi =
                new InterestRateQueryApi(_interestRateApiQueryConfigMock.Object, _loggingMock.Object);
        }

        [Test]
        public async Task Test_Some_Http_Calling_Method()
        {
            using var httpTest = new HttpTest();

            httpTest
                .ShouldHaveCalled("*")
                .WithVerb(HttpMethod.Get)
                .Times(1);

            await _interestRateQueryApi.GetInterestRateAsync();
        }
    }
}