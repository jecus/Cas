using System;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.KitControls;
using CAS.UI.UIControls.MaintananceProgram;
using CAS.UI.UIControls.PersonnelControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.StoresControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using TempUIExtentions;

namespace CAS.UI.Management
{
	/// <summary>
	/// Менеджер для работы со страницами и формами
	/// </summary>
	// TODO:(Evgenii Babak) Произвести рефакторинг. pagecaption вынести в DestinationHelper
	public class ScreenAndFormManager
    {

		#region public static Form GetEditForm(BaseEntityObject forObject)

		/// <summary>
		/// Возвращает элемент Форму или Страницу применимую для редвктирования переданного элемента
		/// </summary>
		/// <param name="forObject">Объект для редактирования</param>
		/// <returns></returns>
		public static Form GetEditForm(BaseEntityObject forObject)
		{
			if (forObject == null)
				throw new ArgumentNullException("forObject","Is null");

			var form = GetEditFormInternal(forObject);
			if (form == null)
				throw new NotSupportedException(string.Format("Form not found for {0}", forObject));
			return form;
	    }

		#endregion

		#region private static Form GetEditFormInternal(BaseEntityObject forObject)

		private static Form GetEditFormInternal(BaseEntityObject forObject)
	    {
		    try
		    {
			    if (forObject is AircraftWorkerCategory)
				    return new AircraftWorkerCategoryForm((AircraftWorkerCategory) forObject);
				if (forObject is ComponentModel)
					return new ModelForm((ComponentModel)forObject);
				if (forObject is AircraftModel)
				    return new CommonEditorForm(forObject);
			    if (forObject is Product)
				    return new ProductForm((Product) forObject);
			    if (forObject is AccessoryRequired)
				    return new KitForm((AccessoryRequired) forObject);
			    if (forObject is GoodStandart)
				    return new GoodStandardForm((GoodStandart) forObject);
			    if (forObject is NonRoutineJob)
			    {
				    var nrj = (NonRoutineJob) forObject;
				    if (nrj.ParentWorkPackage != null && nrj.WorkPackageRecord != null)
						return new NonRoutineJobForm(nrj.WorkPackageRecord, nrj.ParentWorkPackage);
				  	return new NonRoutineJobForm(nrj);
			    }
			    if (forObject is Component)
			    {
				    var component = (Component) forObject;
				    if (component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.MaintenanceMaterials) ||
				        component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools)||
				        component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Protection))
					    return new ConsumablePartAndKitForm(component);
			    }
				else return new CommonEditorForm(forObject);

				return null;
		    }
		    catch (Exception ex)
		    {
			    Program.Provider.Logger.Log("Error while building new object", ex);
			    return null;
		    }
	    }

	    #endregion

		#region public static DisplayerParams GetEditScreen(BaseEntityObject forObject)

		public static DisplayerParams GetEditScreen(BaseEntityObject forObject)
	    {
		    if (forObject == null)
				throw new ArgumentNullException("forObject", "Is null");

			var screen = GetEditScreenInternal(forObject);
			if (screen == null)
				throw new NotSupportedException(string.Format("Page is not found for {0}",forObject));
			return screen;

	    }

		#endregion

		#region private static DisplayerParams GetEditScreenInternal(BaseEntityObject forObject)

		private static DisplayerParams GetEditScreenInternal(BaseEntityObject forObject)
	    {
		    try
		    {
			    IBaseEntityObject parent;

			    if (forObject is NextPerformance)
				    parent = ((NextPerformance) forObject).Parent;
			    else if (forObject is AbstractPerformanceRecord)
				    parent = ((AbstractPerformanceRecord) forObject).Parent;
			    else parent = forObject;

			    if (parent is Directive)
				    return GetDirectiveScreen((Directive) parent);
			    if (parent is BaseComponent)
				    return GetBaseComponentScreen((BaseComponent) parent);
			    if (parent is Component)
				    return GetComponentScreen((Component) parent);
			    if (parent is ComponentDirective)
				    return GetComponentDirectiveScreen((ComponentDirective) parent);
			    if (parent is MaintenanceCheck)
				    return GetMaintenanceCheckScreen((MaintenanceCheck) parent);
			    if (parent is MaintenanceDirective)
				    return GetMaintenanceDirectiveScreen((MaintenanceDirective) parent);

			    return null;
		    }
		    catch (Exception ex)
		    {
			    Program.Provider.Logger.Log("Error while return ReferenceEventArgs", ex);
			    return null;
		    }
	    }

	    #endregion

		#region public static DisplayerParams GetEditScreenOrForm(BaseEntityObject forObject)

		public static DisplayerParams GetEditScreenOrForm(BaseEntityObject forObject)
	    {
			if (forObject == null)
				throw new ArgumentNullException(nameof(forObject), "Is null");

			var dp = GetEditScreenInternal(forObject);
		    if (dp != null)
			    return dp;

			var form = GetEditFormInternal(forObject);
			if (form != null)
				return DisplayerParams.CreateFormParams(form);

			throw new NotSupportedException(string.Format("Page of Form not found for {0}",forObject));
	    }

		#endregion

		#region public static DisplayerParams GetDirectiveScreen(Directive directive)
		/// <summary>
		/// Возвращает DisplayerParams для Directive
		/// </summary>
		public static DisplayerParams GetDirectiveScreen(Directive directive)
	    {
		    var pagecaption = $"{directive.ParentBaseComponent.GetParentAircraftRegNumber()} {directive.Title}";

			if (directive is DeferredItem)
			    return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new DeferredScreen((DeferredItem)directive));
		    else if (directive is DamageItem)
				return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new DamageDirectiveScreen((DamageItem)directive));
		    else if (directive.DirectiveType == DirectiveType.OutOfPhase)
				return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new OutOfPhaseReferenceScreen(directive));
		    else return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new DirectiveScreen(directive));

	    }

		#endregion

		#region public static DisplayerParams GetBaseComponentScreen(BaseComponent baseComponent)
		/// <summary>
		/// Возвращает DisplayerParams для BaseComponent
		/// </summary>
		public static DisplayerParams GetBaseComponentScreen(BaseComponent baseComponent)
		{
			string pagecaption;

			//TODO:(Evgenii Babak) Пересмотреть подход здесь
			var parentStore = GlobalObjects.StoreCore.GetStoreById(baseComponent.ParentStoreId);

			if (baseComponent.ParentAircraftId > 0)
				pagecaption = $"{baseComponent.GetParentAircraftRegNumber()} {baseComponent.BaseComponentType}. Component PN {baseComponent.PartNumber}";
			else if(parentStore != null)
				pagecaption = $"{parentStore.Name}. Component PN {baseComponent.PartNumber}";
			else
				pagecaption = $"Component PN {baseComponent.PartNumber}";

			return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new ComponentScreenNew(baseComponent));
	    }

		#endregion

		#region public static DisplayerParams GetComponentScreen(Component component)
		/// <summary>
		/// Возвращает DisplayerParams для Component
		/// </summary>
		public static DisplayerParams GetComponentScreen(Component component)
		{
			if (component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.MaintenanceMaterials) ||
				component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools) ||
			    component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Protection))
				return null;

			string pagecaption;
			//TODO:(Evgenii Babak) Пересмотреть подход здесь
			var parentStore = GlobalObjects.StoreCore.GetStoreById(component.ParentStoreId);

			if (component.ParentAircraftId > 0)
			    pagecaption = $"{component.GetParentAircraftRegNumber()}. Component PN {component.PartNumber}";
			else if (parentStore != null)
				pagecaption = $"{parentStore.Name}. Component PN {component.PartNumber}";
			else if (component.ParentBaseComponent != null)
				pagecaption = $"Component PN {component.ParentBaseComponent.PartNumber}";//TODO:(Evgenii Babak) заменить на использование ComponentCore
			else
				pagecaption = $"Component PN {component.PartNumber}";

			return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new ComponentScreenNew(component));
	    }

		#endregion

		#region public static DisplayerParams GetComponentDirectiveScreen(ComponentDirective componentDirective)
		/// <summary>
		/// Возвращает DisplayerParams для ComponentDirective
		/// </summary>
		public static DisplayerParams GetComponentDirectiveScreen(ComponentDirective componentDirective)
		{
			string pagecaption;

			if (componentDirective.ParentComponent != null)
			{
				//TODO:(Evgenii Babak) Пересмотреть подход здесь

				if (componentDirective.ParentComponent.ParentAircraftId > 0)
				    pagecaption = $"{DestinationHelper.GetDestinationStringFromAircraft(componentDirective.ParentComponent.ParentAircraftId, false, null)}. Component PN {componentDirective.ParentComponent.PartNumber}";
				else if (componentDirective.ParentComponent.ParentStoreId > 0)
				{
					var parentStore = GlobalObjects.StoreCore.GetStoreById(componentDirective.ParentComponent.ParentStoreId);
					pagecaption = $"{parentStore.Name}. Component PN {componentDirective.ParentComponent.PartNumber}";
				}
				else if (componentDirective.ParentBaseComponent != null)
					pagecaption = $"Component PN {componentDirective.ParentComponent.ParentBaseComponent.PartNumber}";//TODO:(Evgenii Babak) заменить на использование ComponentCore
				else
					pagecaption = $"Component PN {componentDirective.ParentComponent.PartNumber}";
				    
				return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new ComponentScreenNew(componentDirective.ParentComponent));
		    }
		    
			throw new NullReferenceException("ComponentDirective.ParentComponent is null");
	    }

		#endregion

		#region public static DisplayerParams GetMaintenanceCheckScreen(MaintenanceCheck maintenanceCheck)
		/// <summary>
		/// Возвращает DisplayerParams для MaintenanceCheck
		/// </summary>
		public static DisplayerParams GetMaintenanceCheckScreen(MaintenanceCheck maintenanceCheck)
	    {
		    string pagecaption = maintenanceCheck.ParentAircraft.RegistrationNumber + ". Maintenance Program";
		    return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, pagecaption, new MaintenanceScreen(maintenanceCheck.ParentAircraft));
	    }

		#endregion

		#region public static DisplayerParams GetMaintenanceDirectiveScreen(MaintenanceDirective mpd)
		/// <summary>
		/// Возвращает DisplayerParams для MaintenanceDirective
		/// </summary>
		public static DisplayerParams GetMaintenanceDirectiveScreen(MaintenanceDirective mpd)
	    {
		    string regNumber;
		    Aircraft parentAircraft = null;
			if (mpd.ParentBaseComponent.LastDestinationObjectType == SmartCoreType.Aircraft)
				parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(mpd.ParentBaseComponent.LastDestinationObjectId);
		    if (mpd.ParentBaseComponent.BaseComponentType == BaseComponentType.Frame)
			    regNumber = mpd.ParentBaseComponent.GetParentAircraftRegNumber();
			else
		    {
			    if (parentAircraft != null)
				    regNumber = $"{parentAircraft.RegistrationNumber}. {mpd.ParentBaseComponent}";
				else
				    regNumber = mpd.ParentBaseComponent.ToString();
		    }
		    regNumber += $". MPD. {mpd.WorkType.CommonName}. {mpd.TaskNumberCheck}";

		    return DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, regNumber, new MaintenanceDirectiveScreen(mpd));
	    }

	    #endregion

	}
}
