using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("CheckList", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListDTO : BaseEntity,IOperatable
    {
        [Column("Source")]
        public string Source { get; set; }
        
        [Column("EditionId")]
        public int  EditionId{ get; set; }

        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }



        #region Navigation Property

        [Child]
        public ICollection<CheckListRecordDTO> CheckListRecords { get; set; }

        #endregion

        [Column("OperatorId")]
        public int OperatorId { get; set; }
    }

}
