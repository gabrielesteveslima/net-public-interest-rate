namespace Soft.InterestRate.API.Application.CalculateInterest
{
    using FluentValidation;

    public class CalculateInterestValidator : AbstractValidator<CalculateInterestCommand>
    {
        public CalculateInterestValidator()
        {
            RuleFor(x => x.Amount).NotEmpty();
            RuleFor(x => x.Months).NotEmpty();
            RuleFor(x => x.CurrencyDisplay).IsInEnum();
        }
    }
}