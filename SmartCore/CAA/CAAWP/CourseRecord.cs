using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.CAAWP
{
    [CAADto(typeof(CourseRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CourseRecord : BaseEntityObject
    {
        public CourseRecord()
        {
            SmartCoreObjectType = SmartCoreType.Aircraft;
        }
        
        public int SpecialistId { get; set; }
        public int ObjectId { get; set; }
        public int WorkPackageId { get; set; }
        public string SettingsJSON{ get; set; }
        public CAAEducationManagment Parent { get; set; }
        public Document CloseDocument { get; set; }
    }
}
