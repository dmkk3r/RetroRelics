using System.ComponentModel;

namespace RetroRelics.Playwright.Enums.ebay.QueryParams;

public enum ExtendedKeywordFilter {
    [Description("_ex_kw")] ExcludeKeyword,
    [Description("_in_kw")] IncludeKeyword,
}