namespace LearnCraft.Api.Extensions.Telemetry
{
    public static class LoggingExtensions
    {
        public static void ILoggingBuilder(this ILoggingBuilder loggingBuilder,
        IConfiguration configuration)
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.AddConsole();

            loggingBuilder.AddApplicationInsights(
                configureTelemetryConfiguration: (config) =>
                    config.ConnectionString = configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"],
                configureApplicationInsightsLoggerOptions: (options) => { }
            );
        }
    }
}