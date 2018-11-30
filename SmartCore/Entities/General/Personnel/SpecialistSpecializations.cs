using System;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistSpecializations", "dbo", "ItemId")]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class SpecialistSpecializations : BaseEntityObject
	{

		#region public int SpecialistId { get; set; }

		[TableColumn("SpecialistId")]
		public int SpecialistId { get; set; }

		#endregion

		#region public Specialization Specialization { get; set; }

		private Specialization _specialization;

		[TableColumnAttribute("SpecializationId")]
		public Specialization Specialization
		{
			get { return _specialization ?? Specialization.Unknown; }
			set { _specialization = value; }
		}

		#endregion
	}
}