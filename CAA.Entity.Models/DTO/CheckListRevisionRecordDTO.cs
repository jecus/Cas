using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
    
    [Table("CheckListRevisionRecord", Schema = "dbo")]
    [Condition("IsDeleted", 0)]
    public class CheckListRevisionRecordDTO: BaseEntity
    {
        [Column("CheckListId")]
        public int CheckListId { get; set; }

        [Column("ParentId")]
        public int ParentId { get; set; }
        
        [Column("SettingsJSON")]
        public string SettingsJSON { get; set; }
        
        
        public CheckListRevisionRecordDTOSettings Settings
        {
            get
            {
                return string.IsNullOrWhiteSpace(SettingsJSON)
                    ? new CheckListRevisionRecordDTOSettings()
                    : JsonConvert.DeserializeObject<CheckListRevisionRecordDTOSettings>(SettingsJSON);
            }
        }
    }
    
    public class CheckListRevisionRecordDTOSettings
    {
        [JsonProperty("RevisionCheckType", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(RevisionCheckType.None)]
        public RevisionCheckType RevisionCheckType { get; set; }
    }
    
    [Serializable]
    public enum RevisionCheckType : byte
    {
        None = 0,
        New = 1,
        Del = 2,
        Mod =3
       
    }
}