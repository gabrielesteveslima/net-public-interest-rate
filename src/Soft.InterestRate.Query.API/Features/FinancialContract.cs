namespace Soft.InterestRate.Query.API.Features
{
    using System;

    public class FinancialContract
    {
        public Guid Id { get; set; }
        public string Type => "financial";
        public double InterestRate { get; set; }
    }
}