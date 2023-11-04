using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RetroRelics.Postgres;

public class RetroRelicsContext : DbContext {
    private readonly IConfiguration _configuration;

    public RetroRelicsContext(IConfiguration configuration) {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("retrorelics"));
    }
}