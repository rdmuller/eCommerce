namespace eCommerce.Domain.Entites;
public abstract class BaseEntity
{
    public long Id { get; private set; }
    public DateTimeOffset CreatedDate { get; private set; } = DateTime.UtcNow;
    public DateTimeOffset? UpdatedDate { get; private set; }
}
