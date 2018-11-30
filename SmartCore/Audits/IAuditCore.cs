using System;
using System.Collections.Generic;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Quality;

namespace SmartCore.Audits
{
	public interface IAuditCore
	{
		List<Audit> GetAudits(Operator op = null,
							 WorkPackageStatus status = WorkPackageStatus.All,
							 bool loadWorkPackageItems = false,
							 ICommonCollection includedTasks = null);

		List<Audit> GetAuditsLite(Operator op,
								  WorkPackageStatus status = WorkPackageStatus.All,
								  ICommonCollection includedTasks = null);

		void LoadAuditItems(Audit workPackage);

		Audit AddAudit(IEnumerable<NextPerformance> auditItems, Operator parentOperator, out string message);

		bool AddToAudit(List<NextPerformance> workPackageItems, int auditId, Operator parentOperator, out string message);

		void GetAuditItemsWithCalculate(Audit audit);

		void DeleteFromAudit(IBaseEntityObject record, Audit audit);

		void Publish(Audit wp, DateTime date, String remarks);
	}
}