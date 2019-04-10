using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SmsEventTypeMap : BaseMap<SmsEventTypeDTO>
	{
		public SmsEventTypeMap() : base()
		{
			ToTable("dbo.SmsEventTypes");

			Property(i => i.FullName)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			Property(i => i.Description)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");
		}
	}
}