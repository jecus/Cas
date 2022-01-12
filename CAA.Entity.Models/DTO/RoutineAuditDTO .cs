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
        [Column("AuditNumber")]
        public string AuditNumber { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("Title")]
        public string Title { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("Remark")]
        public string Remark { get; set; }

        [Column("AuthorId")]
        public int AuthorId { get; set; }

        [Column("Created")]
        public DateTime Created { get; set; }
    }
}
