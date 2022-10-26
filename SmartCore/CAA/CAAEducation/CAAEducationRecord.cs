using System;
using System.Collections.Generic;
using System.ComponentModel;
using CAA.Entity.Models;
using CAA.Entity.Models.Dictionary;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.CAA.PEL;
using SmartCore.CAA.Tasks;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.CAA.CAAEducation
{
    [CAADto(typeof(EducationRecordsDTO))]
    [Serializable]
    public class CAAEducationRecord : BaseEntityObject, IOperatable
    {
	    public int OperatorId { get; set; }
	    public int SpecialistId { get; set; }
	    public int OccupationId { get; set; }
	    public int EducationId { get; set; }
	    public CAAEducation Education { get; set; }
	    
	    public int PriorityId { get; set; }

	    public string SettingsJSON
	    {
		    get
		    {
			    if (Settings == null)
				    return null;

			    return JsonConvert.SerializeObject(Settings,
				    Formatting.Indented,
				    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		    }

		    set => Settings = string.IsNullOrWhiteSpace(value) ? new CAAEducationRecordSettings() : JsonConvert.DeserializeObject<CAAEducationRecordSettings>(value);
	    }

	    public CAAEducationRecordSettings Settings { get; set; }
	    
	    public CAAEducationRecord()
	    {
		    SmartCoreObjectType = SmartCoreType.CAAEducationRecord;
		    Settings = new CAAEducationRecordSettings();
	    }
	    
    }
    
    
    [Serializable]
    public class CAAEducationRecordSettings
    {
	    public CAAEducationRecordSettings()
	    {
		    LastCompliances = new List<CAAEducationLastCompliance>();
	    }
	    
	    private List<CAAEducationLastCompliance> _lastCompliances;

	    [JsonProperty]
	    public bool IsCombination { get; set; }
	    
	    [JsonProperty]
	    public bool IsClosed { get; set; }
	    

	    [JsonProperty]
	    public List<CAAEducationLastCompliance> LastCompliances
	    {
		    get => _lastCompliances ?? (_lastCompliances = new List<CAAEducationLastCompliance>());
		    set => _lastCompliances = value;
	    }
	    
	    [JsonIgnore]
	    public NextCompliance NextCompliance { get; set; }
	    
	    [JsonIgnore]
	    public List<NextCompliance> NextCompliances { get; set; }
	    
	    [JsonProperty]
	    public int? BlockedWpId { get; set; }
    }

    
    [Serializable]
    public class NextCompliance
    {
	    public NextCompliance()
	    {
		    Condition = ConditionState.Satisfactory;
	    }
	    
	    [JsonIgnore]
	    public DateTime? NextDate { get; set; }

	    [JsonIgnore]
	    public Lifelength Remains { get; set; }
	    
	    [JsonIgnore]
	    public ConditionState Condition { get; set; }
    }


    [Serializable]
    public class CAAEducationLastCompliance  : BaseEntityObject
    {
	    
	    private Lifelength _repeat;
	    private byte[] _repeatByte;
	    public CAAEducationLastCompliance()
	    {
		    LastDate = DateTime.Now;
		    Repeat = Lifelength.Null;
	    }

    [JsonProperty] public DateTime? LastDate { get; set; }

    [JsonProperty] public string Remark { get; set; }
    
    [JsonProperty] 
    [DefaultValue(false)] 
    public bool IsAircraft { get; set; }
    
    [JsonProperty] 
    [DefaultValue(-1)] 
    public int AircraftId { get; set; }
    
    
    [JsonProperty] 
    [DefaultValue(false)] 
    public bool IsLevel { get; set; }
    
    [JsonProperty] 
    [DefaultValue(-1)] 
    public int LevelId { get; set; }
    
    [JsonProperty] 
    [DefaultValue(false)] 
    public bool IsRepeat { get; set; }
    
    [JsonProperty]
    public byte[] RepeatByte
    {
	    get => _repeatByte;
	    set
	    {
		    _repeatByte = value;
		    _repeat = Lifelength.ConvertFromByteArray(value);
	    }
    }
    
    
    [JsonIgnore]
    public Lifelength Repeat
    {
	    get => _repeat;
	    set
	    {
		    _repeat = value;
		    _repeatByte = value.ConvertToByteArray();
	    }
    }

    [JsonProperty] public int? DocumentId { get; set; }

    [JsonIgnore] public Document Document { get; set; }
    
    }


    [Serializable]
    public class LastComplianceView : BaseEntityObject
    {
	    public CAAEducationRecord Record { get; set; }
	    public CAAEducationLastCompliance  LastCompliance{ get; set; }
	    public string Group { get; set; }
	    public string Course { get; set; }
	    
    }

}