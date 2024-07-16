using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDBContext
{
    public DbSet<Tenant> Tenants { get; set; }
    
    public void ModifiedEntity<T>(T target, T comparingObj, string[]? includingColumns = null, string[]? ignoringColumns = null) where T : IBaseEntity, IAuditableEntity;
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}