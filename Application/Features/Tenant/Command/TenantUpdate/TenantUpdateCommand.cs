using System.Data.Entity.Infrastructure.Design;
using MediatR;

namespace Application.Features.Tenant.Command.TenantUpdate;

public class TenantUpdateCommand : IRequest<Domain.Entities.Tenant>
{
    public int id { get; set; }
    public Domain.Entities.Tenant model { get; set; }
}