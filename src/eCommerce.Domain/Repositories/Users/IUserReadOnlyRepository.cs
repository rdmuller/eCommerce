using eCommerce.Domain.Entites;

namespace eCommerce.Domain.Repositories.Users;
public interface IUserReadOnlyRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
}
