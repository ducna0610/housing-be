using Housing.Application.Interfaces;
using Housing.Domain.Entities;
using Housing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Housing.Infrastructure.Repositories;

public class CityRepository : ICityRepository
{
    private readonly HousingDbContext dc;

    public CityRepository(HousingDbContext dc)
    {
        this.dc = dc;
    }

    public void AddCity(City city)
    {
        dc.Cities.Add(city);
    }

    public void DeleteCity(int CityId)
    {
        var city = dc.Cities.Find(CityId);
        dc.Cities.Remove(city);
    }

    public async Task<City> FindCity(int id)
    {
        return await dc.Cities.FindAsync(id);
    }

    public async Task<IEnumerable<City>> GetCitiesAsync()
    {
        return await dc.Cities.ToListAsync();
    }
}