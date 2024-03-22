namespace LearnCraft.Api.Extensions.Telemetry;

public static class ApplicationInsightsExtensions
{
    public static void AddApplicationInsightsExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplicationInsightsTelemetry(options =>
            {
                options.ConnectionString = configuration["APPLICATIONINSIGHTS_CONNECTION_STRING"];
            });
    }
}