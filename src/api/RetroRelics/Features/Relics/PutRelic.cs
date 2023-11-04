using FastEndpoints;

namespace RetroRelics.Features.Relics;

public class PutRelic : Endpoint<PutRelicRequest> {
    private readonly ILogger<PutRelic> _logger;

    public PutRelic(ILogger<PutRelic> logger) {
        _logger = logger;
    }

    public override void Configure() {
        Put("/relics");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PutRelicRequest req, CancellationToken ct) {
        await SendAsync(new PutRelicResponse {
        }, cancellation: ct);
    }
}

public class PutRelicRequest {
    public int Id { get; set; }
}

public class PutRelicResponse {
}