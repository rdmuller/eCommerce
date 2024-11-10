using eCommerce.Domain.Entites;

namespace eCommerce.Domain.Repositories.Users;

public interface IDepartmentReadOnlyRepository
{
    Task<List<Department>> GetAllAsync();
    Task<Department?> GetByIdAsync(long id);
}
