namespace Soft.InterestRate.API.Domain
{
    using System;

    public static class FinancialExtensions
    {
        public static decimal TruncateInTwoPlaces(this decimal value)
        {
            return Math.Truncate(value * 100) / 100;
        }
    }
}