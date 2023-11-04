using FastEndpoints;
using RetroRelics.Postgres;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddDbContextFactory<RetroRelicsContext>();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();