using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Aircraft
{
    public interface IAircraftFilter
    {
        [Filter("Registration Number:", Order = 1)]
        string RegistrationNumber { get; set; }


        [Filter("Serial Number:", Order = 2)]
        string SerialNumber { get; set; }

        [Filter("Variable Number:", Order = 3)]
        string VariableNumber { get; set; }

        [Filter("Line Number:", Order = 4)]
        string LineNumber { get; set; }
    }
}
