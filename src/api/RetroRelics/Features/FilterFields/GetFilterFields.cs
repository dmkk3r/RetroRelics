using FastEndpoints;
using RetroRelics.Features.Relics;
using RetroRelics.Playwright.Extensions;
using RetroRelics.Playwright.Models;
using RetroRelics.Playwright.Models.ebay;

namespace RetroRelics.Features.FilterFields;

public class GetFilterFields : EndpointWithoutRequest<GetFilterFieldsResponse> {
    private readonly ILogger<GetRelics> _logger;

    public GetFilterFields(ILogger<GetRelics> logger) {
        _logger = logger;
    }

    public override void Configure() {
        Get("/filterfields");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct) {
        var filterFields = new EbayFilterOptions().ToFilterFields();

        await SendAsync(new GetFilterFieldsResponse {
            FilterFields = filterFields
        }, cancellation: ct);
    }
}

public class GetFilterFieldsResponse {
    public List<FilterField> FilterFields { get; set; } = new();
}