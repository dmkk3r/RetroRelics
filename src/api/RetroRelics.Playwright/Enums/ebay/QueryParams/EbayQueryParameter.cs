using System.ComponentModel;

namespace RetroRelics.Playwright.Enums.ebay.QueryParams;

public enum EbayQueryParameter {
    [Description("_nkw")] Keyword,
    [Description("_ipg")] ItemsPerPage,
    [Description("_sacat")] Category,
    [Description("_sop")] SortOrder,
    [Description("_pgn")] PageNumber,
    [Description("LH_Sold")] Sold,
    [Description("LH_Complete")] Completed,
    [Description("LH_PrefLoc")] ArticleLocation,
    [Description("Regionalcode")] RegionalCode,
}