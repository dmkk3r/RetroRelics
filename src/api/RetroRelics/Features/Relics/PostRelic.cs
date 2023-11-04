using FastEndpoints;

namespace RetroRelics.Features.Relics;

public class PostRelic : Endpoint<PostRelicRequest> {
    private readonly ILogger<PostRelic> _logger;

    public PostRelic(ILogger<PostRelic> logger) {
        _logger = logger;
    }

    public override void Configure() {
        Post("/relics");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PostRelicRequest req, CancellationToken ct) {
        await SendAsync(new PostRelicRespone {
        }, cancellation: ct);
    }
}

public class PostRelicRequest {
    public int Id { get; set; }
}

public class PostRelicRespone {
}