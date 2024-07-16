using MediatR;

namespace Application.Features.Tenant.Command.TenantCreate;

public class TenantCreateCommand : IRequest<Domain.Entities.Tenant>
{
    public Domain.Entities.Tenant model { get; set; }
}