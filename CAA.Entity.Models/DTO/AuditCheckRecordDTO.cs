using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("AuditCheckRecor", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public  class AuditCheckRecordDTO : BaseEntity
    {
        [Column("CheckListRecordId")]
        public int CheckListRecordId { get; set; }

        [Column("IsChecked")]
        public bool IsChecked { get; set; }
    }
}
