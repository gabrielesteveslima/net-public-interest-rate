namespace Soft.InterestRate.API.Application.CalculateInterest.ACL
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IInterestRateQueryApi
    {
        Task<decimal> GetInterestRate(CancellationToken cancellationToken);
    }
}