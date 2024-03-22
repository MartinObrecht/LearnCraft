using LearnCraft.Api.Extensions.Swagger;
using LearnCraft.Api.Extensions.Telemetry;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsExtensions(builder.Configuration);
builder.Logging.AddLoggingExtensions(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
