using Intellexi.TrailRacing.Domain;
using Intellexi.TrailRacing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intellexi.TrailRacing.Persistence.Configurations;

public class RaceConfiguration : IEntityTypeConfiguration<Race>
{
    public void Configure(EntityTypeBuilder<Race> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(MaxPropertyLength);

        builder.Property(x => x.Distance).IsRequired();
    }
}