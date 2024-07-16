using System.Data.Entity;
using Application.DTO;
using Application.Interfaces;
using Application.Mappers;
using MediatR;

namespace Application.Features.Tenant.Queries.TenantGetQuery
{

    public class TenantGetHandler : IRequestHandler<TenantGetQuery, TenantResponseDTO>
    {
        
        private readonly IApplicationDBContext _dbContext;

        public TenantGetHandler(IApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<TenantResponseDTO> Handle(TenantGetQuery request, CancellationToken cancellationToken)
        {
            return Process(request, cancellationToken);
            
        }

        private async  Task<TenantResponseDTO> Process(TenantGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var query = _dbContext.Tenants.AsQueryable();
                if (request.Id > 0)
                {
                    query.Where(t => t.Id == request.Id);
                }

                var tenantResponse = await query.FirstOrDefaultAsync(cancellationToken);

                var mapTenantResponse = TenantResponseMapper.ToTenantResponse(tenantResponse);
                
                return mapTenantResponse;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}