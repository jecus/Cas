using System;
using CAA.Entity.Models.DTO;
using Newtonsoft.Json;
using SmartCore.CAA.RoutineAudits;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.CAA.PEL
{
    [CAADto(typeof(PelSpecialistDTO))]
    [Condition("IsDeleted", "0")]
    [Serializable]
    public class PelSpecialist : BaseEntityObject
    {
        public int AuditId { get; set; }
        public int SpecialistId { get; set; }
        
        public Specialist Specialist { get; set; }
        
        private PELRole _role;
        public PELRole Role
        {
            get { return _role ?? PELRole.Unknown; }
            set { _role = value; }
        }
        
        private PELResponsibilities _responsibilities;
        public PELResponsibilities PELResponsibilities
        {
            get { return _responsibilities ?? PELResponsibilities.Unknown; }
            set { _responsibilities = value; }
        }
        
        
        private PELPosition _position;
        public PELPosition PELPosition
        {
            get { return _position ?? PELPosition.Unknown; }
            set { _position = value; }
        }
        
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

            set => Settings = string.IsNullOrWhiteSpace(value) ? new PelSpecialistSettings() : JsonConvert.DeserializeObject<PelSpecialistSettings>(value);
        }

        public PelSpecialistSettings Settings { get; set; }


        public PelSpecialist()
        {
            Settings = new PelSpecialistSettings();
        }
        
        public override string ToString()
        {
            return $"{Specialist.FirstName} {Specialist.LastName} / {Role} / {PELResponsibilities} / {PELPosition}";
        }
    }


    [Serializable]
    public class PelSpecialistSettings
    {
        public PelSpecialistSettings()
        {
            
        }
    }
}