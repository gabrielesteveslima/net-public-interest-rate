namespace Soft.InterestRate.API.Features
{
    using System;
    using Microsoft.AspNetCore.Mvc;

    public class FinancialContract
    {
        public Guid Id { get; set; }
        public string Type => "financial";

        [FromQuery(Name = "valorInicial")] public decimal Amount { get; set; }

        [FromQuery(Name = "meses")] public int Months { get; set; }

        public decimal SimpleInterest { get; set; }
    }
}