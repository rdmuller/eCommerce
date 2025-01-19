using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs.Security;
public class LoginDTO
{
    [JsonPropertyName("email")]
    //[Required(ErrorMessage = "E-mail deve ser informado")]
    //[EmailAddress(ErrorMessage = "E-mail com formato inválido")]
    public string Email { get; set; } = string.Empty;

    [JsonPropertyName("password")]
    //[Required(ErrorMessage = "E-mail deve ser informado")]
    //[StringLength(80, MinimumLength = 8, ErrorMessage = "Senha deve conter no mínimo 8 caracteres")]
    public string Password { get; set; } = string.Empty;
}
