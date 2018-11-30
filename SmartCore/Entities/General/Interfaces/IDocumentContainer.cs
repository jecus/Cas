namespace SmartCore.Entities.General.Interfaces
{
	public interface IDocumentContainer : IBaseEntityObject
	{
		BaseEntityObject Parent { get; set; }
	}
}