using eCommerce.Domain.Enums;

namespace eCommerce.Domain.Entites;
public class User : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public SexTypeEnum Sex { get; private set; } = SexTypeEnum.Male;
    public string? RG {  get; private set; }
    public string? CPF {  get; private set; }
    public string MotherName {  get; private set; } = string.Empty;
    public string FatherName { get; private set; } = string.Empty;
    public UserStatusEnum Status { get; private set; } = UserStatusEnum.Active;
    public UserRoleEnum Role { get; set; } = UserRoleEnum.Customer;

    public ICollection<DeliveryAddress>? DeliveryAddresses { get; set; }
    public ICollection<Department>? Departments { get; set; }

    public User(long id, string name, string email) : base(id)
    {
        Name = name;
        Email = email;
    }
}
