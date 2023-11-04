using FastEndpoints;

namespace RetroRelics.Features.Relics;

public class DeleteRelic : Endpoint<DeleteRelicRequest> {
    private readonly ILogger<DeleteRelic> _logger;

    public DeleteRelic(ILogger<DeleteRelic> logger) {
        _logger = logger;
    }

    public override void Configure() {
        Delete("/relics/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRelicRequest req, CancellationToken ct) {
        await SendAsync(new DeleteRelicResponse {
        }, cancellation: ct);
    }
}

public class DeleteRelicRequest {
    public int Id { get; set; }
}

public class DeleteRelicResponse {
}