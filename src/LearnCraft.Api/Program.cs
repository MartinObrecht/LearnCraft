using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using LearnCraft.Api.Extensions.Swagger;
using LearnCraft.Api.Extensions.Telemetry;
using LearnCraft.Repository;
using Microsoft.EntityFrameworkCore;

namespace LearnCraft.Api
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddApplicationInsightsExtensions(builder.Configuration);
            builder.Logging.AddLoggingExtensions(builder.Configuration);
            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(item: new JsonStringEnumConverter());
                });
            builder.Services.AddSwagger();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<CachorroDbContext>(options =>
            {
                options.UseInMemoryDatabase("Cachorros");
            });

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}