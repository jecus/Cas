using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistCAAMap : BaseMap<SpecialistCAADTO>
	{
		public SpecialistCAAMap() : base()
		{
			ToTable("dbo.SpecialistsCAA");

			Property(i => i.NumberCAA)
				.HasMaxLength(25)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NumberCAA");

			Property(i => i.CAAId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CAAId");

			Property(i => i.CAAType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CAAType");

			Property(i => i.ValidTo)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ValidTo");

			Property(i => i.SpecialistLicenseId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistLicenseId");

			Property(i => i.Notify)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Notify");

			Property(i => i.IssueDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDate");
		}
	}
}