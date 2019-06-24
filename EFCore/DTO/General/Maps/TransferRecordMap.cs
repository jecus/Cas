using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class TransferRecordMap : BaseMap<TransferRecordDTO>
	{
		public TransferRecordMap() : base()
		{
			HasRequired(i => i.ReceivedSpecialist)
				.WithMany(i => i.RecivedSpecialist)
				.HasForeignKey(i => i.ReceivedSpecialistId);

			HasRequired(i => i.ReleasedSpecialist)
				.WithMany(i => i.ReleasedSpecialist)
				.HasForeignKey(i => i.ReleasedSpecialistId);


			HasMany(i => i.Files).WithRequired(i => i.TransferRecord).HasForeignKey(i => i.ParentId);
		}
	}
}