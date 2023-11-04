namespace RetroRelics.Postgres.Entities;

public class RelicMetadata {
    public Guid Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public Guid RelicId { get; set; }
    public Relic Relic { get; set; } = null!;
}