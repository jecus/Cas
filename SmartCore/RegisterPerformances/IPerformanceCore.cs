using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Packages;

namespace SmartCore.RegisterPerformances
{
	public interface IPerformanceCore
	{
		/// <summary>
		/// Добавить выполнение работы к задаче
		/// </summary>
		/// <param name="directive"></param>
		/// <param name="performance"></param>
		/// <param name="directivePackage">Рабочий пакет, в рамках которого может производится выполнение работы. По умолчанию равен null </param>
		/// <param name="registerPerformanceForBindedItems"></param>
		void RegisterPerformance(IDirective directive, AbstractPerformanceRecord performance, IDirectivePackage directivePackage = null, bool registerPerformanceForBindedItems = true);

		void Delete(DirectiveRecord directiveRecord);
	}
}