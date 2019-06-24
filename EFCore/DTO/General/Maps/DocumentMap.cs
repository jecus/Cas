using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DocumentMap : BaseMap<DocumentDTO>
	{
		public DocumentMap() : base()
		{
			HasRequired(i => i.DocumentSubType)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.SubTypeId);

			HasRequired(i => i.Supplier)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.SupplierId);

			HasRequired(i => i.ResponsibleOccupation)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.ResponsibleOccupationId);

			HasRequired(i => i.Nomenсlature)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.NomenсlatureId);

			HasRequired(i => i.ServiceType)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.ServiceTypeId);

			HasRequired(i => i.Department)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.DepartmentId);

			HasRequired(i => i.Location)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.LocationId);

		}
	}
}