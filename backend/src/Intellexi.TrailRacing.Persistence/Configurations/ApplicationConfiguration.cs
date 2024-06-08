using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intellexi.TrailRacing.Persistence.Configurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Domain.Entities.Application>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Application> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(MaxPropertyLength);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(MaxPropertyLength);

        builder.Property(x => x.Club)
            .IsRequired()
            .HasMaxLength(MaxPropertyLength);

        builder.Property(x => x.RaceId).IsRequired();
        
        builder
            .HasOne(x => x.Race)
            .WithMany()
            .HasForeignKey(x => x.RaceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}