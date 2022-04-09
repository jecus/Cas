using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("StandartManual", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class StandartManualDTO : BaseEntity,IOperatable
    {
        [Column("Source")]
        public string Source { get; set; }
        
        public string SettingsJSON{ get; set; }
        
        [Column("OperatorId")]
        public int OperatorId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int ProgramTypeId { get; set; }
    }
    
}
