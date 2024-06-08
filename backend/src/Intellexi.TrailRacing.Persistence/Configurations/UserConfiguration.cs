using Intellexi.TrailRacing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intellexi.TrailRacing.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever();
        
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasMaxLength(MaxPropertyLength);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasMaxLength(MaxPropertyLength);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(MaxPropertyLength);

        builder.Property(x => x.DateOfBirth).IsRequired();

        builder.Property(x => x.Role).IsRequired();
    }
}