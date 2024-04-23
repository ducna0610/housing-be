using Housing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Housing.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Role)
            .IsRequired()
            .HasColumnType("tinyint");

        builder.Property(x => x.IsAvtive)
            .IsRequired();

        builder.Property(x => x.Password)
            .IsRequired();

        builder.Property(x => x.PasswordKey)
            .IsRequired();

        builder.HasIndex(x => x.Username)
            .IsUnique();
    }
}
