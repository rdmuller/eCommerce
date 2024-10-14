namespace eCommerce.Domain.Entites;
public class DeliveryAddress : BaseEntity
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ZipCode { get; set; }
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int Number {  get; set; }
    public string? complement { get; set; }

    public User? User { get; set; }
}
