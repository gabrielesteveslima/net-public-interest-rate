﻿namespace Soft.InterestRate.API.Configuration.ProblemDetails.Helpers
{
    using Infrastructure.Logs;
    using Infrastructure.Processing;
    using Microsoft.AspNetCore.Mvc.Filters;

    /// <summary>
    ///     Filters any exception from the application
    /// </summary>
    public class ProblemDetailsFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            switch (exception)
            {
                case InvalidCommandException commandException:
                    Log.Error(commandException.Errors);
                    break;
                default:
                    Log.Error(exception);
                    break;
            }
        }
    }
}