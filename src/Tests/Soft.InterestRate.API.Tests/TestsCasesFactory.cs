namespace Soft.InterestRate.API.Tests
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class TestsCasesFactory
    {
        public static IEnumerable<TestCaseData> FormatToBrlCurrencyTestCases
        {
            get
            {
                yield return new TestCaseData(new decimal(100)).Returns("R$ 100,00");
                yield return new TestCaseData(new decimal(100.50)).Returns("R$ 100,50");
                yield return new TestCaseData(new decimal(100.5)).Returns("R$ 100,50");
            }
        }

        public static IEnumerable<TestCaseData> FormatToUsdCurrencyTestCases
        {
            get
            {
                yield return new TestCaseData(new decimal(100)).Returns("$100.00");
                yield return new TestCaseData(new decimal(100.50)).Returns("$100.50");
                yield return new TestCaseData(new decimal(100.5)).Returns("$100.50");
            }
        }

        public static IEnumerable<TestCaseData> TruncateAmountValueTestCases
        {
            get
            {
                yield return new TestCaseData(new decimal(100.02901323)).Returns(new decimal(100.02));
                yield return new TestCaseData(new decimal(100.108912)).Returns(new decimal(100.1));
                yield return new TestCaseData(new decimal(100)).Returns(new decimal(100.0));
            }
        }
    }
}