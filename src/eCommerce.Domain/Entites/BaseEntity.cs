namespace eCommerce.Domain.Entites;
public abstract class BaseEntity
{
    public long Id { get; private set; }
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }

    protected BaseEntity(long id)
    {
        Id = id;
    }

    protected BaseEntity()
    {
        
    }
}