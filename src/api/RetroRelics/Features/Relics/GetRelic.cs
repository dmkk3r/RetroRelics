using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using RetroRelics.Postgres;

namespace RetroRelics.Features.Relics;

public class GetRelic : Endpoint<GetRelicRequest> {
    private readonly ILogger<GetRelic> _logger;
    private readonly IDbContextFactory<RetroRelicsContext> _dbContextFactory;

    public GetRelic(ILogger<GetRelic> logger, IDbContextFactory<RetroRelicsContext> dbContextFactory) {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    public override void Configure() {
        Get("/relics/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRelicRequest req, CancellationToken ct) {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(ct);
        var relic = await dbContext.Relics
            .Include(r => r.Metadata)
            .FirstOrDefaultAsync(r => r.Id == req.Id, ct);

        await SendAsync(new GetRelicResponse {
        }, cancellation: ct);
    }
}

public class GetRelicRequest {
    public Guid Id { get; set; }
}

public class GetRelicResponse {
}