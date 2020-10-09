namespace Soft.InterestRate.Infrastructure.Resilience
{
    using Autofac;
    using Flurl.Http;

    public class ResilienceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            FlurlHttp.Configure(settings => settings.HttpClientFactory = new PollyHttpClientFactory());
        }
    }
}