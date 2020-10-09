namespace Soft.InterestRate.API.Configuration.ProblemDetails
{
    using System.Collections.Generic;
    using Helpers;
    using Infrastructure.Processing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///     Represents errors on command model state <see cref="FluentValidation" />
    /// </summary>
    public class InvalidCommandRuleValidationExceptionProblemDetails : ProblemDetails
    {
        public InvalidCommandRuleValidationExceptionProblemDetails(InvalidCommandException exception)
        {
            Status = StatusCodes.Status400BadRequest;
            Type = nameof(InvalidCommandRuleValidationExceptionProblemDetails);
            Errors = ProblemDetailsWrapErrors.GetErrors(exception.Errors);
        }

        public IEnumerable<ProblemDetailsWrapErrors> Errors { get; }
        public new string Extensions { get; set; }
        public new string Title { get; set; }
        public new string Detail { get; set; }
    }
}