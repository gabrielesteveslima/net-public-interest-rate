namespace Soft.InterestRate.API.Domain
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

        public Guid Id { get; }
        public decimal Amount { get; }
        public int Months { get; }

        public decimal CalculateInterest(decimal interestRate)
        {
            decimal simpleInterest =
                Decimal.Multiply(Amount, (decimal)Math.Pow((double)(1 + interestRate), Months));

            return simpleInterest.TruncateInTwoPlaces();
        }
    }
}