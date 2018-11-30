using System;
using System.Collections.Generic;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Purchase
{
	public interface IPurchaseCore
	{

		IList<Product> GetProducts(int kitId, bool loadChild = false);
		/// <summary>
		/// Возвращает все KIT -ы, находящиеся в определенном ордере запроса
		/// </summary>
		/// <returns></returns>
		List<Product> GetProducts(PurchaseOrder po);
		List<Product> GetProducts();
		List<Product> GetProducts(Supplier supplier);
		/// <summary>
		/// Возвращает Закупочные ордера воздушного судна
		/// </summary>
		/// <param name="aircraft">Воздушное судно. При пережаче null вернет все Закупочные ордера</param>
		/// <param name="status">Фильтр статуса Закупочные ордера. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="loadWorkPackageItems">Флаг загрузки элементов Закупочного ордера</param>
		/// <param name="includedAccessory">Задачи, которые должны содержать ордера (при передаче пустои коллекции запрос вернет 0 Закупочного ордера)</param>
		/// <returns></returns>
		IList<PurchaseOrder> GetPurchaseOrders(Aircraft aircraft, WorkPackageStatus status = WorkPackageStatus.All, bool loadWorkPackageItems = false, IEnumerable<AbstractAccessory> includedAccessory = null);
		/// <summary>
		/// Возвращает Котировочные ордера воздушного судна
		/// </summary>
		/// <param name="parent">Владелец котировочного оредера. При пережаче null вернет все Котировочные ордера</param>
		/// <param name="statuses">Фильтр статуса Котировочные ордера. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="loadWorkPackageItems">Флаг загрузки элементов Котировочного ордера</param>
		/// <param name="includedAccessory">Задачи, которые должны содержать ордера (при передаче пустои коллекции запрос вернет 0 Котировочного ордера)</param>
		/// <returns></returns>
		IList<PurchaseOrder> GetPurchaseOrders(BaseEntityObject parent, WorkPackageStatus[] statuses = null, bool loadWorkPackageItems = false, Product[] includedAccessory = null);
		/// <summary>
		/// Возвращает Котировочные ордера воздушного судна
		/// </summary>
		/// <param name="parent">Владелец котировочного оредера. При пережаче null вернет все Котировочные ордера</param>
		/// <param name="statuses">Фильтр статуса Котировочные ордера. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="loadWorkPackageItems">Флаг загрузки элементов Котировочного ордера</param>
		/// <param name="includedAccessory">Задачи, которые должны содержать ордера (при передаче пустои коллекции запрос вернет 0 Котировочного ордера)</param>
		/// <returns></returns>
		IList<RequestForQuotation> GetRequestForQuotation(BaseEntityObject parent, WorkPackageStatus[] statuses = null, bool loadWorkPackageItems = false, Product[] includedAccessory = null);
		/// <summary>
		/// Возвращает Котировочные ордера воздушного судна
		/// </summary>
		/// <param name="parent">Владелец котировочного оредера. При пережаче null вернет все Котировочные ордера</param>
		/// <param name="statuses">Фильтр статуса Котировочные ордера. (По умолчанию = WorkPackageStatus.All)</param>
		/// <param name="loadWorkPackageItems">Флаг загрузки элементов Котировочного ордера</param>
		/// <param name="includedAccessory">Задачи, которые должны содержать ордера (при передаче пустои коллекции запрос вернет 0 Котировочного ордера)</param>
		/// <returns></returns>
		IList<InitialOrder> GetInitialOrders(BaseEntityObject parent, WorkPackageStatus[] statuses = null, bool loadWorkPackageItems = false, Product[] includedAccessory = null);
		/// <summary>
		/// Загружает все элементы рабочего пакета
		/// </summary>
		/// <param name="rfq"></param>
		void LoadRequestForQuotationItems(RequestForQuotation rfq);
		/// <summary>
		/// Загружает все элементы рабочего пакета
		/// </summary>
		/// <param name="po"></param>
		void LoadPurchaseOrderItems(PurchaseOrder po);
		/// <summary>
		/// Загружает все элементы рабочего пакета
		/// </summary>
		/// <param name="rfq"></param>
		void LoadInitionalOrderItems(InitialOrder rfq);
		RequestForQuotation GetRequestForQuotation(int requestForQuotationId);
		/// <summary>
		/// Публикует закупочный акт
		/// </summary>
		/// <param name="po"></param>
		/// <param name="date"></param>
		void Publish(PurchaseOrder po, DateTime date);

		InitialOrder AddInitialOrder(IEnumerable<KeyValuePair<Product, double>> quotationList,
									 BaseEntityObject parent, DateTime effDate,
									 DeferredCategory category, out string message);

		InitialOrder AddInitialOrder(IEnumerable<InitialOrderRecord> initialList,
									 BaseEntityObject parent, out string message);

		void GetInitialOrderItemsWithCalculate(InitialOrder initialOrder);

		RequestForQuotation AddQuotationOrder(IEnumerable<KeyValuePair<Product, double>> quotationList, BaseEntityObject parent, out string message);

		RequestForQuotation AddQuotationOrder(IEnumerable<RequestForQuotationRecord> quotationList,
										      Supplier toSupplier, BaseEntityObject parent,
											  out string message, IORQORRelation[] iorqorRelations = null);

		bool AddToQuotationOrder(List<KeyValuePair<Product, double>> quotationItems, int quotationId, out string message);

		void Publish(RequestForQuotation rfq, DateTime date);

		void Close(RequestForQuotation rfq, DateTime date, string remarks);

		void Close(PurchaseOrder rfq, DateTime date, string remarks);

		void DeleteFromRequestForQuotation(Product accessory, RequestForQuotation rfq);
	}
}