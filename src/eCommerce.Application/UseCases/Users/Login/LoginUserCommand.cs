using eCommerce.Application.DTOs.Security;
using MediatR;
using System.Text.Json.Serialization;

namespace eCommerce.Application.UseCases.Users.Login;
public class LoginUserCommand : IRequest<TokenDTO>
{
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}
