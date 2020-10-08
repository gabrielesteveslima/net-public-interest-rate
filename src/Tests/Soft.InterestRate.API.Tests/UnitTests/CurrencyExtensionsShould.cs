namespace Soft.InterestRate.API.Tests.UnitTests
{
    using Domain;
    using NUnit.Framework;

    [TestFixture]
    public class CurrencyExtensionsShould
    {
        [Test,
         TestCaseSource(typeof(TestsCasesFactory), nameof(TestsCasesFactory.FormatToBrlCurrencyTestCases))]
        public string FormatValueToBrlCurrency(decimal value)
        {
            return value.FormatToCurrency(CurrencyDisplay.PtBr);
        }

        [Test,
         TestCaseSource(typeof(TestsCasesFactory), nameof(TestsCasesFactory.FormatToUsdCurrencyTestCases))]
        public string FormatValueToUsdCurrency(decimal value)
        {
            return value.FormatToCurrency(CurrencyDisplay.EnUs);
        }

        [Test,
         TestCaseSource(typeof(TestsCasesFactory), nameof(TestsCasesFactory.TruncateAmountValueTestCases))]
        public decimal TruncateInterestInTwoPlaces(decimal value)
        {
            return value.TruncateInTwoPlaces();
        }
    }
}