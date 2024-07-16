using Domain.Interfaces;
using Domain.Mappers;

namespace Domain.QueryExtensions;

public static class CommonQueryExtensions
{
    public static IQueryable<T> ToPage<T>(this IQueryable<T> query, IPagination searchParams) where T : IBaseEntity {
        var pagination = searchParams.ToPagination();
        if(pagination.limit < 0)
            return query;
        return query.Skip(pagination.offset).Take(pagination.limit);
    }   
}