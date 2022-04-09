using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("RoutineAuditRecords", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class RoutineAuditRecordDTO : BaseEntity
    {
        [Column("RoutineAuditId")]
        public int RoutineAuditId { get; set; }

        [Column("CheckListId")]
        public int CheckListId { get; set; }
    }
}
