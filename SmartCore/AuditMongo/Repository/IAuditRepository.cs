﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Abstractions;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.AuditMongo.Repository
{
	public enum AuditOperation : byte
	{
		SignIn, // Залогинился
		SignOut, // ВЫлогинился)))
		Created, // Добавление в БД
		Changed, // Изменение
		Deleted, // Удаление
		ReportOpened // Открытие отчета
	}

	public interface IAuditRepository
	{
		Task WriteAsync<TEntity>(TEntity target, AuditOperation operation, IIdentityUser user,
			Dictionary<string, object> parameters = null) where TEntity : class, IBaseEntityObject;

		Task WriteReportAsync(IIdentityUser user, string reportName);
	}
}