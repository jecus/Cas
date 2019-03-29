using System;
using EFCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Personnel
{
	[Table("SpecialistsTraining", "dbo", "ItemId")]
	[Dto(typeof(SpecialistTrainingDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class SpecialistTraining : BaseEntityObject, IFileContainer
	{
		#region public int SpecialistId { get; set; }

		[TableColumn("SpecialistId")]
		public int SpecialistId { get; set; }

		#endregion

		#region public int AircraftTypeID { get; set; }

		[TableColumn("AircraftTypeID")]
		public int AircraftTypeID { get; set; }

		public AircraftModel AircraftType
		{
			get { return _aircraftType ?? AircraftModel.Unknown; }
			set { _aircraftType = value; }
		}

		#endregion

		#region public EmployeeSubject EmployeeSubject

		[TableColumn("EmployeeSubjectID")]
		public EmployeeSubject EmployeeSubject
		{
			get { return _employeeSubject ?? EmployeeSubject.Unknown; }
			set { _employeeSubject = value; }
		}

		#endregion

		#region public TrainingType TrainingType

		private TrainingType _trainingType;
		[TableColumn("TrainingId")]
		public TrainingType TrainingType
		{
			get { return _trainingType ?? TrainingType.Unknown; }
			set { _trainingType = value; }
		}
			#endregion

		#region public Supplier Supplier { get; set; }

		[TableColumn("SupplierId")]
		[Child]
		public Supplier Supplier { get; set; }

		#endregion

		#region public double ManHours { get; set; }

		[TableColumn("ManHours")]
		public double ManHours { get; set; }

		#endregion

		#region public double Cost { get; set; }

		[TableColumn("Cost")]
		public double Cost { get; set; }

		#endregion

		#region public String Remarks { get; set; }

		[TableColumn("Remarks")]
		public String Remarks { get; set; }
		#endregion

		#region public String HiddenRemark { get; set; }

		[TableColumn("HiddenRemark")]
		public String HiddenRemark { get; set; }
		#endregion

		#region public String Description { get; set; }

		[TableColumn("Description")]
		public String Description { get; set; }

		#endregion

		#region public bool IsClosed { get; set; }

		[TableColumn("IsClosed")]
		public bool IsClosed { get; set; }
			#endregion

		#region public Attachement FaaFormFile { get; set; }
		[NonSerialized]
		private AttachedFile _formFile;
		/// <summary>
		/// 
		/// </summary>
		public AttachedFile FormFile
		{
			get
			{
				return _formFile ?? (Files.GetFileByFileLinkType(FileLinkType.TrainingFormFile));
			}
			set
			{
				_formFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.TrainingFormFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1317)]
		public CommonCollection<ItemFileLink> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
			set
			{
				if (_files != value)
				{
					if (_files != null)
						_files.Clear();
					if (value != null)
						_files = value;
				}
			}
		}

		#endregion

		#region public TrainingThreshold Threshold { get; set; }

		private TrainingThreshold _threshold;
		private AircraftModel _aircraftType;
		private EmployeeSubject _employeeSubject;

		/// <summary>
		/// Условие выполнения директивы
		/// </summary>
		[TableColumnAttribute("Threshold")]
		public TrainingThreshold Threshold
		{
			get { return _threshold ?? (_threshold = new TrainingThreshold()); }
			set { _threshold = value; }
		}
		#endregion

		#region public Document Document { get; set; }

		public Document Document { get; set; }

		#endregion

		public SpecialistTraining()
		{
			SmartCoreObjectType = SmartCoreType.SpecialistTraining;
		}

		public bool PrintInWorkPackage { get; set; }
		public bool WorkPackageACCPrintTitle { get; set; }
		public bool WorkPackageACCPrintTaskCard { get; set; }
	}
}