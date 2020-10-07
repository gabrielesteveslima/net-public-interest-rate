namespace Soft.InterestRate.API.Application.CalculateInterest.ACL
{
    using System;
    using Newtonsoft.Json;

    public class InterestRateResponse
    {
        public Guid Id { get; set; }
        public decimal InterestRate { get; set; }
    }
}