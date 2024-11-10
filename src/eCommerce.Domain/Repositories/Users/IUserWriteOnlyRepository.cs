using eCommerce.Domain.Entites;

namespace eCommerce.Domain.Repositories.Users;
public interface IUserWriteOnlyRepository
{
    Task<User> GetAsync(int id);
    Task Add(User user);
    Task Update(User user);
    Task Delete(int id);
}
