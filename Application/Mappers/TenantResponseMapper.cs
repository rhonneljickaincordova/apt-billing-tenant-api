using Application.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Mappers;

public abstract class TenantResponseMapper : IRequest<Tenant>
{
        
    public static TenantResponseDTO ToTenantResponse(Tenant model){
        TenantResponseDTO tenantDto = new TenantResponseDTO
        {
            Id = model.Id,
            Active = model.Active,
            Name = model.Name,
            ContactNumber = model.ContactNumber,
            EmergencyContactName = model.EmergencyContactName,
            EmergencyContactNumber = model.EmergencyContactNumber,
            EmergencyContactRelationship = model.EmergencyContactRelationship,
            DateCreated = model.DateCreated
        };
        return tenantDto;
    }
    
}