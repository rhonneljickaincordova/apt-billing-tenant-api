using Application.DTO;
using Domain.Interfaces;
using MediatR;

namespace Application.Features.Tenant.Queries.TenantGetQuery
{
    public class TenantGetQuery :  ISearchableSinglePrimaryKey<int>, IRequest<TenantResponseDTO>
    {
        public int Id { get; set; }
    }    
}

