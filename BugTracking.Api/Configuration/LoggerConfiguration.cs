using Serilog;

namespace BugTracking.Api.Configuration
{
    public static class LoggerConfiguration
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new Serilog.LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.File("logs/error-log.txt", rollingInterval: RollingInterval.Day)
                .Enrich.FromLogContext()
                .CreateLogger();
        }
    }
}
