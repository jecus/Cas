using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsTraining", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistTrainingDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		[DataMember]
		[Column("TrainingId")]
		public int? TrainingId { get; set; }

		[DataMember]
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		[DataMember]
		[Column("ManHours")]
		public double? ManHours { get; set; }

		[DataMember]
		[Column("Cost")]
		public double? Cost { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("HiddenRemark")]
		public string HiddenRemark { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("Threshold"), MaxLength(200)]
		public byte[] Threshold { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		[DataMember]
		[Column("AircraftTypeID")]
		public int? AircraftTypeID { get; set; }

		[DataMember]
		[Column("EmployeeSubjectID")]
		public int? EmployeeSubjectID { get; set; }

		[DataMember]
		[Include]
		public AccessoryDescriptionDTO AircraftType { get; set; }

		[DataMember]
		[Include]
		public EmployeeSubjectDTO EmployeeSubject { get; set; }

		[DataMember]
		[Child]
		public SupplierDTO Supplier { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1317)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }


		#region Navigation Property

		[DataMember]
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}