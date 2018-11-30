using SmartCore.Entities.Dictionaries;

namespace SmartCore.Entities.General.Interfaces
{
	public interface IComponentContainer
	{
		int ItemId { get; }
		SmartCoreType SmartCoreObjectType { get; }
	}
}