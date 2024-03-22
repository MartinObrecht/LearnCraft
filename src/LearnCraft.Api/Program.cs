using LearnCraft.Api.Extensions.Telemetry;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationInsightsExtensions(builder.Configuration);
builder.Logging.AddLoggingExtensions(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
