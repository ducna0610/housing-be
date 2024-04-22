using Housing.Domain.Entities;
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
}
