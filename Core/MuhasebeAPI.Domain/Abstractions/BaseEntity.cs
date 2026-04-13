namespace MuhasebeAPI.Domain.Abstractions;

public abstract class BaseEntity
{
    protected BaseEntity()
    {
    }

    protected BaseEntity(string id)
    {
        Id = id;
    }

    public string Id { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
