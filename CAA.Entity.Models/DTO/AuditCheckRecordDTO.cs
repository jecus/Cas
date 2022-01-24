using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("AuditCheckRecords", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public  class AuditCheckRecordDTO : BaseEntity
    {
        [Column("AuditRecordId")]
        public int AuditRecordId { get; set; }

        [Column("CheckListRecordId")]
        public int CheckListRecordId { get; set; }

        [Column("IsChecked")]
        public bool IsChecked { get; set; }
    }
}
