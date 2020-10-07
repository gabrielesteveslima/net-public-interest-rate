﻿namespace Soft.InterestRate.API.Application.Commands
{
    using Features;

    public class CalculateInterestCommand : CommandBase<FinancialContract>
    {
        public CalculateInterestCommand(decimal amount, int months)
        {
            Amount = amount;
            Months = months;
        }

        public decimal Amount { get; }
        public int Months { get; }
    }
}