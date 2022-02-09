using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;

namespace CAA.Entity.Models.DTO
{
    public enum RevisionType
    {
        Edition = 0,
        Revision = 1
    }

    [Table("CheckListRevision", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListRevisionDTO: BaseEntity,IOperatable
    {
        [Column("Number")]
        public string Number { get; set; }

        [Column("Type")]
        public RevisionType Type { get; set; }

        [Column("OperatorId")]
        public int OperatorId{ get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Column("EffDate")]
        public DateTime EffDate { get; set; }

        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
    }
}