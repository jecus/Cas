using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("RootCauses", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class RootCauseDTO : BaseEntity, IOperatable
    {
        [Column("CategoryNumber"), MaxLength(250)]
        public string CategoryNumber { get; set; }
        [Column("CategoryName"), MaxLength(250)]
        public string CategoryName { get; set; }
        [Column("Remark")]
        public string Remark { get; set; }
        [Column("OperatorId")]
        public int OperatorId { get; set; }
    }
}
