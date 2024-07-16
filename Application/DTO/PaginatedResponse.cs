using Domain.Interfaces;

namespace Application.DTO;

public class PaginatedResponse<T> where T: IBaseEntity
{
    public int total { get; set; }
    public IEnumerable<T> data { get; set; }
}