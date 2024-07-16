namespace Domain.Interfaces;

public interface IPagination
{
    public string? searchText { get; set; }
    public int? limit { get; set; }
    public int? page { get; set; }
    public string[]? orderBy { get; set; }   
}