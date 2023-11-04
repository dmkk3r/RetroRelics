using System.ComponentModel.DataAnnotations;

namespace RetroRelics.Postgres.Entities;

public class Relic {
    [Key] public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<RelicMetadata> Metadata { get; set; } = new List<RelicMetadata>();
}