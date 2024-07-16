using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Tenant.Command.TenantUpdate;

public class TenantUpdateHandler : IRequestHandler<TenantUpdateCommand,Domain.Entities.Tenant>
{
 
    private readonly IApplicationDBContext _dbContext;


    public TenantUpdateHandler(IApplicationDBContext dbContext) {
        _dbContext = dbContext;
    }

    public Task<Domain.Entities.Tenant> Handle(TenantUpdateCommand request, CancellationToken cancellationToken)
    {
        return Process(request, cancellationToken);
    }

    private  async Task<Domain.Entities.Tenant> Process(TenantUpdateCommand request, CancellationToken cancellationToken)
    {
        var query = _dbContext.Tenants.AsQueryable();
        query = query.Where(t => t.Id == request.id);
        var foundModel = await query.FirstOrDefaultAsync(cancellationToken);
        if (foundModel is  null)
        {
            return null;
        }

        request.model.Id = request.id;
        _dbContext.Tenants.Entry(foundModel).CurrentValues.SetValues(request.model);
        _dbContext.Tenants.Update(foundModel);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return foundModel;

    }
}