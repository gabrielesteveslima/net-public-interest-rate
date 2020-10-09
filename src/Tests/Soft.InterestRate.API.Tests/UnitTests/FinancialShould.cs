namespace Soft.InterestRate.API.Tests.UnitTests
{
    using System.Threading.Tasks;
    using Application.CalculateInterest.ACL;
    using Domain;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class FinancialShould
    {
        [SetUp]
        public void Setup()
        {
            _mock = new Mock<IInterestRateQueryApi>();
        }

        private Mock<IInterestRateQueryApi> _mock;

        [TestCase(200.20, 5, 210.41)]
        [TestCase(1000.50, 3, 1030.81)]
        [TestCase(5500.23, 13, 6259.77)]
        public async Task CalculateInterest(decimal amount, int months, decimal expectedResult)
        {
            _mock.Setup(s => s.GetInterestRateAsync()).ReturnsAsync(new decimal(0.01));

            var financial = new Financial(amount, months);
            var actualResult = await financial.CalculateInterest(_mock.Object);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}