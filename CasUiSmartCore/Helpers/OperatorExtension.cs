using SmartCore.CAA;
using SmartCore.Entities.General;

namespace CAS.UI.Helpers
{
    public static class OperatorExtension
    {
        public static Operator ToOperator(this AllOperators oper)
        {
            return new Operator()
            {
                ItemId = oper.ItemId,
                Address = oper.Address,
                Email = oper.Email,
                Fax = oper.Fax,
                ICAOCode = oper.ICAOCode,
                CorrectorId = oper.CorrectorId,
                IsDeleted = oper.IsDeleted,
                LogoTypeImage = oper.LogoTypeImage,
                LogoTypeWhiteImage = oper.LogoTypeWhiteImage,
                LogotypeReportLargeImage = oper.LogotypeReportLargeImage,
                LogotypeReportVeryLargeImage = oper.LogotypeReportVeryLargeImage,
                Name = oper.FullName,
                Phone = oper.Phone,
            };
        }

    }
}
