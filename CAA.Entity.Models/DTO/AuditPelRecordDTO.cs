using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    
    [Table("AuditPelRecords", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class AuditPelRecordDTO: BaseEntity
    {
        [Column("AuditRecordId")]
        public int AuditId { get; set; }
        
        [Column("CheckListId")]
        public int CheckListId { get; set; }
        
        [Column("AuditorId")]
        public int AuditorId { get; set; }
        
        [Column("AuditeeId")]
        public int AuditeeId { get; set; }
        
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
        
    }
}