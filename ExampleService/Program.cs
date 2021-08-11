using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
// setting Nlog
using NLog;
using NLog.Extensions.Logging;
namespace ExampleService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(opts => {
                        opts.ListenAnyIP(5000);
                    });
                    webBuilder.UseStartup<Startup>();
                });
        
        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
                .AddTransient<Runner>() // Runner is the custom class
                .AddLogging(loggingBuilder =>
                {
                    // configure Logging with NLog
                    loggingBuilder.ClearProviders();
                    loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                    loggingBuilder.AddNLog(config);
                })
                .BuildServiceProvider();
        }

    }
        public class Runner
    {
        private readonly ILogger<Runner> _logger;

        public Runner(ILogger<Runner> logger)
        {
            _logger = logger;
        }

        public void DoAction(string name)
        {
            _logger.LogDebug(20, "Doing hard work! {Action}", name);
            _logger.LogInformation(21, "Doing hard work! {Action}", name);
            _logger.LogWarning(22, "Doing hard work! {Action}", name);
            _logger.LogError(23, "Doing hard work! {Action}", name);
            _logger.LogCritical(24, "Doing hard work! {Action}", name);
        }
    }
}
