namespace Soft.InterestRate.API.Configuration.ProblemDetails
{
    using Flurl.Http;
    using Hellang.Middleware.ProblemDetails;
    using Helpers;
    using Infrastructure.Processing;
    using Microsoft.Extensions.DependencyInjection;

    public static class ProblemDetailsExtension
    {
        /// <summary>
        ///     Set handlers errors to problem details classes <see cref="Microsoft.AspNetCore.Mvc.ProblemDetails" />
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection AddProblemDetailsMiddleware(this IServiceCollection services)
        {
            services.AddScoped<ProblemDetailsFilter>();
            services.AddProblemDetails(setup =>
            {
                setup.Map<FlurlHttpException>(exception => new InfrastructureExceptionProblemDetails(exception));
                setup.Map<InvalidCommandException>(exception =>
                    new InvalidCommandRuleValidationExceptionProblemDetails(exception));
            });

            return services;
        }
    }
}