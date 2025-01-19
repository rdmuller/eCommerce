using eCommerce.Application.DTOs.Security;
using eCommerce.Domain.Entites;
using eCommerce.Domain.Security;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce.Infra.Security;

public class AccessTokenGenerator : IAccessTokenGenerator
{
    private readonly uint _expirationTimeMinutes;
    private readonly string _signingKey;
    private readonly string _audience;
    private readonly string _issuer;

    public AccessTokenGenerator(uint expirationTimeMinutes,
        string signingKey,
        string audience,
        string issuer)
    {
        _audience = audience;
        _expirationTimeMinutes = expirationTimeMinutes;
        _signingKey = signingKey;
        _issuer = issuer;
    }

    public TokenJwt GenerateAccessToken(User user)
    {
        var claims = new Claim[] { 
            new Claim(ClaimTypes.Email, user.Email),
            //new Claim(ClaimTypes.Name, user.Name),
            //new Claim(ClaimTypes.Sid, user.UserIdentifier.ToString()),
            //new Claim(ClaimTypes.Role, user.Role)
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        // gerar chave privada para assinar o token
        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signingKey));

        // gerar a assinatura digital
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

        // definir o tempo de expiração
        var expiration = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes);

        // gerar o token
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
            );

        var tokenJwt = new TokenJwt()
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };

        return tokenJwt;
    }
}
