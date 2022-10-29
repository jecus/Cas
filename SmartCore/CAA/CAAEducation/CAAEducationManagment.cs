using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.CAA.CAAEducation
{
    [Serializable]
    public class CAAEducationManagment : BaseEntityObject,ICAAEducationManagmentFilter
    {
        public Specialist Specialist { get; set; }
        public Occupation Occupation { get; set; }
        public bool IsCombination { get; set; }
        public CAAEducation Education { get; set; }
        public CAAEducationRecord  Record{ get; set; }
        

        public CAAEducationManagment()
        {
            IsCombination = true;
        }

        public ConditionState Condition => Record?.Settings?.NextCompliance?.Condition ?? ConditionState.NotEstimated;
    }


    public interface ICAAEducationManagmentFilter
    {
        [Filter("Condition:", Order = 1)]
        ConditionState Condition { get; }
    }
}