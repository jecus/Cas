using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Operators
{
    public interface IAllOperatorFilterParams
    {
        [Filter("Name:", Order = 1)]
        string FullName { get; }

        [Filter("Type:", Order = 2)]
        string TypeString { get; }

        [Filter("ICAOCode:", Order = 3)]
        string ICAOCode { get; }

        [Filter("IATA:", Order = 4)]
        string IATACode { get; }

        [Filter("CAT/NC:", Order = 5)]
        string CommertialString { get; }

        [Filter("Type of Operation:", Order = 6)]
        string TPOString { get; }

        [Filter("SPO:", Order = 7)]
        string SPOString { get; }

        [Filter("Fleet:", Order = 8)]
        string FleetString { get; }

        [Filter("Aircraft Type:", Order = 9)]
        string Description { get; }

        [Filter("Privilages:", Order = 10)]
        string PrivilagesString { get; }

        [Filter("Address:", Order = 11)]
        string Address { get; }

        [Filter("Fax:", Order = 12)]
        string Fax { get; }

        [Filter("Web:", Order = 13)]
        string Web { get; }

        [Filter("Email:", Order = 14)]
        string Email { get; }

    }
}
