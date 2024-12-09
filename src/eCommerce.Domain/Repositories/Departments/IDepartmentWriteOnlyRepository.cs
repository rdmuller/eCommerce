using eCommerce.Domain.Entites;

namespace eCommerce.Domain.Repositories.Departments;
public interface IDepartmentWriteOnlyRepository
{
    Task AddAsync(Department department);

    Task<Department?> GetByIdAsync(long id);

    void Update(Department department);

    void Delete(Department department);
}
