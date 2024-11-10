using eCommerce.Domain.Entites;
using eCommerce.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infra.DataAccess.Repositories;
public class DepartmentRepository : IDepartmentReadOnlyRepository
{
    private readonly eCommerceDbContext _dbContext;

    public DepartmentRepository(eCommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Department>> GetAllAsync()
    {
        return await _dbContext.Departments.AsNoTracking().ToListAsync();
    }

    public async Task<Department?> GetByIdAsync(long id)
    {
        return await _dbContext.Departments
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id.Equals(id));
    }
}
