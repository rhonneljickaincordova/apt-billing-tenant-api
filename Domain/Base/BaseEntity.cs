using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interfaces;

namespace Domain.Base;


public class BaseEntity :  IAuditableEntity
{
    [Column("dateCreated")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime dateCreated { get; set; }

    [Column("dateUpdated", TypeName = "timestamp")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime dateUpdated { get; set; }

}