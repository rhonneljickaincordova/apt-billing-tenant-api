namespace Application.DTO;

public class TenantResponseDTO
{
    public int Id { get;set; }
    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }
    public sbyte Active { get; set; }
    public string? Name { get; set; }
    public string? ContactNumber { get; set; }
    public string? EmergencyContactName { get; set; }
    public string? EmergencyContactNumber { get; set; }
    public string? EmergencyContactRelationship { get; set; }
    public string? IdImageUrl { get; set; }
    public string? SignitureImageUrl { get; set; }
}