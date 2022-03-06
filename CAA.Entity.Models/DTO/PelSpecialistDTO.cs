using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("PelSpecialist", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class PelSpecialistDTO : BaseEntity
    {
        [Column("AuditId")]
        public int AuditId { get; set; }
        
        [Column("SpecialistId")]
        public int SpecialistId { get; set; }
        
        [Column("PositionId")]
        public int PositionId { get; set; }
        
        [Column("RoleId")]
        public int RoleId { get; set; }
        
        [Column("ResponsibilitiesId")]
        public int ResponsibilitiesId { get; set; }
        
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
    }
}