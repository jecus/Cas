using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("RoutineAudits", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class RoutineAuditDTO : BaseEntity
    {
        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Remark")]
        public string Remark { get; set; }

        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }

    }
}
