using System.Threading.Tasks;
using EFCore.Interfaces;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.AuditMongo
{
	public enum AuditOperation : byte
	{
		SignIn, // Залогинился
		SignOut, // ВЫлогинился)))
		Created, // Добавление в БД
		Changed, // Изменение
		Deleted // Удаление
	}

	public interface IAuditRepository
	{
		Task WriteAsync<TEntity>(TEntity target, AuditOperation operation)
			where TEntity : class, IBaseEntityObject, IBaseEntity;
	}
}