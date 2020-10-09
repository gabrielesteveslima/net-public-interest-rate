namespace Soft.InterestRate.API.Domain
{
    using System;
    using System.Threading.Tasks;
    using Application.CalculateInterest.ACL;

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

        public async Task<decimal> CalculateInterest(IInterestRateQueryApi interestRateQueryApi)
        {
            var interestRate = await interestRateQueryApi.GetInterestRateAsync();

            var simpleInterest =
                Decimal.Multiply(Amount, (decimal)Math.Pow((double)(1 + interestRate), Months));

            return simpleInterest.TruncateInTwoPlaces();
        }
    }
}