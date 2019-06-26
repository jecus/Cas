using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
{
	[Table("SpecialistsTraining", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class SpecialistTrainingDTO : BaseEntity, IFileDtoContainer
	{
		
		[Column("SpecialistId")]
		public int? SpecialistId { get; set; }

		
		[Column("TrainingId")]
		public int? TrainingId { get; set; }

		
		[Column("SupplierId")]
		public int? SupplierId { get; set; }

		
		[Column("ManHours")]
		public double? ManHours { get; set; }

		
		[Column("Cost")]
		public double? Cost { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Column("HiddenRemark")]
		public string HiddenRemark { get; set; }

		
		[Column("Description")]
		public string Description { get; set; }

		
		[Column("Threshold"), MaxLength(200)]
		public byte[] Threshold { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		
		[Column("AircraftTypeID")]
		public int? AircraftTypeID { get; set; }

		
		[Column("EmployeeSubjectID")]
		public int? EmployeeSubjectID { get; set; }

		
		[Include]
		public AccessoryDescriptionDTO AircraftType { get; set; }

		
		[Include]
		public EmployeeSubjectDTO EmployeeSubject { get; set; }

		
		[Child]
		public SupplierDTO Supplier { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1317)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }


		#region Navigation Property

		
		public SpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}