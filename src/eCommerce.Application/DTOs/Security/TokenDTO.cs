using System.Text.Json.Serialization;

namespace eCommerce.Application.DTOs.Security;
public record TokenDTO
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = string.Empty;

    [JsonPropertyName("expiration_at")]
    public DateTimeOffset Expiration { get; set; }
}
