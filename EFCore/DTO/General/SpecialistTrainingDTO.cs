using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecialistTrainingDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int SpecialistId { get; set; }

		[DataMember]
		public int? TrainingId { get; set; }

		[DataMember]
		public int? SupplierId { get; set; }

		[DataMember]
		public double? ManHours { get; set; }

		[DataMember]
		public double? Cost { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public string HiddenRemark { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public byte[] Threshold { get; set; }

		[DataMember]
		public bool? IsClosed { get; set; }

		[DataMember]
		public int AircraftTypeID { get; set; }

		[DataMember]
		public int EmployeeSubjectID { get; set; }

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