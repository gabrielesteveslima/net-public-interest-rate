namespace Soft.InterestRate.API.Features
{
    using System;
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    public class FinancialContract
    {
        public Guid Id { get; set; }
        public string Type => "financial";

        [FromQuery(Name = "valorInicial")] public decimal Amount { get; set; }

        [FromQuery(Name = "meses")] public int Months { get; set; }

        [FromQuery(Name = "currency")] public CurrencyDisplay? Currency { get; set; }

        public DisplayValuesContract ValuesInCurrency { get; set; }

        public decimal SimpleInterest { get; set; }
    }

    public class DisplayValuesContract
    {
        public string Type { get; set; }
        public string AmountCurrency { get; set; }
        public string SimpleInterestCurrency { get; set; }
    }
}