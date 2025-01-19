using eCommerce.Application.Common.Bases;
using eCommerce.Application.DTOs.Security;
using eCommerce.Domain.Entites;
using eCommerce.Domain.Security;
using MediatR;

namespace eCommerce.Application.UseCases.Users.Register;
public class RegisterUserHandler(IIdentityService identityService, IAccessTokenGenerator accessTokenGenerator) : IRequestHandler<RegisterUserCommand, TokenDTO>
{
    private readonly IIdentityService _identityService = identityService;
    private readonly IAccessTokenGenerator _accessTokenGenerator = accessTokenGenerator;

    public async Task<TokenDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.AddAsync(request!.Data!.Email, request.Data.Password);

        var user = new User(request.Data.Email);

        var tokenJwt = _accessTokenGenerator.GenerateAccessToken(user);

        var response = new TokenDTO() { Token = tokenJwt.Token, Expiration = tokenJwt.Expiration };

        return response;
    }
}
