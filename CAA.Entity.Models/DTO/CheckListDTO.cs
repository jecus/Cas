using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("CheckList", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListDTO : BaseEntity
    {
        [Column("Source")]
        public string Source { get; set; }

        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }



        #region Navigation Property

        [Child]
        public ICollection<CheckListRecordDTO> CheckListRecords { get; set; }

        #endregion



    }

}
