using Intellexi.TrailRacing.Shared;
using Microsoft.EntityFrameworkCore;

namespace Intellexi.TrailRacing.Persistence;

public class TrailRacingDbContext : DbContext
{
    public TrailRacingDbContext(DbContextOptions<TrailRacingDbContext> options)
        : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(AppDefaults.Persistence.SchemaName);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrailRacingDbContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}