using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Infrastructure.Data.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.Area)
            .IsRequired();

        builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .IsRequired();

        builder.Property(x => x.Category)
            .IsRequired()
            .HasColumnType("tinyint");

        builder.Property(x => x.FurnishingType)
            .IsRequired()
            .HasColumnType("tinyint");

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.HasOne(x => x.City)
            .WithOne(x => x.Property)
            .HasForeignKey<Property>(x => x.CityId);

        builder.HasOne(x => x.User)
            .WithMany(x => x.Properties)
            .HasForeignKey(x => x.PostedBy)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
