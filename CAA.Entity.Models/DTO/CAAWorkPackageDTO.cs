﻿using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    
    [Table("WorkPackages", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CAAWorkPackageDTO : BaseEntity, IOperatable
    {
        [Column("Title")]
        public string Title { get; set; }
        
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }

        [Column("OperatorId")]
        public int OperatorId { get; set; }
        
    }

}