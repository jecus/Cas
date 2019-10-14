using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("Setting", Schema = "dbo")]

	[Condition("IsDeleted", 0)]
	public class SettingDTO : BaseEntity
	{
		[Column("SettingsJSON")]
		public string SettingsJSON { get; set; }
	}
}