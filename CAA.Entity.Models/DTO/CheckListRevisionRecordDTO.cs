using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    
    [Table("CheckListRevisionRecord", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListRevisionRecordDTO: BaseEntity
    {
        [Column("CheckListId")]
        public int CheckListId { get; set; }

        [Column("ParentId")]
        public int ParentId { get; set; }
        
        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("EffDate")]
        public DateTime EffDate{ get; set; }

        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
    }
}