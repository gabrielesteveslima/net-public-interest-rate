﻿using System;
using System.Linq;
using System.Net.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;
using Wire.Transfer.In.Infrastructure.Logs;

namespace Wire.Transfer.In.Infrastructure.Resilience
{
    public static class FlurExtensions
    {
        private static AsyncRetryPolicy<HttpResponseMessage> RetryPolicy
        {
            get
            {
                var maxDelay = TimeSpan.FromMinutes(3);
                var delay = Backoff
                    .DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(5), 5)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks)));

                return Policy
                    .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                    .WaitAndRetryAsync(delay,
                        (delegateResult, timeSpan, retryCount, context) =>
                        {
                            Log.Warning($"WireTransfer failed with status {delegateResult.Result?.StatusCode}." +
                                        $"Waiting {timeSpan} before next retry. Retry attempt {retryCount}.");
                        });
            }
        }

        public static AsyncPolicy<HttpResponseMessage> PolicyStrategy => RetryPolicy;
    }
}