using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("AuditRecords", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CAAAuditRecordDTO : BaseEntity
    {
        [Column("RoutineAuditId")]
        public int RoutineAuditId { get; set; }

        [Column("AuditId")]
        public int AuditId { get; set; }
    }
}
