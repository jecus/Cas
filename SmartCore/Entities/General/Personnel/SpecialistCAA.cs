using System;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.CAA.Repositories;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistsCAA", "dbo", "ItemId")]
	[Dto(typeof(SpecialistCAADTO))]
	[CAADto(typeof(CAASpecialistCustomDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class SpecialistCAA : BaseEntityObject, ILightRemain
	{

		#region public Citizenship Caa { get; set; }
		private Citizenship _caa;
		private DateTime _issueDate;

		[TableColumn("CAAId")]
		public Citizenship Caa
		{
			get { return _caa ?? Citizenship.UNK; }
			set { _caa = value; }
		}

		#endregion

		#region public string CAANumber { get; set; } 

		[TableColumn("NumberCAA")]
		public string CAANumber { get; set; }
		#endregion

		#region public DateTime IssueDate { get; set; } 

		[TableColumn("ValidTo")]
		public DateTime ValidToDate { get; set; }
		#endregion
		
		public bool IsValidTo { get; set; }

		#region public DateTime IssueDate { get; set; } 

		[TableColumn("IssueDate")]
		public DateTime IssueDate
		{
			get { return _issueDate < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _issueDate; }
			set { _issueDate = value; }
		}

		#endregion

		#region public Lifelength NotifyLifelength { get; set; }

		[TableColumn("Notify")]
		public Lifelength NotifyLifelength { get; set; }

		#endregion

		#region public CaaType CaaType { get; set; }

		[TableColumn("CAAType")]
		public CaaType CaaType { get; set; }
		#endregion

		#region public int SpecialistLicenseId { get; set; }

		[TableColumn("SpecialistLicenseId")]
		public int SpecialistLicenseId { get; set; }

		#endregion

		#region public Document Document { get; set; }

		public Document Document { get; set; }

		#endregion

		public SpecialistCAA()
		{
			ItemId = -1;
			ValidToDate = DateTime.Today;
			IssueDate = DateTime.Today;
			SmartCoreObjectType = SmartCoreType.SpecialistCAA;
		}

		public Lifelength Remain { get; set; }
		public ConditionState Condition { get; set; }
	}

	public enum CaaType : short
	{
		Licence = 1,
		Other = 0
	}
}