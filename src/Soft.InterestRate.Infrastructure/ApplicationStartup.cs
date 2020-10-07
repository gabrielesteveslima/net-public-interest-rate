namespace SecurityManagement.Infrastructure
{
    using System;
    using Auth;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Autofac.Extras.CommonServiceLocator;
    using CommonServiceLocator;
    using Database;
    using Domain;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Processing;

    public static class ApplicationStartup
    {
        public static IServiceProvider Initialize(
            IServiceCollection services,
            IConfiguration configuration)
        {
            var serviceProvider = CreateAutofacServiceProvider(services, configuration);
            return serviceProvider;
        }

        private static IServiceProvider CreateAutofacServiceProvider(
            IServiceCollection services,
            IConfiguration configuration)
        {
            var container = new ContainerBuilder();

            container.Populate(services);

            container.RegisterModule(new DatabaseModule(
                configuration.GetConnectionString("DefaultConnection")));

            container.RegisterModule(new ProcessingModule());
            container.RegisterModule(new AuthModule(configuration));
            container.RegisterModule(new DomainModule());

            var buildContainer = container.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(buildContainer));
            var serviceProvider = new AutofacServiceProvider(buildContainer);
            CompositionRoot.SetContainer(buildContainer);
            return serviceProvider;
        }
    }
}