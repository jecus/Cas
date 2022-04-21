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
			    StartDate = DateTime.Today
		    };
	    }
	    
    }
    
    
    [Serializable]
    public class CAAEducationRecordSettings
    {
	    [JsonProperty]
	    public DateTime StartDate { get; set; }
	    
	    [JsonProperty]
	    public bool IsClosed { get; set; }
	    
	    [JsonProperty]
	    public Lifelength Repeat { get; set; }
	    
	    [JsonProperty]
	    public Lifelength Notify { get; set; }
    }
    
}