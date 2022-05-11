using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    [Table("ConcessionRequest", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class ConcessionRequestDTO : BaseEntity
    {
        [Column("Created")]
        public DateTime Created { get; set; }
        
        [Column("From")]
        public int From { get; set; }
        
        [Column("To")]
        public int To { get; set; }
        
        [Column("Current")]
        public int Current { get; set; }
        
        [Column("Status")]
        public int Status { get; set; }
        
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
        
    }
}