namespace Domain.Interfaces;

public interface IAuditableEntity
{
    public DateTime dateCreated { get; set; }
    public DateTime dateUpdated { get; set; }
}