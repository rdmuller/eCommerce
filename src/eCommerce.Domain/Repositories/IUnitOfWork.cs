namespace eCommerce.Domain.Repositories;
public interface IUnitOfWork
{
    Task Commit();
}
