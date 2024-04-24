using Housing.Application.Interfaces;
using Housing.Infrastructure.Repositories;

namespace Housing.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly HousingDbContext dc;

    public UnitOfWork(HousingDbContext dc)
    {
        this.dc = dc;
    }

    public ICityRepository CityRepository =>
        new CityRepository(dc);

    public IUserRepository UserRepository =>
        new UserRepository(dc);

    public IPropertyRepository PropertyRepository =>
        new PropertyRepository(dc);

    public async Task<bool> SaveAsync()
    {
        return await dc.SaveChangesAsync() > 0;
    }
}