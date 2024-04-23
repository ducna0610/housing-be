using Housing.Domain.Entities;
using Housing.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Housing.Infrastructure.Data;

public class HousingDbContext : DbContext
{
    public HousingDbContext(DbContextOptions<HousingDbContext> options) : base(options) { }

    #region DbSet
    DbSet<User> Users { get; set; }
    DbSet<City> Cities { get; set; }
    DbSet<Property> Properties { get; set; }
    DbSet<Photo> Photos { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new PhotoConfiguration());
        modelBuilder.ApplyConfiguration(new PropertyConfiguration());
    }
}
