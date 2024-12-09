using eCommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infra.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly eCommerceDbContext _dbContext;
    public UnitOfWork(eCommerceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CommitAsync() => await _dbContext.SaveChangesAsync();
}
