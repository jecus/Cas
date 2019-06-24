using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AircraftMap : BaseMap<AircraftDTO>
	{
		public AircraftMap() : base()
		{
			
			HasRequired(i => i.Model)
				.WithMany(i => i.AircraftDtos)
				.HasForeignKey(i => i.ModelId);

			HasMany(i => i.MaintenanceProgramChangeRecords).WithRequired(i => i.ParentAircraftDto).HasForeignKey(i => i.ParentAircraftId);

		}
	}
}