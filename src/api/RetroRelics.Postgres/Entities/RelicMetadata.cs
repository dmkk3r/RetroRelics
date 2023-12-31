using System.ComponentModel.DataAnnotations;

namespace RetroRelics.Postgres.Entities;

public class RelicMetadata {
    [Key] public Guid Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public Guid RelicId { get; set; }
}