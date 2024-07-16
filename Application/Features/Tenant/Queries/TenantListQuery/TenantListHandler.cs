using Application.DTO;
using Application.Interfaces;
using Application.QueryExtensions;
using MediatR;

namespace Application.Features.Tenant.Queries.TenantListQuery;

public class TenantListHandler : IRequestHandler<TenantListQuery,PaginatedResponse<Domain.Entities.Tenant>>
{
    private readonly IApplicationDBContext _dbContext;

    public TenantListHandler(IApplicationDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<PaginatedResponse<Domain.Entities.Tenant>> Handle(TenantListQuery request, CancellationToken cancellationToken)
    {
        return this.process(request, cancellationToken);
    }
    
    private async  Task<PaginatedResponse<Domain.Entities.Tenant>> process(TenantListQuery request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Tenants.AsQueryable();
        
        
        if (!string.IsNullOrEmpty(request.searchText))
        {
            query = query.Where(d => d.Name.Contains(request.searchText) || d.Name.Contains(request.searchText));
        }
        
        if (request.id is not null)
        {
            query = query.Where(config => config.Id == Int32.Parse(request.id));
        }

        if (request.limit < -1)
        {
            request.limit = -1;
        }

        if (request.page is null)
        {
            request.page = 0;
        }
        
        return await query.ToPaginationResponse(request, cancellationToken);
        
    }

}