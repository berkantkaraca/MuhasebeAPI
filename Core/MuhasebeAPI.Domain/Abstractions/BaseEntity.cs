namespace MuhasebeAPI.Domain.Abstractions;

public abstract class BaseEntity
{
    public string Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
