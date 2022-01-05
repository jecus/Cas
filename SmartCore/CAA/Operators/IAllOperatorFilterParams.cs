using System.Collections.Generic;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Operators
{
    public interface IAllOperatorFilterParams
    {
        [Filter("Name:", Order = 1)]
        string FullName { get; }

        [Filter("Type:", Order = 2)]
        Type TypeFilter { get; }

        [Filter("ICAOCode:", Order = 3)]
        string ICAOCode { get; }

        [Filter("IATA:", Order = 4)]
        string IATACode { get; }

        [Filter("CAT/NC:", Order = 5)]
        Cat CommertialFilter { get; }

        [Filter("Type of Operation:", Order = 6)]
        List<TypesOfOperations> TPOFilter { get; }

        [Filter("SPO:", Order = 7)]
        List<SpecialOperations> SPOFilter { get; }

        [Filter("Fleet:", Order = 8)]
        List<Fleet> FleetFilter { get; }

        [Filter("Aircraft Type:", Order = 9)]
        string Description { get; }

        [Filter("Privilages:", Order = 10)]
        List<Privileges> PrivilagesFilter { get; }

        [Filter("Address:", Order = 11)]
        string Address { get; }

        [Filter("Fax:", Order = 12)]
        string Fax { get; }

        [Filter("Web:", Order = 13)]
        string Web { get; }

        [Filter("Email:", Order = 14)]
        string Email { get; }

        [Filter("Ratings:", Order = 15)]
        string Ratings { get; }

    }
}
