using Payment.API.Models;

namespace Payment.API.Services;

public interface IUserService
{
    User GetById(int id);
}

public class UserService : IUserService
{
    public User GetById(int id) => new() { Country = new Country() { CountryId = 3 } };
}
