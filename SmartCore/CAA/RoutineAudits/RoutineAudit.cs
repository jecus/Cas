using System;
using CAA.Entity.Models.DTO;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.RoutineAudits
{
    [CAADto(typeof(RoutineAuditDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class RoutineAudit : BaseEntityObject, IRoutineAuditFilterParams
    {
        [FormControl(350, "AuditNumber:", 1, Order = 1)]
        public string AuditNumber { get; set; }

        [FormControl(350, "Type:", 1, Order = 2)]
        public string Type { get; set; }

        [FormControl(350, "Title:", 1, Order = 3)]
        public string Title { get; set; }

        [FormControl(350, "Description:", 1, Order = 4, Height = 100)]
        public string Description { get; set; }

        [FormControl(350, "Remark:", 1, Order = 5, Height = 100)]
        public string Remark { get; set; }

        public int AuthorId { get; set; }

        public DateTime Created { get; set; }


        public RoutineAudit()
        {
            SmartCoreObjectType = SmartCoreType.RoutineAudit;
            ItemId = -1;
        }

        public override BaseEntityObject GetCopyUnsaved(bool marked = true)
        {
            var clone = (RoutineAudit)MemberwiseClone();
            clone.ItemId = -1;
            clone.UnSetEvents();

            if (marked)
                clone.Title += " Copy";


            return clone;
        }
    }
}
