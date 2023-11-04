using FastEndpoints;

namespace RetroRelics.Features.Relics;

public class GetRelic : Endpoint<GetRelicRequest> {
    private readonly ILogger<GetRelic> _logger;

    public GetRelic(ILogger<GetRelic> logger) {
        _logger = logger;
    }

    public override void Configure() {
        Get("/relics/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRelicRequest req, CancellationToken ct) {
        await SendAsync(new GetRelicResponse {
        }, cancellation: ct);
    }
}

public class GetRelicRequest {
    public int Id { get; set; }
}

public class GetRelicResponse {
}