using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;

namespace SmartCore.Entities
{
	public interface IKeeper
	{
		//TODO:(Evgenii Babak) первый четыре метода вынести в нужные Core
		
		void Save(BaseEntityObject obj, bool saveAttachedFile = true);

		void SaveAll(BaseEntityObject obj, bool saveChild = false, bool saveForsed = false);

		void Delete(BaseEntityObject obj, bool isDeletedOnly = false, bool saveAttachedFile = true);

		void SaveAttachedFile(IFileContainer container);

		void MarkAsDeleted<T>(ICommonFilter[] filters) where T : BaseEntityObject;

	}
}