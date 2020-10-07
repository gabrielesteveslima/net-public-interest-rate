namespace Soft.InterestRate.API.Features
{
    using System.ComponentModel.DataAnnotations;
    using Domain;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class FinancialRequest
    {
        [FromQuery(Name = "valorInicial")] public decimal Amount { get; set; }

        [FromQuery(Name = "meses")] public int Months { get; set; }

        [FromQuery(Name = "moeda")]
        public CurrencyDisplay? Currency { get; set; }
    }
}