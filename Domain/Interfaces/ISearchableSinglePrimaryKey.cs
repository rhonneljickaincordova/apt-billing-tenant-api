namespace Domain.Interfaces;

public interface ISearchableSinglePrimaryKey<TKey>
{
    public TKey Id { get; set; }   
}