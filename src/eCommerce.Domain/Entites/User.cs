using eCommerce.Domain.Enums;

namespace eCommerce.Domain.Entites;
public class User : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public SexType Sex { get; private set; } = SexType.Male;
    public string? RG {  get; private set; }
    public string? CPF {  get; private set; }
    public string MotherName {  get; private set; } = string.Empty;
    public string Situation { get; private set; } = string.Empty;

    public Contact? Contact {  get; set; } 
    public ICollection<DeliveryAddress>? DeliveryAddresses { get; set; }
    public ICollection<Department>? Departments { get; set; }
}
