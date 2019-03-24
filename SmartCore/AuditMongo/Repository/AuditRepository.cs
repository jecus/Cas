using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EFCore.DTO.General;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.AuditMongo.Repository
{
	public class AuditRepository : IAuditRepository
	{
		private readonly AuditContext _context;

		public AuditRepository(AuditContext context)
		{
			_context = context;
		}

		#region Implementation of IAuditRepository

		public async Task WriteAsync<TEntity>(TEntity target, AuditOperation operation, UserDTO user, Dictionary<string, object> parameters = null) where TEntity : class, IBaseEntityObject
		{
			var objectName = typeof(TEntity).Name;

			await _context.AuditCollection.InsertOneAsync(new AuditEntity
			{
				Action = $"{objectName}{operation}",
				Date = DateTime.UtcNow,
				ObjectId = target.ItemId,
				ObjectTypeId = target.SmartCoreObjectType.ItemId,
				UserId = user.ItemId,
				AdditionalParameters = parameters
			});
		}

		#endregion
	}
}