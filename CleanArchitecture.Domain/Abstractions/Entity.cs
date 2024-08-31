namespace CleanArchitecture.Domain.Abstractions;
public abstract class Entity
{
    protected Entity()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
