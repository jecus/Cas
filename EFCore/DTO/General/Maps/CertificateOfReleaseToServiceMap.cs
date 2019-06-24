using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class CertificateOfReleaseToServiceMap : BaseMap<CertificateOfReleaseToServiceDTO>
	{
		public CertificateOfReleaseToServiceMap() : base()
		{
			HasRequired(i => i.AuthorizationB1)
				.WithMany(i => i.CertificateOfReleaseToServiceB1Dtos)
				.HasForeignKey(i => i.AuthorizationB1Id);

			HasRequired(i => i.AuthorizationB2)
				.WithMany(i => i.CertificateOfReleaseToServiceB2Dtos)
				.HasForeignKey(i => i.AuthorizationB2Id);

		}
	}
}