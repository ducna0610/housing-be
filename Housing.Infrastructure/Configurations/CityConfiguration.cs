using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Infrastructure.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}
