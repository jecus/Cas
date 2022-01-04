using System;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.FindingLevel
{
    [CAADto(typeof(FindingLevelsDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class FindingLevels : BaseEntityObject, IBaseDictionary
    {
        [FormControl(150, "Level Name:", 1, Order = 1)]
        [Filter("Level Name", Order = 1)]
        [ListViewData("Level Name",  1)]
        public string LevelName { get; set; }

        [FormControl(150, "Class:", 1, Order = 2)]
        [Filter("Class", Order = 2)]
        [ListViewData("Class", 2)]
        public LevelClass LevelClass { get; set; }

        [FormControl(150, "Color:", 1, Order = 3)]
        [Filter("Color", Order = 3)]
        [ListViewData("Color", 3)]
        public LevelColor LevelColor { get; set; }

        [FormControl(150, "Corrective Action:", 1, Order = 4)]
        [Filter("Corrective Action", Order = 4)]
        [ListViewData("Corrective Action", 4)]
        public Lifelength CorrectiveAction { get; set; }

        [FormControl(150, "Final Action:", 1, Order = 5)]
        [Filter("Final Action", Order = 5)]
        [ListViewData("Final Action", 5)]
        public Lifelength FinalAction { get; set; }

        [FormControl(150, "Remark:                                                                                       ", 1, Order = 6)]
        [Filter("Remark", Order = 6)]
        [ListViewData("Remark", 6)]
        public string Remark { get; set; }


        public FindingLevels()
        {
            FinalAction = Lifelength.Zero;
            CorrectiveAction = Lifelength.Zero;
        }
    }
}
