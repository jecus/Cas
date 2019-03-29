using System;
using System.Linq;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;
using SmartCore.Packages;
using SmartCore.Relation;

namespace SmartCore.RegisterPerformances
{
	public class PerformanceCore : IPerformanceCore
	{
		private readonly INewKeeper _newKeeper;
		private readonly IKeeper _keeper;
		private readonly ICalculator _calculator;
		private readonly IBindedItemsCore _bindedItemsCore;

		public PerformanceCore(INewKeeper newKeeper, IKeeper keeper, ICalculator calculator,
							   IBindedItemsCore bindedItemsCore)
		{
			_newKeeper = newKeeper;
			_keeper = keeper;
			_calculator = calculator;
			_bindedItemsCore = bindedItemsCore;
		}

		#region public void RegisterPerformance(IDirective directive, AbstractPerformanceRecord performance, IDirectivePackage directivePackage = null, bool registerPerformanceForBindedItems = true)

		public void RegisterPerformance(IDirective directive, AbstractPerformanceRecord performance, IDirectivePackage directivePackage = null, bool registerPerformanceForBindedItems = true)
		{
			if((directive is Entities.General.Accessory.Component))
				Check((Entities.General.Accessory.Component)directive, (TransferRecord)performance);
			else Check(directive, performance);

			// Не можем добавить выполнение для не существующей директивы
			if (directive.ItemId <= 0)
				throw new Exception("1033: Can not register performance for not existing directive");

			// Дополняем необходимые данные
			performance.ParentId = directive.ItemId;

			// Выставляем родителя записи о выполнении
			performance.Parent = directive;

			if (directivePackage != null)
			{
				performance.DirectivePackageId = directivePackage.ItemId;
				performance.AttachedFile = directivePackage.AttachedFile;
			}

			_newKeeper.Save(performance);

			if (directive.PerformanceRecords.GetItemById(performance.ItemId) == null)
				directive.PerformanceRecords.Add(performance);

			if (directive is Entities.General.Accessory.Component)
			{
				var component = directive as Entities.General.Accessory.Component;
				var transferRecord = performance as TransferRecord;
				//выставление нового родителя
				if (transferRecord.DestinationObjectType == SmartCoreType.Aircraft)
					component.ParentAircraftId = transferRecord.DestinationObjectId;
				if (component.IsBaseComponent)
				{
					//обнуление мат аппарата для этой базовой детали
					_calculator.ResetMath((BaseComponent)component);
				}
			}

			if (!registerPerformanceForBindedItems)
				return;

			if (directive is MaintenanceDirective)
			{
				var mpd = directive as MaintenanceDirective;
				CreateAndSavePerformanceForBindedItems(mpd, performance);
			}
			else if (directive is ComponentDirective)
			{
				var dd = directive as ComponentDirective;
				var dr = performance as DirectiveRecord;
				CreateAndSavePerformanceForBindedItems(dd, dr);
			}
		}
		#endregion

		#region public void Delete(DirectiveRecord directiveRecord)
		/// <summary>
		/// Удаляет запись о выполнении директивы
		/// </summary>
		/// <param name="directiveRecord"></param>
		public void Delete(DirectiveRecord directiveRecord)
		{
			if (directiveRecord.Dispatched == new DateTime(0001, 01, 01))
				directiveRecord.Dispatched = DateTimeExtend.GetCASMinDateTime();

			directiveRecord.IsDeleted = true;
			_newKeeper.Save(directiveRecord);

			// нужно обнулить математический аппарат объекта, которому принадлежит запись о выполнении
			// а также удалить выполнение директивы из коллекции выполнений директивы
			IDirective parent = directiveRecord.Parent;
			if (parent == null)
				throw new Exception("1040: Failed to specify directive record parent type");

			ICommonFilter filter = null;

			if (parent is MaintenanceCheck)
				filter = new CommonFilter<int>(DirectiveRecord.MaintenanceCheckRecordIdProperty, directiveRecord.ItemId);
			else if (parent is MaintenanceDirective)
				filter = new CommonFilter<int>(DirectiveRecord.MaintenanceDirectiveRecordIdProperty, directiveRecord.ItemId);
			else if (parent is ComponentDirective)
			{
				if(directiveRecord.MaintenanceDirectiveRecordId > 0)
					filter = new CommonFilter<int>(DirectiveRecord.MaintenanceDirectiveRecordIdProperty, directiveRecord.ItemId);
			}

			if (filter != null)
				_keeper.MarkAsDeleted<DirectiveRecord>(new[] { filter });


			parent.PerformanceRecords.Remove(directiveRecord);
		}
		#endregion

		#region private void CreateAndSavePerformanceForBindedItems(MaintenanceDirective mpd, AbstractPerformanceRecord performance)

		private void CreateAndSavePerformanceForBindedItems(MaintenanceDirective mpd, AbstractPerformanceRecord performance)
		{
			var bindedItems = _bindedItemsCore.GetBindedItemsFor(mpd.ParentBaseComponent.ParentAircraftId, mpd);

			foreach (var bindedItem in bindedItems)
			{
				if (bindedItem is ComponentDirective)
				{
					var componentDirective = (ComponentDirective) bindedItem;
					var newPerformance = new DirectiveRecord(performance)
					{
						MaintenanceDirectiveRecordId = performance.ItemId,
						Parent = componentDirective,
						//TODO:(Evgenii Babak) Выяснить почему при создании записи берем наработку на начало дня, но в отчетах, для записей о выполнении пересчитываем наработку, и выводим наработку на конец дня
						OnLifelength = _calculator.GetFlightLifelengthOnStartOfDay(componentDirective.ParentComponent, performance.RecordDate),
						ParentId = componentDirective.ItemId
					};
					_newKeeper.Save(newPerformance, false);
				}
			}
		}

		#endregion

		#region private void CreateAndSavePerformanceForBindedItems(ComponentDirective componentDirective, DirectiveRecord directiveRecord)

		private void CreateAndSavePerformanceForBindedItems(ComponentDirective componentDirective, DirectiveRecord directiveRecord)
		{
			if (componentDirective.ParentComponent != null && componentDirective.ParentComponent.ParentAircraftId > 0)
			{
				var bindedItem = _bindedItemsCore.GetBindedItemsFor(componentDirective.ParentComponent.ParentAircraftId, componentDirective).SingleOrDefault();

				if (bindedItem is MaintenanceDirective)
				{
					var mpd = bindedItem as MaintenanceDirective;
					var newPerformance = new DirectiveRecord(directiveRecord)
					{
						MaintenanceDirectiveRecordId = -1,
						//TODO:(Evgenii Babak) Выяснить почему при создании записи берем наработку на начало дня, но в отчетах, для записей о выполнении пересчитываем наработку, и выводим наработку на конец дня
						OnLifelength = _calculator.GetFlightLifelengthOnStartOfDay(mpd.ParentBaseComponent, directiveRecord.RecordDate),
						Parent = mpd,
						ParentId = mpd.ItemId
					};

					_newKeeper.Save(newPerformance, false);

					directiveRecord.MaintenanceDirectiveRecordId = newPerformance.ItemId;
					_newKeeper.Save(directiveRecord);
				}
			}
		}

		#endregion

		#region private void Check(IDirective directive, AbstractPerformanceRecord performance)

		private void Check(IDirective directive, AbstractPerformanceRecord performance)
		{
			if (directive.PerformanceRecords.GetLast() != null)
			{
				if (directive.IsClosed && directive.PerformanceRecords.GetLast().RecordDate > performance.RecordDate)
					throw new Exception("1629: Can not register performance after directive closing");
			}
		}

		#endregion

		#region private void Check(Component component, TransferRecord transferRecord)

		private void Check(Entities.General.Accessory.Component component, TransferRecord transferRecord)
		{
			if (transferRecord.ItemId > 0)
				if (transferRecord.TransferDate > component.ActualStateRecords[0].RecordDate.Date)
					throw new Exception("953: You can not change the date on TransferRecord bigger than the first ActualState");
		}

		#endregion

	}
}