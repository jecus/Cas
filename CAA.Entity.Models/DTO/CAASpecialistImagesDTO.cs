using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    [Table("SpecialistImages", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CAASpecialistImagesDTO : BaseEntity, IOperatable
    {
        [Column("OperatorId")]
        public int OperatorId { get; set; }
        
        [Column("SpecialistId")]
        public int SpecialistId { get; set; }
        
        [Column("Sign")]
        public byte[] Sign { get; set; }
		
        [Column("Stamp")]
        public byte[] Stamp { get; set; }
        
        [Column("Photo")]
        public byte[] Photo { get; set; }
    }
}