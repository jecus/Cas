using SmartCore.CAA.RoutineAudits;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace SmartCore.CAA.PEL
{
    public class PelSpecialist : BaseEntityObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        
        private Specialization _specialization;
        public Specialization Specialization
        {
            get { return _specialization ?? Specialization.Unknown; }
            set { _specialization = value; }
        }
        
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
        
        
        
        
    }
}