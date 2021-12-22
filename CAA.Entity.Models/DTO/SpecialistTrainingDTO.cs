using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAA.Entity.Models.Dictionary;
using Entity.Abstractions;
using Entity.Abstractions.Attributte;
using Newtonsoft.Json;

namespace CAA.Entity.Models.DTO
{
	[Table("SpecialistsTraining", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class CAASpecialistTrainingDTO : BaseEntity, ICAAFileDtoContainer
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
		public CAAAccessoryDescriptionDTO AircraftType { get; set; }

		
		[Include]
		public CAAEmployeeSubjectDTO EmployeeSubject { get; set; }

		
		[Child]
		public CAASupplierDTO Supplier { get; set; }

		
		[Child(FilterType.Equal, "ParentTypeId", 1317)]
		public ICollection<CAAItemFileLinkDTO> Files { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public CAASpecialistDTO SpecialistDto { get; set; }

		#endregion
	}
}