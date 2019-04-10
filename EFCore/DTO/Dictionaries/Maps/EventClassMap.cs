using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class EventClassMap : BaseMap<EventClassDTO>
	{
		public EventClassMap() : base()
		{
			ToTable("Dictionaries.EventClasses");

			Property(i => i.FullName)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			Property(i => i.People)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("People");

			Property(i => i.Failure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Failure");

			Property(i => i.Regularity)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Regularity");

			Property(i => i.Property)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Property");

			Property(i => i.Environmental)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Environmental");

			Property(i => i.Reputation)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Reputation");

			Property(i => i.Weight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Weight");
		}
	}
}