namespace Soft.InterestRate.API.Features
{
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    public class FinancialRequest
    {
        [FromQuery(Name = "valorInicial")] public decimal Amount { get; set; }

        [FromQuery(Name = "meses")] public int Months { get; set; }

        [FromQuery(Name = "currency")] public CurrencyDisplay? Currency { get; set; }
    }
}