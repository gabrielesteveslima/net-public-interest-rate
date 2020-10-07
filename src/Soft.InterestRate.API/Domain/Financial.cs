namespace Soft.InterestRate.API
{
    using System;

    public class Financial
    {
        public Financial(decimal amount, int months)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            Months = months;
        }

        public Guid Id { get; private set; }
        public decimal Amount { get; private set; }
        public int Months { get; private set; }

        public decimal CalculateInterest()
        {
            var interestRate = 0.01;
            var simpleInterestTruncated =
                Decimal.Multiply(Amount, (decimal)Math.Pow(1 + interestRate, Months));

            return simpleInterestTruncated.TruncateInTwoPlaces();
        }
    }

    public static class FinancialExtensions
    {
        public static decimal TruncateInTwoPlaces(this decimal value)
        {
            return Math.Truncate(value * 100) / 100;
        }
    }
}