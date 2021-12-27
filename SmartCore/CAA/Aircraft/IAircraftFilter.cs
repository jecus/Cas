namespace SmartCore.CAA.Aircraft
{
    public interface IAircraftFilter
    {
        string RegistrationNumber { get; set; }
        string SerialNumber { get; set; }
        string VariableNumber { get; set; }
        string LineNumber { get; set; }
    }
}
