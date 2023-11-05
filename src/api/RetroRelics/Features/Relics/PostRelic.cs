using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using RetroRelics.Postgres;
using RetroRelics.Postgres.Entities;

namespace RetroRelics.Features.Relics;

public class PostRelic : Endpoint<PostRelicRequest> {
    private readonly ILogger<PostRelic> _logger;

    private readonly IDbContextFactory<RetroRelicsContext> _dbContextFactory;

    public PostRelic(ILogger<PostRelic> logger, IDbContextFactory<RetroRelicsContext> dbContextFactory) {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
    }

    public override void Configure() {
        Post("/relics");
        AllowAnonymous();
    }

    public override async Task HandleAsync(PostRelicRequest req, CancellationToken ct) {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync(ct);

        var relic = new Relic {
            Name = req.Name,
            Metadata = new List<RelicMetadata> {
                new() {
                    Key = "Description",
                    Value = req.Description
                },
                new() {
                    Key = "ImageUrl",
                    Value = req.ImageUrl
                }
            }
        };

        _logger.LogInformation($"Adding relic {relic.Name}");

        await dbContext.Relics.AddAsync(relic, ct);
        await dbContext.SaveChangesAsync(ct);

        await SendOkAsync(ct);
    }
}

public class PostRelicRequest {
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}