using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.Dictionary
{
    [Table("FindingLevels", Schema = "Dictionaries")]

    [Condition("IsDeleted", 0)]
    public class FindingLevelsDTO : BaseEntity, IBaseDictionary
    {
        [Column("LevelName")]
        public string LevelName { get; set; }

        [Column("LevelClass")]
        public LevelClass LevelClass { get; set; }

        [Column("LevelColor")]
        public LevelColor LevelColor { get; set; }

        [Column("CorrectiveAction"), MaxLength(50)]
        public byte[] CorrectiveAction { get; set; }

        [Column("FinalAction"), MaxLength(50)]
        public byte[] FinalAction { get; set; }

        [Column("Remark")]
        public string Remark { get; set; }
    }
}
