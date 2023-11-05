using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using RetroRelics.Postgres;

namespace RetroRelics.Features.Relics;

public class DeleteRelic : Endpoint<DeleteRelicRequest> {
    private readonly ILogger<DeleteRelic> _logger;
    private readonly IDbContextFactory<RetroRelicsContext> _dbContextFactory;

    public DeleteRelic(ILogger<DeleteRelic> logger, IDbContextFactory<RetroRelicsContext> dbContextFactory) {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    public override void Configure() {
        Delete("/relics/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRelicRequest req, CancellationToken ct) {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(ct);

        var relic = await dbContext.Relics
            .FirstOrDefaultAsync(r => r.Id == req.Id, ct);

        if (relic == null) {
            await SendNotFoundAsync(ct);
            return;
        }

        _logger.LogInformation($"Deleting relic {relic.Name}");

        dbContext.Relics.Remove(relic);
        await dbContext.SaveChangesAsync(ct);

        await SendAsync(new DeleteRelicResponse {
        }, cancellation: ct);
    }
}

public class DeleteRelicRequest {
    public Guid Id { get; set; }
}

public class DeleteRelicResponse {
}