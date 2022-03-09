using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("CheckListTransfer", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListTransferDTO : BaseEntity
    {
        [Column("Created")]
        public DateTime Created { get; set; }

        [Column("AuditId")]
        public int AuditId { get; set; }
        
        [Column("CheckListId")]
        public int CheckListId { get; set; }
        
        [Column("From")]
        public int From { get; set; }
        
        [Column("To")]
        public int To { get; set; }
        
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
    }
}