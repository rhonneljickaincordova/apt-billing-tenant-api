using Application.Interfaces;
using MediatR;

namespace Application.Features.Tenant.Command.TenantCreate;

public class TenantCreateHandler: IRequestHandler<TenantCreateCommand, Domain.Entities.Tenant>
{
    private readonly IApplicationDBContext _dbContext;
    
    public TenantCreateHandler(IApplicationDBContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<Domain.Entities.Tenant> Handle(TenantCreateCommand request, CancellationToken cancellationToken)
    {
        return await Process(request, cancellationToken);
    }

    private async Task<Domain.Entities.Tenant> Process(TenantCreateCommand request, CancellationToken cancellationToken)
    {
        _dbContext.Tenants.Add(request.model);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return request.model;
    }
}