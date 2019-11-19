using SmartCore.Calculations;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;

namespace CAS.UI.UIControls.PurchaseControls
{
	#region public class ScheduleDirectiveProduct
	/// <summary>
	/// Описывает планирование расходника на определенное выполнение определенной задачи 
	/// </summary>
	public class ScheduleDirectiveProduct
	{
		public IDirective Directive { get; private set; }
		public NextPerformance Performance { get; private set; }
		public Product Product { get; private set; }
		public double Quantity { get; private set; }

		public ScheduleDirectiveProduct(IDirective directive,
										NextPerformance performance,
										Product product,
										double quantity)
		{
			Directive = directive;
			Performance = performance;
			Product = product;
			Quantity = quantity;
		}
	}
	#endregion
}
