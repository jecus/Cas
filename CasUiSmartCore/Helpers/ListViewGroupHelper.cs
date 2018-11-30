using System;
using System.Collections.Generic;
using System.Linq;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.Helpers
{
	public class ListViewGroupHelper
	{
		public static string GetGroupString(object tag)
		{
			var temp = "";

			IBaseEntityObject parent;

			if (tag is NextPerformance)
				parent = ((NextPerformance) tag).Parent;
			else if (tag is AbstractPerformanceRecord)
				parent = ((AbstractPerformanceRecord) tag).Parent;
			else if (tag is IBaseEntityObject)
				parent = (IBaseEntityObject) tag;
			else parent = null;


			if (parent is Directive)
			{
				var directive = (Directive)parent;
				temp = getDirectiveGroupString(directive);
			}
			else if (parent is BaseComponent)
			{
				var baseComponent = parent as BaseComponent;
				temp = getBaseComponentGroup(baseComponent);
			}
			else if (parent is Component)
			{
				var component = parent as Component;
				temp = getComponentGroupString(component);
			}
			else if (parent is ComponentDirective)
			{
				var dd = (ComponentDirective) parent;
				temp = getComponentDirectiveGroupString(dd);
			}
			else if (parent is MaintenanceCheck)
			{
				var mc = (MaintenanceCheck) parent;
				temp = getMaintenanceCheckGroupString(mc);
			}
			else if (parent is MaintenanceDirective)
			{
				var md = (MaintenanceDirective) parent;
				temp = getMaintenanceDirectiveGroupString(md);
			}
			else if (tag is NonRoutineJob)
			{
				temp = "Non-Routine Jobs";
			}

			return temp;
		}

		public static string GetGroupStringByPerformanceDate(IList<NextPerformance> performances, DateTime performanceDate, string aircraftRegistrationNumber = null)
		{
			//Формирование первой части названия группы, состоящей из даты выполнения
			var temp = performanceDate > DateTimeExtend.GetCASMinDateTime()
							? Convert.GetDateFormat(performanceDate) + "  " +
							(!string.IsNullOrEmpty(aircraftRegistrationNumber) ? "  " + aircraftRegistrationNumber + "  " : "") : "";

			//Добавление в название присутствующих на данную дату чеков программы обслуживания
			var maintenanceCheckPerformances = performances.Where(np => np.Parent != null && np.Parent is MaintenanceCheck);
			foreach (var maintenanceCheckPerformance in maintenanceCheckPerformances)
			{
				if (maintenanceCheckPerformance is MaintenanceNextPerformance)
				{
					var mnp = maintenanceCheckPerformance as MaintenanceNextPerformance;
					temp += mnp.PerformanceGroup.GetGroupName();
				}
				else temp += ((MaintenanceCheck)maintenanceCheckPerformance.Parent).Name;
				temp += " ";
			}

			var isAdPerformances = false;
			var isSbPerformances = false;
			var isEoPerformances = false;
			var isComponentPerformances = false;
			var isMpdPerformances = false;

			foreach (var np in performances)
			{
				if (np.Parent == null)
					continue;

				if (!isAdPerformances && np.Parent is Directive)
				{
					var directive = np.Parent as Directive;

					if(directive.DirectiveType == DirectiveType.AirworthenessDirectives)
						isAdPerformances = true;
					else if (directive.DirectiveType == DirectiveType.SB)
						isSbPerformances = true;
					else if (directive.DirectiveType == DirectiveType.EngineeringOrders)
						isEoPerformances = true;
				}
				else if (!isComponentPerformances && np.Parent is Component || np.Parent is ComponentDirective)
					isComponentPerformances = true;
				else if (!isMpdPerformances && np.Parent is MaintenanceDirective)
					isMpdPerformances = true;

				if (isAdPerformances && isComponentPerformances && isMpdPerformances)
					break;
			}

			//Добавление в название присутствующих на данную дату директив летной годности
			if (isAdPerformances)
				temp += "-AD  ";

			if (isSbPerformances)
				temp += "-SB  ";

			if (isEoPerformances)
				temp += "-EO  ";

			//Добавление в название присутствующих на данную дату компонентов или задач по ним
			if (isComponentPerformances)
				temp += "-Comp  ";

			//Добавление в название присутствующих на данную дату MPD
			if (isMpdPerformances)
				temp += "-MPD  ";


			return temp;
		}

		public static string GetGroupStringByPerformanceDate(object tag)
		{
			var date = DateTimeExtend.GetCASMinDateTime();
			if (tag is IDirective)
			{
				var np = ((IDirective)tag).NextPerformance;
				if (np != null && np.PerformanceDate != null)
					date = np.PerformanceDate.Value.Date;
			}

			return date.Date > DateTimeExtend.GetCASMinDateTime().Date ? Convert.GetDateFormat(date.Date) : "";
		}

		public static string GetDirectiveGroupString(Directive directive, Lifelength current, Lifelength forecast)
		{
			return getDirectiveGroupString(directive) + $" C:{current} F:{forecast}";
		}

		public static string GetDirectiveGroupString(Directive directive)
		{
			return getDirectiveGroupString(directive);
		}

		private static string getDirectiveGroupString(Directive directive)
		{
			var res = "";

			var currentDestination = directive.ParentBaseComponent.ParentAircraftId > 0
				? DestinationHelper.GetDestinationStringFromAircraft(directive.ParentBaseComponent.ParentAircraftId, false,
					directive.ParentBaseComponent.ItemId)
				: DestinationHelper.GetDestinationStringFromStore(directive.ParentBaseComponent.ParentStoreId,
					directive.ParentBaseComponent.ItemId, false);

			if (directive is DeferredItem)
				res = $"{currentDestination} | Deffred";
			else if (directive is DamageItem)
				res = $"{currentDestination} | Damage";
			else if (directive.DirectiveType == DirectiveType.OutOfPhase)
				res = $"{currentDestination} | Out of phase";
			else
			{
				if (directive.DirectiveType.ItemId == DirectiveType.AirworthenessDirectives.ItemId)
					res = $"{currentDestination} | AD";
				else if (directive.DirectiveType.ItemId == DirectiveType.EngineeringOrders.ItemId)
					res = $"{currentDestination} | Engineering orders";
				else if (directive.DirectiveType.ItemId == DirectiveType.SB.ItemId)
					res = $"{currentDestination} | Service bulletins";
			}

			return res;
		}

		public static string GetBaseComponentGroupString(BaseComponent baseComponent, Lifelength current, Lifelength forecast)
		{
			return getBaseComponentGroup(baseComponent) + $" C:{current} F:{forecast}";
		}

		private static string getBaseComponentGroup(BaseComponent baseComponent)
		{
			var currentDestination = DestinationHelper.GetDestinationStringFromAircraft(baseComponent.ParentAircraftId, false, null);
			return $"{currentDestination} {baseComponent.BaseComponentType} . Component PN {baseComponent.PartNumber}";
		}

		public static string GetComponentGroupString(Component component, Lifelength current, Lifelength forecast)
		{
			var currentDestination = DestinationHelper.GetDestinationStringFromAircraft(component.ParentAircraftId, false, null);
			return $"{currentDestination} | {component.ParentBaseComponent} | Components C:{current} F:{forecast}";
		}

		private static string getComponentGroupString(Component component)
		{
			var currentDestination = DestinationHelper.GetDestinationStringFromAircraft(component.ParentAircraftId, false, null);
			return component.ParentBaseComponent != null ? $"{currentDestination} | {component.ParentBaseComponent} | Components" : "Components";
		}

		public static string GetComponentDirectiveGroupString(ComponentDirective componentDirective, Lifelength current, Lifelength forecast)
		{
			if (componentDirective.ParentComponent.ParentAircraftId > 0)
			{
				var currentDestination = DestinationHelper.GetDestinationStringFromAircraft(componentDirective.ParentComponent.ParentAircraftId, false, null);
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				return $"{currentDestination} | {componentDirective.ParentComponent} | Detail directives C:{current} F:{forecast}";
			}
			if (componentDirective.ParentComponent.ParentStoreId > 0)
			{
				var currentDestination = DestinationHelper.GetDestinationStringFromStore(componentDirective.ParentComponent.ParentStoreId, componentDirective.ParentComponent.ItemId, false);
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				return $"{currentDestination} | Detail directives C:{current} F:{forecast}";
			}
			return componentDirective.ParentComponent + " | Detail directives";//TODO:(Evgenii Babak) Переименовать Detail в Component
		}

		private static string getComponentDirectiveGroupString(ComponentDirective componentDirective)
		{
			string res;

			if (componentDirective.ParentComponent != null)
			{
				var title = string.Format("P/N:{0} {1} Pos:{2} S/N:{3} {4}",
					componentDirective.ParentComponent.PartNumber,
					componentDirective.ParentComponent.Description,
					componentDirective.ParentComponent.Position,
					componentDirective.ParentComponent.SerialNumber,
					componentDirective.ParentComponent.MaintenanceControlProcess.ShortName);

				var parentStore = GlobalObjects.StoreCore.GetStoreById(componentDirective.ParentComponent.ParentStoreId);

				if (componentDirective.ParentComponent.ParentAircraftId > 0)
				{
					var currentDestination = DestinationHelper.GetDestinationStringFromAircraft(componentDirective.ParentComponent.ParentAircraftId, false,
						null);
					res = $"{currentDestination} | {title} | Component directives";
				}
				else if (parentStore != null)
					res = $"{parentStore} | {title} | Component directives";
				else res = title + " | Component directives";
			}
			else res = "Component Directives";

			return res;
		}

		public static string GetMaintenanceCheckGroupString(MaintenanceCheck maintenanceCheck, Lifelength current, Lifelength forecast)
		{
			var currentDestination = DestinationHelper.GetDestinationStringFromAircraft(maintenanceCheck.ParentAircraftId, false, null);
			return $"{currentDestination} | Maintenance checks  C:{current} F:{forecast}";
		}

		private static string getMaintenanceCheckGroupString(MaintenanceCheck maintenanceCheck)
		{
			var currentDestination = DestinationHelper.GetDestinationStringFromAircraft(maintenanceCheck.ParentAircraftId, false, null);
			return $"{currentDestination} | Maintenance checks {(maintenanceCheck.Schedule ? "Schedule" : "Store")}";
		}

		public static string GetMaintenanceDirectiveGroupString(MaintenanceDirective maintenanceDirective, Lifelength current, Lifelength forecast)
		{
			return $"{getMaintenanceDirectiveGroupString(maintenanceDirective)} C:{current} F:{forecast}";
		}

		private static string getMaintenanceDirectiveGroupString(MaintenanceDirective maintenanceDirective)
		{
			return maintenanceDirective.ParentBaseComponent + " | MPD";
		}

	}
}
