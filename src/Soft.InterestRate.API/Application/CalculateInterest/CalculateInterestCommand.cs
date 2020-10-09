namespace Soft.InterestRate.API.Application.CalculateInterest
{
    using Domain;

    public class CalculateInterestCommand : CommandBase<FinancialContract>
    {
        public CalculateInterestCommand(decimal amount, int months, CurrencyDisplay? currencyDisplay)
        {
            Amount = amount;
            Months = months;
            CurrencyDisplay = currencyDisplay;
        }

        public decimal Amount { get; }
        public int Months { get; }
        public CurrencyDisplay? CurrencyDisplay { get; }
    }
}