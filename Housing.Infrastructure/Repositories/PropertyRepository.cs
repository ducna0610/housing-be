using Housing.Application.Interfaces;
using Housing.Domain.Entities;
using Housing.Domain.Enums;
using Housing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Housing.Infrastructure.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly HousingDbContext dc;

    public PropertyRepository(HousingDbContext dc)
    {
        this.dc = dc;
    }

    public void AddProperty(Property property)
    {
        dc.Properties.Add(property);
    }

    public void DeleteProperty(int id)
    {
        throw new System.NotImplementedException();
    }

    public async Task<IEnumerable<Property>> GetPropertiesAsync(int sellRent)
    {
        var properties = await dc.Properties
        .Include(p => p.City)
        .Include(p => p.Photos)
        .Where(p => p.Category == (CategoryEnum)sellRent)
        .ToListAsync();

        return properties;
    }

    public async Task<Property> GetPropertyDetailAsync(int id)
    {
        var properties = await dc.Properties
        .Include(p => p.City)
        .Include(p => p.Photos)
        .Where(p => p.Id == id)
        .FirstAsync();

        return properties;
    }

    public async Task<Property> GetPropertyByIdAsync(int id)
    {
        var properties = await dc.Properties
        .Include(p => p.Photos)
        .Where(p => p.Id == id)
        .FirstOrDefaultAsync();

        return properties;
    }
}