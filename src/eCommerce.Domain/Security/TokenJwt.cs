namespace eCommerce.Domain.Security;
public record TokenJwt
{
    public string Token { get; set; } = string.Empty;

    public DateTimeOffset Expiration { get; set; }
}
