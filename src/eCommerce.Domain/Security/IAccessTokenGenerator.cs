using eCommerce.Domain.Entites;

namespace eCommerce.Domain.Security;

public interface IAccessTokenGenerator
{
    TokenJwt GenerateAccessToken(User user);
}
