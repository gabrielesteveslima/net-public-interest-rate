namespace Soft.InterestRate.API.Application.CalculateInterest
{
    using FluentValidation;

    public class CalculateInterestValidator : AbstractValidator<CalculateInterestCommand>
    {
        public CalculateInterestValidator()
        {
            RuleFor(x => x.Amount).NotEmpty().OverridePropertyName("valorInicial");
            RuleFor(x => x.Months).NotEmpty().OverridePropertyName("meses");
            RuleFor(x => x.CurrencyDisplay).IsInEnum().OverridePropertyName("moeda");
        }
    }
}