namespace Soft.InterestRate.API.Tests.UnitTests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Application.CalculateInterest.ACL;
    using FluentAssertions;
    using Flurl.Http.Testing;
    using Infrastructure.Logs;
    using Microsoft.Extensions.Options;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class InterestRateQueryApiShould
    {
        [SetUp]
        public void Setup()
        {
            _loggingMock = new Mock<ILogging>();
            _interestRateApiQueryConfigMock = Options.Create(new InterestRateApiQueryConfig
            {
                Host = "https://run.mocky.io/v3/b46c1b1b-9af1-454e-8a5c-167429ead97e", Path = "taxajuros"
            });

            _interestRateQueryApi =
                new InterestRateQueryApi(_interestRateApiQueryConfigMock, _loggingMock.Object);
        }

        private IInterestRateQueryApi _interestRateQueryApi;
        private IOptions<InterestRateApiQueryConfig> _interestRateApiQueryConfigMock;
        private Mock<ILogging> _loggingMock;

        [Test]
        public async Task Test_Some_Http_Calling_Method()
        {
            using var httpTest = new HttpTest();

            var result = await _interestRateQueryApi.GetInterestRateAsync();

            httpTest
                .ShouldHaveCalled(
                    $"{_interestRateApiQueryConfigMock.Value.Host}/{_interestRateApiQueryConfigMock.Value.Path}")
                .With(x => x.Response.IsSuccessStatusCode)
                .WithVerb(HttpMethod.Get)
                .Times(1);

            result.Should().NotBe(null).And.BeOfType(typeof(decimal));
        }
    }
}