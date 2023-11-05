using Microsoft.EntityFrameworkCore;
using RetroRelics.Postgres.Entities;

namespace RetroRelics.Postgres;

public class RetroRelicsContext : DbContext {
    public RetroRelicsContext(DbContextOptions<RetroRelicsContext> options) : base(options) { }

    public DbSet<Relic> Relics { get; set; }
    public DbSet<RelicMetadata> RelicMetadata { get; set; }
}