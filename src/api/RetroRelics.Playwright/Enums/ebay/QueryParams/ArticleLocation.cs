using System.ComponentModel;

namespace RetroRelics.Playwright.Enums.ebay.QueryParams;

public enum ArticleLocation {
    [Description("98")] Standard,
    [Description("1")] Germany,
    [Description("3")] Europe,
    [Description("6")] EuropeContinental,
    [Description("2")] Worldwide,
}