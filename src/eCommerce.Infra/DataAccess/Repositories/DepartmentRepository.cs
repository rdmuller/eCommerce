using eCommerce.Domain.Entites;
using eCommerce.Domain.Repositories.Departments;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infra.DataAccess.Repositories;
public class DepartmentRepository : IDepartmentReadOnlyRepository, IDepartmentWriteOnlyRepository
{
    private readonly eCommerceDbContext _dbContext;

    public DepartmentRepository(eCommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Department department)
    {
        await _dbContext.Departments.AddAsync(department);
    }

    public async Task<List<Department>> GetAllAsync(int? pageNum = 1, int? pageSize = 10)
    {
        return await _dbContext.Departments.AsNoTracking().Skip(((int)pageNum! - 1) * (int)pageSize!).Take((int)pageSize!).Select(d => new Department(d.Id, d.Name)).ToListAsync();
    }

    async Task<Department?> IDepartmentReadOnlyRepository.GetByIdAsync(long id)
    {
        return await _dbContext.Departments
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id.Equals(id));
    }
    async Task<Department?> IDepartmentWriteOnlyRepository.GetByIdAsync(long id)
    {
        return await _dbContext.Departments
            .FindAsync(id);
            //.FirstOrDefaultAsync(d => d.Id.Equals(id));
    }

    public void Update(Department department)
    {
        _dbContext.Departments.Update(department);
    }

    public void Delete(Department department)
    {
        _dbContext.Departments.Remove(department);
    }
}
