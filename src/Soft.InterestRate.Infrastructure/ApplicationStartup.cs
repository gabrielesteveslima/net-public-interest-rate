namespace Soft.InterestRate.Infrastructure
{
    using System;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Autofac.Extras.CommonServiceLocator;
    using CommonServiceLocator;
    using Logs;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Processing;
    using Resilience;

    public static class ApplicationStartup
    {
        public static IServiceProvider Initialize(
            IServiceCollection services, IConfiguration configuration)
        {
            var serviceProvider = CreateAutofacServiceProvider(services, configuration);
            return serviceProvider;
        }

        private static IServiceProvider CreateAutofacServiceProvider(
            IServiceCollection services, IConfiguration configuration)
        {
            var container = new ContainerBuilder();

            container.Populate(services);
            container.RegisterModule(new LogModule());
            container.RegisterModule(new ResilienceModule());
            container.RegisterModule(new MediatorModule(configuration));

            var buildContainer = container.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));
            var serviceProvider = new AutofacServiceProvider(buildContainer);
            return serviceProvider;
        }
    }
}