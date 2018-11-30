using System.Collections.Generic;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;

namespace SmartCore.Discrepancies
{
	public interface IDiscrepanciesCore
	{
		List<Discrepancy> GetDiscrepancies(Aircraft aircraft = null);
	}
}