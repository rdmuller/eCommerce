using eCommerce.Application.Common.Exceptions;
using eCommerce.Application.DTOs.Security;
using eCommerce.Domain.Entites;
using eCommerce.Domain.Security;
using MediatR;

namespace eCommerce.Application.UseCases.Users.Login;
public class LoginUserHandler(IIdentityService identityService, IAccessTokenGenerator accessTokenGenerator) : IRequestHandler<LoginUserCommand, TokenDTO>
{
    private readonly IIdentityService _identityService = identityService;
    private readonly IAccessTokenGenerator _accessTokenGenerator = accessTokenGenerator;

    public async Task<TokenDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var authorizeSuccess = await _identityService.AuthorizeAsync(request.Email, request.Password);

        if (!authorizeSuccess)
            throw new NotAuthorizedException("Acesso negado");

        var user = new User(request.Email);
        var tokenJwt = _accessTokenGenerator.GenerateAccessToken(user);

        var response = new TokenDTO() { Token = tokenJwt.Token, Expiration  = tokenJwt.Expiration };

        return response;
    }
}
