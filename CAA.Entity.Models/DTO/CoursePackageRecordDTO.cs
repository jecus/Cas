using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    
    [Table("CourseRecords", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CoursePackageRecordDTO : BaseEntity
    {
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }

        [Column("WorkPackageId")]
        public int WorkPackageId { get; set; }
        
        [Column("ObjectId")]
        public int ObjectId { get; set; }

        [Column("SpecialistId")]
        public int SpecialistId { get; set; }
    }

}
