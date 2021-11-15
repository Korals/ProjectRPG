using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectK.Service.Workers;
using Serilog;

namespace ProjectK.Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); })
                .ConfigureLogging((hostingContext, logging) =>
                {
                    var loggerConfig = new LoggerConfiguration()
                        .ReadFrom.Configuration(hostingContext.Configuration);
                    var logger = loggerConfig.CreateLogger();
                    Log.Logger = logger;

                    logging.AddSerilog(logger);
                })
                .ConfigureServices((_, services) => services.AddHostedService<TestWorker>())
                .UseSerilog();
    }
}