using Application.DTO;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Tenant.Queries.TenantListQuery;

public class TenantListQuery: IPagination, IRequest<PaginatedResponse<Domain.Entities.Tenant>>
{
    public string? searchText { get; set; }
    public int? limit { get; set; }
    public int? page { get; set; }
    
    public string[]? orderBy { get; set; }
    public string? id { get; set; }
}