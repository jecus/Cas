using System;
using CAA.Entity.Models;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using SmartCore.CAA.PEL;
using SmartCore.CAA.Tasks;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.CAAEducation
{
    [CAADto(typeof(EducationDTO))]
    [Serializable]
    public class CAAEducation : BaseEntityObject, IOperatable
    {
        public int OperatorId { get; set; }
        
        public int? TaskId { get; set; }
        
        public int? OccupationId { get; set; }
        public EducationPriority Priority { get; set; }
        
        public Occupation Occupation { get; set; }
        
        public CAATask Task { get; set; }
    }
}