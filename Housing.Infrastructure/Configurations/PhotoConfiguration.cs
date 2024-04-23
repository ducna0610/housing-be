using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Infrastructure.Data.Configurations;

public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.Property(x => x.PublicId)
            .IsRequired();

        builder.Property(x => x.ImageUrl)
            .IsRequired();

        builder.Property(x => x.IsPrimary)
            .IsRequired();

        builder.HasOne(x => x.Property)
            .WithMany(x => x.Photos)
            .HasForeignKey(x => x.PropertyId);
    }
}
