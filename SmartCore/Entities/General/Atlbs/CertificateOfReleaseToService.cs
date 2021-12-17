using System;
using CAS.Entity.Models.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;

namespace SmartCore.Entities.General.Atlbs
{

	/// <summary>
	/// ������ �� ���������� ������������ ���������� �����
	/// </summary>
	[Table("CRSs", "dbo", "ItemId")]
	[Dto(typeof(CertificateOfReleaseToServiceDTO))]
	[Serializable]
	public class CertificateOfReleaseToService : AbstractRecord // : LoggableType
	{

		#region public string Station
		/// <summary>
		/// ��������, ���� ��, ��� ��������� ���������� �������
		/// </summary>
		private string _station;
		/// <summary>
		/// ��������, ���� ��, ��� ��������� ���������� �������
		/// </summary>
		[TableColumnAttribute("Station")]
		public string Station
		{
			get { return _station ?? ""; }
			set
			{
		   //     ModificationApplied(_Station, value);
				_station = value;
			}
		}
		#endregion

		#region public string MRO
		/// <summary>
		/// �����������, ������������� ���������� �������
		/// </summary>
		private string _mro;
		/// <summary>
		/// �����������, ������������� ���������� �������
		/// </summary>
		//[TableColumnAttribute("Station")]
		public string MRO
		{
			get { return _mro; }
			set
			{
				//     ModificationApplied(_Station, value);
				_mro = value;
			}
		}
		#endregion

		#region public Specialist AuthorizationB1
		/// <summary>
		/// �������� ������ ����������
		/// </summary>
		private Specialist _authorizationB1;
		/// <summary>
		/// �������� ������ ����������
		/// </summary>
		[TableColumnAttribute("AuthorizationB1Id"), Child(false)]
		public Specialist AuthorizationB1
		{
			get { return _authorizationB1 != null ? _authorizationB1 : Specialist.Unknown; }
			set
			{
			 //   ModificationApplied(_AuthorizationNo, value);
				_authorizationB1 = value;
			}
		}
		#endregion

		#region public Specialist AuthorizationB2
		/// <summary>
		/// �������� ������ ����������
		/// </summary>
		private Specialist _authorizationB2;
		/// <summary>
		/// �������� ������ ����������
		/// </summary>
		[TableColumnAttribute("AuthorizationB2Id"), Child(false)]
		public Specialist AuthorizationB2
		{
			get { return _authorizationB2 != null ? _authorizationB2 : Specialist.Unknown; }
			set
			{
				//   ModificationApplied(_AuthorizationNo, value);
				_authorizationB2 = value;
			}
		}
		#endregion

		#region public string CheckPerformed
		/// <summary>
		/// ����, ������� ���� ��������� ����� �������
		/// </summary>
		private string _checkPerformed;
		/// <summary>
		/// ����, ������� ���� ��������� ����� �������
		/// </summary>
		[TableColumnAttribute("CheckPerformed")]
		public string CheckPerformed
		{
			get { return _checkPerformed; }
			set
			{
			//    ModificationApplied(_CheckPerformed, value);
				_checkPerformed = value;
			}
		}
		#endregion

		#region public string Reference

		private string _reference;
		/// <summary>
		/// ������ �� ��������, �� ��������� ��������  ���� ��������� ������� ����� ��������������� ����������
		/// </summary>
		[TableColumnAttribute("Reference")]
		public string Reference
		{
			get { return _reference; }
			set
			{
			//    ModificationApplied(reference, value);
				_reference = value;
			}
		}

		#endregion

		#region public override DateTime RecordDate { get; set; }

		private DateTime _recordDate;
		/// <summary>
		/// ���� ���������� ������
		/// </summary>
		[TableColumnAttribute("RecordDate")]
		public override DateTime RecordDate
		{
			get { return _recordDate; }
			set { _recordDate = value; }
		}
		#endregion

		#region public override Lifelength OnLifelength { get; set; }
		/// <summary>
		/// ������������ �� AbstractRecord � �� �� �����������
		/// </summary>
		public override Lifelength OnLifelength { get; set; }
		#endregion

		#region override public string Remarks { get; set; }
		/// <summary>
		/// ������������ �� AbstractRecord � �� �� �����������
		/// </summary>
		public override string Remarks { get; set; }
		#endregion
		/*
		 * ������������� �������� � ������
		 */
		public CertificateOfReleaseToService()
		{
			_recordDate = DateTime.Today;
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.CertificateOfReleaseToService;
		}
	}

}
