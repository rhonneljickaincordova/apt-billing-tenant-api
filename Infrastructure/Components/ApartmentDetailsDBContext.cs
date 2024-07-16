using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Components;

public class ApartmentDetailsDbContext : DbContext, IApplicationDBContext
{

    public ApartmentDetailsDbContext()
    {
    }
    
    public ApartmentDetailsDbContext(DbContextOptions<ApartmentDetailsDbContext> options)
        : base(options)
    {
    }

    public DbSet<Tenant> Tenants { get; set; }
    
    public void ModifiedEntity<T>(T target, T comparingObj, string[]? includingColumns = null, string[]? ignoringColumns = null) where T : IBaseEntity, IAuditableEntity
    {
        var comparingWithEntity = Entry(comparingObj);
			
        foreach (var propertyEntry in Entry(target).Properties)
        {
            var property = propertyEntry.Metadata;
            var ciPropertyName = property.Name.ToUpper();
            // Skip shadow and key properties
            if (property.Name == "createdDate" || property.IsShadowProperty() || (propertyEntry.EntityEntry.IsKeySet && property.IsKey())) continue;
				
            if (ignoringColumns is not null && ignoringColumns.Select(a=>a.ToUpper()).Contains(ciPropertyName)) continue;
            if (includingColumns is not null && !includingColumns.Select(a=>a.ToUpper()).Contains(ciPropertyName)) continue;

            propertyEntry.CurrentValue = comparingWithEntity.Properties
                .FirstOrDefault(p => p.Metadata.Name == property.Name)?.CurrentValue ?? propertyEntry.CurrentValue;
				
            if (propertyEntry.CurrentValue != propertyEntry.OriginalValue) {
                propertyEntry.IsModified = true;
            }
        }	
    }
}