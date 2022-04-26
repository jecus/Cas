using System;
using System.Collections.Generic;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.CAA.CAAEducation;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.CAAWP
{
    [CAADto(typeof(CAAWorkPackageRecordDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class CAAWorkPackageRecord : BaseEntityObject
    {
        public int ObjectId { get; set; }
        public int WorkPackageId { get; set; }
        public string SettingsJSON{ get; set; }
        public CAAEducationManagment Parent { get; set; }
    }
}
