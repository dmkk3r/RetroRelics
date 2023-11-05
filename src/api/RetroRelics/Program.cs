using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using RetroRelics.Postgres;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument(o => {
        o.DocumentSettings = s => {
            s.Title = "RetroRelics API";
            s.Version = "v1";
        };
    });

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Logging.AddSerilog(logger);

builder.Services.AddDbContextFactory<RetroRelicsContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("retrorelics"));
});

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();