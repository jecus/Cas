using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("Audit", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CAAAuditDTO : BaseEntity, IOperatable
    {

        [Column("AuditNumber")]
        public string AuditNumber { get; set; }


        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }

        [Column("OperatorId")]
        public int OperatorId { get; set; }
    }

}
