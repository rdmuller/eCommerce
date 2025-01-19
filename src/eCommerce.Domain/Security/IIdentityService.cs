namespace eCommerce.Domain.Security;
public interface IIdentityService
{
    Task<string> AddAsync(string email, string password);

    Task<bool> AuthorizeAsync(string email, string password);
}
