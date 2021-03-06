namespace Soft.InterestRate.API
{
    using System;
    using Application.CalculateInterest.ACL;
    using Configuration;
    using Configuration.Docs;
    using Configuration.ProblemDetails;
    using Hellang.Middleware.ProblemDetails;
    using Infrastructure;
    using JsonApiSerializer.ContractResolvers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new JsonApiContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });


            services
                .AddVersioningSystem()
                .AddSwaggerDocumentation()
                .AddProblemDetailsMiddleware()
                .AddHealthChecks();

            services.Configure<InterestRateApiQueryConfig>(Configuration.GetSection("InterestRateApiQueryConfig"));
            services.Configure<ProjectConfig>(Configuration.GetSection("ProjectConfig"));

            services.AddScoped<IInterestRateQueryApi, InterestRateQueryApi>();

            return ApplicationStartup.Initialize(
                services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseProblemDetails();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthcheck",
                    new HealthCheckOptions
                    {
                        ResultStatusCodes =
                        {
                            [HealthStatus.Healthy] = StatusCodes.Status200OK,
                            [HealthStatus.Degraded] = StatusCodes.Status200OK,
                            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                        }
                    });
            });

            app.UseSwaggerDocumentation();
        }
    }
}