using System.ComponentModel;

namespace RetroRelics.Playwright.Enums.ebay.QueryParams;

public enum ListingType {
    [Description("LH_All")] All,
    [Description("LH_Auction")] Auction,
    [Description("LH_BIN")] BuyItNow,
}