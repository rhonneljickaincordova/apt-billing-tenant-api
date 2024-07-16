using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;
using Domain.Interfaces;

namespace Domain.Entities;

[Table("tenant")]
public partial class Tenant : IBaseEntity , ISearchableSinglePrimaryKey<int>
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("dateCreated")]
    [MaxLength(6)]
    public DateTime DateCreated { get; set; }

    [Column("dateUpdated")]
    [MaxLength(6)]
    public DateTime DateUpdated { get; set; }
    
    [Column("active")]
    public sbyte Active { get; set; }
    
    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }
    
    [Column("contactNumber")]
    [StringLength(255)]
    public string? ContactNumber { get; set; }

    [Column("emergencyContactName")]
    [StringLength(255)]
    public string? EmergencyContactName { get; set; }
    
    [Column("emergencyContactNumber")]
    [StringLength(255)]
    public string? EmergencyContactNumber { get; set; }

    [Column("emergencyContactRelationship")]
    [StringLength(255)]
    public string? EmergencyContactRelationship { get; set; }
    
    [Column("idImageUrl")]
    [StringLength(255)]
    public string? IdImageUrl { get; set; }

    [Column("signitureImageUrl")]
    [StringLength(255)]
    public string? SignitureImageUrl { get; set; }

}