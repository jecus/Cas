using System;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListRecordDTO))]
    [Serializable]
    public class CheckListRecords : BaseEntityObject
    {
        public OptionType Option { get; set; }
        public int OptionNumber { get; set; }
        public string Remark { get; set; }
        public int CheckListId { get; set; }
        public CheckLists CheckList { get; set; }

        public CheckListRecords()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.CheckListRecords;
        }
    }
}
