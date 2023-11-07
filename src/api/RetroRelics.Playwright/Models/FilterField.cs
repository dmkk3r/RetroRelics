namespace RetroRelics.Playwright.Models;

public class FilterField {
    public string Name { get; set; } = string.Empty;
    public string? Value { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool Nullable { get; set; }
    public bool Enumeration { get; set; }
    public string[]? EnumerationValues { get; set; }
}