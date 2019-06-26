using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EntityCore.DTO.General
{
	[Table("CorrectiveActions", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class CorrectiveActionDTO : BaseEntity
	{
		[DataMember]
		[Column("DiscrepancyID")]
		public int DiscrepancyID { get; set; }

		[DataMember]
		[Column("Description")]
		public string Description { get; set; }

		[DataMember]
		[Column("ShortDescription")]
		public string ShortDescription { get; set; }

		[DataMember]
		[Column("ADDNo")]
		public string ADDNo { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool IsClosed { get; set; }

		[DataMember]
		[Column("PartNumberOff"), MaxLength(50)]
		public string PartNumberOff { get; set; }

		[DataMember]
		[Column("SerialNumberOff"), MaxLength(50)]
		public string SerialNumberOff { get; set; }

		[DataMember]
		[Column("PartNumberOn"), MaxLength(50)]
		public string PartNumberOn { get; set; }

		[DataMember]
		[Column("SerialNumberOn"), MaxLength(50)]
		public string SerialNumberOn { get; set; }

		[DataMember]
		[Column("CRSID")]
		public int CRSID { get; set; }
	}
}