using RetroRelics.Playwright.Enums.ebay.QueryParams;

namespace RetroRelics.Playwright.Models.ebay;

public class EbayFilterOptions {
    public string Keywords { get; set; } = string.Empty;
    public string? ExcludedKeywords { get; set; }
    public bool? Sold { get; set; }
    public bool? Completed { get; set; }
    public ItemsPerPage? ItemsPerPage { get; set; }
    public ListingType? ListingType { get; set; }
    public ArticleLocation? ArticleLocation { get; set; }
    public RegionalCode? RegionalCode { get; set; }
}