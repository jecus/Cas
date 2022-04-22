using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.CAA.CAAEducation
{
    public class CAAEducationManagment : BaseEntityObject
    {
        public Specialist Specialist { get; set; }
        public Occupation Occupation { get; set; }
        public bool IsCombination { get; set; }
        public SmartCore.CAA.CAAEducation.CAAEducation Education { get; set; }
		
        public CAAEducationRecord  Record{ get; set; }

        public CAAEducationManagment()
        {
            IsCombination = true;
        }
    }
}