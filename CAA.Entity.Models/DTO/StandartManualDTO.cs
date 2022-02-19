using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

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
    }
    
}
