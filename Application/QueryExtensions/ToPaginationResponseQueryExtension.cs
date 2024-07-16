using Application.DTO;
using Domain.Interfaces;
using Domain.QueryExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.QueryExtensions;

public static class ToPaginationResponseQueryExtension
{
    public static async Task<PaginatedResponse<T>> ToPaginationResponse<T>(this IQueryable<T> query, IPagination pagination, CancellationToken cancellationToken = default) where T: class, IBaseEntity  {
        var totalCount = await query.AsNoTracking().CountAsync(cancellationToken);
        query = query.ToPage(pagination);
        var results = await query.ToListAsync(cancellationToken);	
        return new PaginatedResponse<T>() { total = totalCount, data = results };
    }
}