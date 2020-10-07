﻿using Autofac;
using Flurl.Http;

namespace Wire.Transfer.In.Infrastructure.Resilience
{
    public class ResilienceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            FlurlHttp.Configure(settings => settings.HttpClientFactory = new PollyHttpClientFactory());
        }
    }
}