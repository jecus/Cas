using System;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistsInstrumentRating", "dbo", "ItemId")]
	[Dto(typeof(SpecialistInstrumentRatingDTO))]
	[Condition("IsDeleted", "0")]
	public class SpecialistInstrumentRating : BaseEntityObject
	{
		#region public DateTime IssueDate { get; set; } 

		[TableColumn("IssueDate")]
		public DateTime IssueDate { get; set; }
		#endregion

		#region public int SpecialistLicenseId { get; set; }

		[TableColumn("SpecialistLicenseId")]
		public int SpecialistLicenseId { get; set; }

		#endregion

		#region public LicenseIcao Icao { get; set; }

		private LicenseIcao _icao;

		[TableColumn("IcaoId")]
		public LicenseIcao Icao
		{
			get { return _icao ?? LicenseIcao.UNK; }
			set { _icao = value; }
		}

		#endregion

		#region public int MC { get; set; }

		[TableColumn("MC")]
		public int MC { get; set; }
		#endregion

		#region public int MV { get; set; }

		[TableColumn("MV")]
		public int MV { get; set; }
		#endregion

		#region public int RVR { get; set; }

		[TableColumn("RVR")]
		public int RVR { get; set; }
		#endregion

		#region public int TORVR { get; set; }

		[TableColumn("TORVR")]
		public int TORVR { get; set; }

		#endregion

		public SpecialistInstrumentRating()
        {
            ItemId = -1;
			IssueDate = DateTime.Now;
			SmartCoreObjectType = SmartCoreType.SpecialistInstrumentRating;
		}
	}
}