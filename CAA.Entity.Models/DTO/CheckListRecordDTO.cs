using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("CheckListRecord", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    [Serializable]
    public class CheckListRecordDTO : BaseEntity
    {
        [Column("Option")]
        public int Option { get; set; }

        [Column("OptionNumber")]
        public int OptionNumber { get; set; }

        [Column("Remark")]
        public string Remark { get; set; }

        [Column("CheckListId")]
        public int CheckListId { get; set; }

        #region Navigation Property

        [JsonIgnore]
        public CheckListDTO CheckList { get; set; }

        #endregion
    }
}
