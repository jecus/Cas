using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class CertificateOfReleaseToServiceMap : BaseMap<CertificateOfReleaseToServiceDTO>
	{
		public CertificateOfReleaseToServiceMap() : base()
		{
			ToTable("dbo.CRSs");

			Property(i => i.Station)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Station");

			Property(i => i.RecordDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RecordDate");

			Property(i => i.CheckPerformed)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckPerformed");

			Property(i => i.Reference)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Reference");

			Property(i => i.AuthorizationB1Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AuthorizationB1Id");

			Property(i => i.AuthorizationB2Id)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AuthorizationB2Id");


			HasRequired(i => i.AuthorizationB1)
				.WithMany(i => i.CertificateOfReleaseToServiceB1Dtos)
				.HasForeignKey(i => i.AuthorizationB1Id);

			HasRequired(i => i.AuthorizationB2)
				.WithMany(i => i.CertificateOfReleaseToServiceB2Dtos)
				.HasForeignKey(i => i.AuthorizationB2Id);

		}
	}
}