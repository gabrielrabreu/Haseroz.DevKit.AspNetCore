using Serilog;
using Serilog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

var logger = Log.Logger = new LoggerConfiguration()
  .WriteTo.Console()
  .MinimumLevel.Information()
  .CreateLogger();

builder.Host.UseSerilog(logger);

var microsoftLogger = new SerilogLoggerFactory(logger).CreateLogger<Program>();

microsoftLogger.LogInformation("Starting web host");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.RunAsync();
