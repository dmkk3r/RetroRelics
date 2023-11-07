using System.ComponentModel;

namespace RetroRelics.Playwright.Enums.ebay.QueryParams;

public enum ItemsPerPage {
    [Description("60")] Sixty,
    [Description("120")] OneHundredTwenty,
    [Description("240")] TwoHundredForty,
}