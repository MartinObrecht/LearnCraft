using LearnCraft.Api.Extensions.Swagger;
using LearnCraft.Api.Extensions.Telemetry;
using LearnCraft.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsExtensions(builder.Configuration);
builder.Logging.AddLoggingExtensions(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<CachorroContext>(options =>
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
