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

		public async Task WriteAsync<TEntity>(TEntity target, AuditOperation operation, IIdentityUser user, Dictionary<string, object> parameters = null) where TEntity : class, IBaseEntityObject
		{
			try
			{
				if(_context == null)
					return;

				if (target.IsDeleted)
					operation = AuditOperation.Deleted;

				if (target.SmartCoreObjectType.ItemId == -1)
				{
					if(parameters == null)
						parameters = new Dictionary<string, object>();

					parameters.Add("ObjectType", typeof(TEntity).UnderlyingSystemType.Name);
				}

				await _context.AuditCollection.InsertOneAsync(new AuditEntity
				{
					//Action = $"{objectName}{operation}",
					Action = $"{operation}",
					Date = DateTime.UtcNow,
					ObjectId = target?.ItemId ?? -1,
					ObjectTypeId = target?.SmartCoreObjectType.ItemId ?? -1,
					UserId = user.ItemId,
					AdditionalParameters = parameters
				});
			}
			catch
			{}
		}

		public async Task WriteReportAsync(IIdentityUser user, string reportName)
		{
			try
			{
				if (_context == null)
					return;

				await _context.AuditCollection.InsertOneAsync(new AuditEntity
				{
					Action = $"{AuditOperation.ReportOpened}",
					Date = DateTime.UtcNow,
					ObjectId = -1,
					ObjectTypeId = -1,
					UserId = user.ItemId,
					AdditionalParameters = new Dictionary<string, object>()
					{
						["ReportName"] = reportName
					}
				});
			}
			catch
			{ }
		}

		#endregion
	}
}