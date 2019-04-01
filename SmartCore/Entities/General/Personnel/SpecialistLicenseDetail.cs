using System;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistsLicenseDetail", "dbo", "ItemId")]
	[Dto(typeof(SpecialistLicenseDetailDTO))]
	[Condition("IsDeleted", "0")]
	public class SpecialistLicenseDetail : BaseEntityObject
	{
		#region public DateTime IssueDate { get; set; } 

		[TableColumn("IssueDate")]
		public DateTime IssueDate { get; set; }
		#endregion

		#region public string Description { get; set; }

		[TableColumn("Description")]
		public string Description { get; set; }

		#endregion

		#region public int SpecialistLicenseId { get; set; }

		[TableColumn("SpecialistLicenseId")]
		public int SpecialistLicenseId { get; set; }

		#endregion

		#region public int SpecialistId { get; set; }

		[TableColumn("SpecialistId")]
		public int SpecialistId { get; set; }

		#endregion

		public SpecialistLicenseDetail()
        {
            ItemId = -1;
			IssueDate = DateTime.Today;
			SmartCoreObjectType = SmartCoreType.SpecialistLicenseDetail;
		}
	}
}