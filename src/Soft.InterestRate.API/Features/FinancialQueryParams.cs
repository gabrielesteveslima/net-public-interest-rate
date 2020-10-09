namespace Soft.InterestRate.API.Features
{
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    public class FinancialQueryParams
    {
        [FromQuery(Name = "valorInicial")] public decimal Amount { get; set; }

        [FromQuery(Name = "meses")] public int Months { get; set; }

        [FromQuery(Name = "moeda")] public CurrencyDisplay? Currency { get; set; }
    }
}