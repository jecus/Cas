using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;

namespace Entity.Models.DTO.General
{
	[Table("Setting", Schema = "dbo")]

	[Condition("IsDeleted", 0)]
	public class SettingDTO : BaseEntity
	{
		[Column("SettingsJSON")]
		public string SettingsJSON { get; set; }
	}
}