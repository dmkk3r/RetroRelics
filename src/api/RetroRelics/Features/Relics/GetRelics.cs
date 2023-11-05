using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using RetroRelics.Postgres;
using RetroRelics.Postgres.Entities;

namespace RetroRelics.Features.Relics;

public class GetRelics : EndpointWithoutRequest<GetRelicsResponse> {
    private readonly ILogger<GetRelics> _logger;
    private readonly IDbContextFactory<RetroRelicsContext> _dbContextFactory;

    public GetRelics(ILogger<GetRelics> logger, IDbContextFactory<RetroRelicsContext> dbContextFactory) {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    public override void Configure() {
        Get("/relics");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(ct);

        var relics = await dbContext.Relics
            .Include(r => r.Metadata)
            .ToListAsync(ct);

        _logger.LogInformation($"Found {relics.Count} relics");
        
        await SendAsync(new GetRelicsResponse {
            Relics = relics
        }, cancellation: ct);
    }
}

public class GetRelicsResponse {
    public List<Relic> Relics { get; set; } = new();
}