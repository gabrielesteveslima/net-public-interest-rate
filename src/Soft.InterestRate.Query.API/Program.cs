namespace Soft.InterestRate.Query.API
{
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Logging;

    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingBuilder => { loggingBuilder.ClearProviders(); })
                .UseUrls("http://*:5000")
                .UseStartup<Startup>();
        }
    }
}