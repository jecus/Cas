using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("AuditChecks", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class AuditCheckDTO : BaseEntity
    {
        [Column("AuditId")]
        public int AuditId { get; set; }

        [Column("CheckListId")]
        public int CheckListId { get; set; }

        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
    }
}
