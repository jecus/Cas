using System;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Check
{
    [CAADto(typeof(CheckListRevisionRecordDTO))]
    [Serializable]
    public class CheckListRevisionRecord : BaseEntityObject
    {
        public int CheckListId { get; set; }

        public DateTime Date { get; set; }

        public DateTime EffDate { get; set; }

        public string SettingsJSON { get; set; }
        public int ParentId { get; set; }
        public CheckListRevision Parent { get; set; }


        public CheckListRevisionRecord()
        {
            Date = DateTime.Today;
            EffDate = DateTime.Today;
        }
    }
}
