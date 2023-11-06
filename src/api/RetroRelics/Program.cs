using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using RetroRelics.Postgres;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

const string retroReclisOrigin = "retroReclis";
builder.Services.AddCors(opt => {
    opt.AddPolicy(name: retroReclisOrigin, policyBuilder => {
        policyBuilder.WithOrigins("http://localhost:5173")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.Configure<ForwardedHeadersOptions>(options => {
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor |
        ForwardedHeaders.XForwardedHost |
        ForwardedHeaders.XForwardedProto;

    options.ForwardLimit = 2;
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});


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

app.UseForwardedHeaders();
app.UseCors(retroReclisOrigin);

app.UseFastEndpoints()
    .UseSwaggerGen();

app.Run();