using System.ComponentModel.DataAnnotations;

namespace eCommerce.Application.DTOs.Users;
public class RegisterUserCommandDTO
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
}
