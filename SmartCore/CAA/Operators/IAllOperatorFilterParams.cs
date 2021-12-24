using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Operators
{
    public interface IAllOperatorFilterParams
    {
        [Filter("Full Name:", Order = 1)]
        string FullName { get; }

        [Filter("Short Name:", Order = 2)]
        string ShortName { get; }

        [Filter("ICAOCode:", Order = 3)]
        string ICAOCode { get; }

        [Filter("Address:", Order = 4)]
        string Address { get; }

        [Filter("Phone:", Order = 5)]
        string Phone { get; }

        [Filter("Fax:", Order = 6)]
        string Fax { get; }

        [Filter("Web:", Order = 7)]
        string Web { get; }

        [Filter("Email:", Order = 8)]
        string Email { get; }

    }
}
