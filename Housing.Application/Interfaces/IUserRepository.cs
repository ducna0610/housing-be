using Housing.Domain.Entities;

namespace Housing.Application.Interfaces;

public interface IUserRepository
{
    Task<User> Authenticate(string userName, string password);
    void Register(string userName, string password);
    Task<bool> UserAlreadyExists(string userName);
}