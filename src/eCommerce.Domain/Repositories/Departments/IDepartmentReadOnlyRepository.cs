using eCommerce.Domain.Entites;

namespace eCommerce.Domain.Repositories.Departments;

public interface IDepartmentReadOnlyRepository
{
    Task<List<Department>> GetAllAsync(int? pageNum = 1, int? pageSize = 10);

    Task<Department?> GetByIdAsync(long id);
}
