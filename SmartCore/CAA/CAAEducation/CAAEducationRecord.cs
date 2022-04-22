using System;
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
		    Settings = new CAAEducationRecordSettings()
		    {
			    StartDate = DateTime.Today,
			    Condition = ConditionState.Satisfactory,
			    Repeat = Lifelength.Null,
			    Notify = Lifelength.Null,
		    };
	    }
	    
    }
    
    
    [Serializable]
    public class CAAEducationRecordSettings
    {
	    private byte[] _repeatByte;
	    private byte[] _notifyByte;
	    private Lifelength _repeat;
	    private Lifelength _notify;

	    [JsonProperty]
	    public DateTime StartDate { get; set; }
	    
	    [JsonProperty]
	    public bool IsClosed { get; set; }
	    
	    
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

	    [JsonProperty]
	    public byte[] NotifyByte
	    {
		    get => _notifyByte;
		    set
		    {
			    _notifyByte = value;
			    _notify = Lifelength.ConvertFromByteArray(value);
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

	    [JsonIgnore]
	    public Lifelength Notify
	    {
		    get => _notify;
		    set
		    {
			    _notify = value;
			    _notifyByte = value.ConvertToByteArray();
		    }
	    }

	    [JsonIgnore]
	    public DateTime? Next { get; set; }

	    [JsonIgnore]
	    public Lifelength Remains { get; set; }

	    [JsonIgnore]
	    public ConditionState Condition { get; set; }
    }
    
}