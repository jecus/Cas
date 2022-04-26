using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    
    [Table("WorkPackageRecordss", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CAAWorkPackageRecordDTO : BaseEntity
    {
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }

        [Column("WorkPackageId")]
        public int WorkPackageId { get; set; }
        
    }

}
