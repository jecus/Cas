using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class OperatorMap : BaseMap<OperatorDTO>
	{
		public OperatorMap() : base()
		{
			ToTable("dbo.Operators");

			Property(i => i.Name)
				.IsRequired()
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.LogoType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnType("image")
				.HasColumnName("LogoType");

			Property(i => i.ICAOCode)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasMaxLength(50)
				.HasColumnName("ICAOCode");

			Property(i => i.Address)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasMaxLength(200)
				.HasColumnName("Address");

			Property(i => i.Phone)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasMaxLength(100)
				.HasColumnName("Phone");

			Property(i => i.Fax)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasMaxLength(100)
				.HasColumnName("Fax");

			Property(i => i.LogoTypeWhite)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnType("image")
				.HasColumnName("LogoTypeWhite");

			Property(i => i.Email)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Email");

			Property(i => i.LogotypeReportLarge)
				.HasColumnType("image")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LogotypeReportLarge");

			Property(i => i.LogotypeReportVeryLarge)
				.HasColumnType("image")
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LogotypeReportVeryLarge");

		}
	}
}