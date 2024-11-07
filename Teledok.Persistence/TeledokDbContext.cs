using Teledok.Domain;
using Microsoft.EntityFrameworkCore;
using Teledok.Persistence.EntityTypeConfigurations;

namespace Teledok.Persistence;

public class TeledokDbContext(DbContextOptions<TeledokDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Founder> Founders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientConfiguration());
        modelBuilder.ApplyConfiguration(new FounderConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}