using eCommerce.Domain.Entites;
using eCommerce.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Infra.DataAccess.Repositories;
public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly eCommerceDbContext _dbContext;

    Task IUserWriteOnlyRepository.Add(User user)
    {
        throw new NotImplementedException();
    }

    Task IUserWriteOnlyRepository.Delete(int id)
    {
        throw new NotImplementedException();
    }

    Task<List<User>> IUserReadOnlyRepository.GetAllAsync()
    {
        throw new NotImplementedException();
    }

    Task<User> IUserReadOnlyRepository.GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<User> IUserWriteOnlyRepository.GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task IUserWriteOnlyRepository.Update(User user)
    {
        throw new NotImplementedException();
    }
}
