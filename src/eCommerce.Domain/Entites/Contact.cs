namespace eCommerce.Domain.Entites;
public class Contact : BaseEntity
{
    public int UserId { get; set; }
    public string Phone { get; private set; } = string.Empty; 

    public User? User { get; set; }
}
