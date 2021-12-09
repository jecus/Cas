namespace Entity.Models.DTO
{
	public interface IBaseEntity
	{
		bool IsDeleted { get; set; }
		int ItemId { get; set; }
	}
}