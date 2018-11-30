using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("WorkPackageSpecialists", "dbo", "ItemId")]
	[Dto(typeof(WorkPackageSpecialistsDTO))]
	[Condition("IsDeleted", "0")]
	public class WorkPackageSpecialists : BaseEntityObject
	{
		private static Type _thisType;

		#region public int SpecialistId { get; set; }

		[TableColumn("SpecialistId")]
		public int SpecialistId { get; set; }

		public static PropertyInfo SpecialistIdProperty
		{
			get { return GetCurrentType().GetProperty("SpecialistId"); }
		}

		#endregion

		#region public int WorkPackageId { get; set; }

		[TableColumn("WorkPackageId")]
		public int WorkPackageId { get; set; }

		public static PropertyInfo WorkPackageIdProperty
		{
			get { return GetCurrentType().GetProperty("WorkPackageId"); }
		}

		#endregion


		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(WorkPackageSpecialists));
		}
		#endregion
	}
}