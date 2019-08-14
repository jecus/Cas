using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.ComponentControls
{
	///<summary>
	/// ЭУ для отображения суммарной информации по компоненту самолета
	///</summary>
	public partial class ComponentSummary : UserControl
	{
		#region Fields

		private Component _currentComponent;
		private ComponentCollection _baseComponentComponents;
		private List <ComponentSummaryCompliancePerformanceControl> _detailDirectivesPerformances;

		#endregion

		#region Properties

		///<summary>
		///</summary>
		public Component CurrentComponent
		{
			set
			{
				_currentComponent = value;
				UpdateInformation();
			}
		}

		#endregion

		#region Constructor

		///<summary>
		/// конструктор по умолчанию для простого создания ЭУ
		///</summary>
		public ComponentSummary()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Создает объект отображающий краткую информацию о компоненте
		/// </summary>
		/// <param name="currentComponent/param>
		public ComponentSummary(Component currentComponent) : this()
		{
			_currentComponent = currentComponent;
			_detailDirectivesPerformances = new List<ComponentSummaryCompliancePerformanceControl>();

			UpdateInformation();
		}

		#endregion

		#region Methods

		#region public void SetParameters(Detail currentDetail, DetailCollection detailComponents = null)
		/// <summary>
		/// Задает параметры контрола
		/// </summary>
		/// <param name="currentComponentомпонент, информацию которого требуется отобразить</param>
		/// <param name="componentComponents">Коллекция компонентов, связанных с основным компонентом</param>
		public void SetParameters(Component currentComponent, ComponentCollection componentComponents = null)
		{
			_currentComponent = currentComponent;

			if(_baseComponentComponents != componentComponents)
			{
				if(_baseComponentComponents != null && _baseComponentComponents.Count > 0)
					_baseComponentComponents.Clear();
				if (componentComponents != null)
					_baseComponentComponents = componentComponents;
			}

			UpdateInformation();
		}
		#endregion

		#region public void UpdateInformation()
		/// <summary>
		/// Заполняет краткую информацию о директиве 
		/// </summary>
		public void UpdateInformation()
		{
			if (_currentComponent == null)
				return;
			if (_detailDirectivesPerformances == null)
				_detailDirectivesPerformances = new List<ComponentSummaryCompliancePerformanceControl>();
			else _detailDirectivesPerformances.Clear();
			//очищение плавающей панели и списка контролов отображения директив деталей
			flowLayoutPanel_Compliance.Controls.Clear();

			if (_currentComponent is BaseComponent)
			{
				BaseComponent inspectedBaseComponent = (BaseComponent)_currentComponent;

				var lastTransferRecord = inspectedBaseComponent.TransferRecords.GetLast();
				string baseDetailTypeString = inspectedBaseComponent.BaseComponentType.ToString();
				labelCompntTCSN.Text = baseDetailTypeString + " Total:";
				labelCompntInstallDate.Text = baseDetailTypeString + " install date:";
				labelCompntTCSNonInstall.Text = baseDetailTypeString + " on Install:";
				labelCompntTCSNsinceInstall.Text = baseDetailTypeString + " since Install:";


				labelMPDItemValue.Text = inspectedBaseComponent.MPDItem;
				labelDescriptionValue.Text = inspectedBaseComponent.Model != null ? inspectedBaseComponent.Model.Description : inspectedBaseComponent.Description;
				labelRemarksValue.Text = inspectedBaseComponent.Remarks;
				labelHiddenRemarksValue.Text = inspectedBaseComponent.HiddenRemarks;
				labelPartNumberValue.Text = inspectedBaseComponent.PartNumber;
				labelSerialNumberValue.Text = inspectedBaseComponent.SerialNumber;
				labelPositionValue.Text = lastTransferRecord.Position; //позиция задается только для базовых деталей
				labelManufacturerValue.Text = inspectedBaseComponent.Manufacturer;
				labelManufactureDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(inspectedBaseComponent.ManufactureDate);
				labelDeliveryDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(inspectedBaseComponent.DeliveryDate);
				labelModelValue.Text = inspectedBaseComponent.Model != null ? inspectedBaseComponent.Model.ToString() : "";
				labelSupplierValue.Text = inspectedBaseComponent.Suppliers.ToString();
				labelMaintFreqValue.Text = inspectedBaseComponent.MaintenanceControlProcess.ToString();
				labelCostNewValue.Text = inspectedBaseComponent.Cost.ToString();
				labelCostServiceableValue.Text = inspectedBaseComponent.CostServiceable.ToString();
				labelCostOverhaulValue.Text = inspectedBaseComponent.CostOverhaul.ToString();
				labelWarrantyValue.Text = inspectedBaseComponent.Warranty.ToString();
				labelClassValue.Text = inspectedBaseComponent.Model != null ? inspectedBaseComponent.Model.GoodsClass.ToString() :
									   inspectedBaseComponent.GoodsClass != null ? inspectedBaseComponent.GoodsClass.ToString() : "";

				labelATAChapterValue.Text = inspectedBaseComponent.ATAChapter.ToString();

				if (inspectedBaseComponent.AvionicsInventory == AvionicsInventoryMarkType.None)
					labelAvionicsInventoryValue.Text = "None";
				if (inspectedBaseComponent.AvionicsInventory == AvionicsInventoryMarkType.Optional)
					labelAvionicsInventoryValue.Text = "Optional";
				if (inspectedBaseComponent.AvionicsInventory == AvionicsInventoryMarkType.Required)
					labelAvionicsInventoryValue.Text = "Required";
				if (inspectedBaseComponent.AvionicsInventory == AvionicsInventoryMarkType.Unknown)
					labelAvionicsInventoryValue.Text = "Unknown";

				labelCompntInstallDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(lastTransferRecord.TransferDate);
				Lifelength temp, temp2;
				//Наработка компонента на сегодня
				temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(inspectedBaseComponent);
				labelCompntTCSNValue.Text = temp.ToString();

				//Остаток жизненного времени на сегодня
				temp2 = new Lifelength(inspectedBaseComponent.LifeLimit);
				temp2.Substract(temp);
				temp2.Resemble(inspectedBaseComponent.LifeLimit);


				if (inspectedBaseComponent.BaseComponentType == BaseComponentType.Engine)
				{
					Component firstLimitter = _baseComponentComponents != null && _baseComponentComponents.Count > 0
											   ? _baseComponentComponents.Where(d => d.NextPerformanceDate != null)
																	  .OrderBy(d => d.NextPerformanceDate)
																	  .FirstOrDefault()
											   : null;

					labelCompntLifeLimit.Text = baseDetailTypeString + " Life Limit / First Limit";

					labelCompntLifeLimitValue.Text = 
						((inspectedBaseComponent.LifeLimit.IsNullOrZero() ? "N/A" : inspectedBaseComponent.LifeLimit.ToString()) + 
						 " / " +
						 (firstLimitter == null || firstLimitter.LifeLimit.IsNullOrZero() ? "N/A" : firstLimitter.LifeLimit.ToString()));

					labelCompntLifeLimitRemains.Text = baseDetailTypeString + " Life Limit Remain / First Remains";

					labelCompntLifeLimitRemainsValue.Text =
						((inspectedBaseComponent.Remains.IsNullOrZero() ? "N/A" : inspectedBaseComponent.Remains.ToString()) +
						 " / " +
						 (firstLimitter == null || firstLimitter.Remains.IsNullOrZero() ? "N/A" : firstLimitter.Remains.ToString()));
				}
				else
				{
					labelCompntLifeLimit.Text = baseDetailTypeString + " Life Limit";
					labelCompntLifeLimitValue.Text = inspectedBaseComponent.LifeLimit.ToString();
					labelCompntLifeLimitRemains.Text = baseDetailTypeString + " Life Limit Remain";
					labelCompntLifeLimitRemainsValue.Text = temp2.ToString();
				}


				//Наработка компонента на момент установки
				temp2 = inspectedBaseComponent.ActualStateRecords.GetLastKnownRecord(lastTransferRecord.RecordDate)?.OnLifelength ?? Lifelength.Null;
				labelCompntTCSNonInstallValue.Text = temp2.ToString();

				//Наработка компонента с момента установки и по сей день
				temp.Substract(temp2);
				labelCompntTCSNsinceInstallValue.Text = temp.ToString();


				var tcsnLifeLenght = Lifelength.Zero;
				var tcsnNonInstallLifeLenght = Lifelength.Zero;

				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(inspectedBaseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь

				if (parentAircraft != null)
				{
					tcsnLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircraft);

					var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
					//Наработка самолета на момент установки детали
					if (aircraftFrame != null)
						tcsnNonInstallLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(aircraftFrame, lastTransferRecord.TransferDate);
				}

				labelAircraftTCSNValue.Text = tcsnLifeLenght.ToString();
				labelAircraftTCSNonInstallValue.Text = tcsnNonInstallLifeLenght.ToString();
			}
			else
			{
				var inspectedDetail = _currentComponent;

				var lastTransferRecord = inspectedDetail.TransferRecords.GetLast();
				labelMPDItemValue.Text = inspectedDetail.MPDItem;
				labelDescriptionValue.Text = inspectedDetail.Model != null ? inspectedDetail.Model.Description : inspectedDetail.Description;
				labelRemarksValue.Text = inspectedDetail.Remarks;
				labelHiddenRemarksValue.Text = inspectedDetail.HiddenRemarks;
				labelPartNumberValue.Text = inspectedDetail.PartNumber;
				labelSerialNumberValue.Text = inspectedDetail.SerialNumber;
				labelPositionValue.Text = lastTransferRecord.Position;
				labelManufacturerValue.Text = inspectedDetail.Manufacturer;
				labelManufactureDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(inspectedDetail.ManufactureDate);
				labelDeliveryDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(inspectedDetail.DeliveryDate);
				labelModelValue.Text = inspectedDetail.Model != null ? inspectedDetail.Model.ToString() : "";
				labelSupplierValue.Text = inspectedDetail.Suppliers.ToString();
				labelMaintFreqValue.Text = inspectedDetail.MaintenanceControlProcess.ToString();
				labelCostNewValue.Text = inspectedDetail.Cost.ToString();
				labelCostServiceableValue.Text = inspectedDetail.CostServiceable.ToString();
				labelCostOverhaulValue.Text = inspectedDetail.CostOverhaul.ToString();
				labelWarrantyValue.Text = inspectedDetail.Warranty.ToString();
				labelClassValue.Text = inspectedDetail.Model != null ? inspectedDetail.Model.GoodsClass.ToString() :
									   inspectedDetail.GoodsClass != null ? inspectedDetail.GoodsClass.ToString() : "";

				labelATAChapterValue.Text = inspectedDetail.ATAChapter.ToString();

				if (inspectedDetail.AvionicsInventory == AvionicsInventoryMarkType.None)
					labelAvionicsInventoryValue.Text = "None";
				if (inspectedDetail.AvionicsInventory == AvionicsInventoryMarkType.Optional)
					labelAvionicsInventoryValue.Text = "Optional";
				if (inspectedDetail.AvionicsInventory == AvionicsInventoryMarkType.Required)
					labelAvionicsInventoryValue.Text = "Required";
				if (inspectedDetail.AvionicsInventory == AvionicsInventoryMarkType.Unknown)
					labelAvionicsInventoryValue.Text = "Unknown";

				labelCompntInstallDateValue.Text = SmartCore.Auxiliary.Convert.GetDateFormat(lastTransferRecord.TransferDate);
				labelCompntLifeLimitValue.Text = inspectedDetail?.LifeLimit?.ToString();

				var temp = Lifelength.Null;
				var temp2 = Lifelength.Null;
				//Наработка компонента на сегодня
				if (inspectedDetail.LLPMark && inspectedDetail.LLPCategories)
				{
					var selectedCategory = inspectedDetail.ChangeLLPCategoryRecords.GetLast()?.ToCategory;
					if (selectedCategory != null)
					{
						var data = inspectedDetail.LLPData.FirstOrDefault(i => i.ParentCategory == selectedCategory);
						temp = new Lifelength(data?.LLPCurrent);
						if(data?.Remain != null)
							temp2 = data.Remain;
					}

				}
				else temp = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(inspectedDetail);

				labelCompntTCSNValue.Text = temp.ToString();

				//Остаток жизненного времени на сегодня
				//temp2 = new Lifelength(inspectedDetail.LifeLimit);
				//temp2.Substract(temp);
				//temp2.Resemble(inspectedDetail.LifeLimit);
				labelCompntLifeLimitRemainsValue.Text = temp2.ToString();


				//Наработка компонента на момент установки
				var actualState = inspectedDetail.ActualStateRecords.GetLastKnownRecord(lastTransferRecord.RecordDate);
				if (actualState != null)
					temp2 = actualState.OnLifelength;
				else temp2 = Lifelength.Null;

				labelCompntTCSNonInstallValue.Text = temp2.ToString();

				//Наработка компонента с момента установки и по сей день
				if (inspectedDetail.LLPMark && inspectedDetail.LLPCategories)
				{
					var selectedCategory = inspectedDetail.ChangeLLPCategoryRecords.GetLast()?.ToCategory;
					if (selectedCategory != null)
					{
						var data = inspectedDetail.LLPData.FirstOrDefault(i => i.ParentCategory.ItemId == selectedCategory.ItemId);
						temp.Substract(data?.LLPLifelengthCurrent);

						labelCompntTCSNsinceInstallValue.Text = temp.ToString();
					}
				}
				else
				{
					temp.Substract(temp2);
					labelCompntTCSNsinceInstallValue.Text = temp.ToString();
				}
					

				//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
				var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(inspectedDetail.ParentAircraftId);

				//Наработка самолета на сегодня
				temp = parentAircraft != null
					? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircraft) 
					: Lifelength.Zero;
				labelAircraftTCSNValue.Text = temp.ToString();

				//Наработка самолета на момент установки детали
				temp = parentAircraft != null
						   ? GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId), lastTransferRecord.TransferDate)
						   : Lifelength.Zero;
				labelAircraftTCSNonInstallValue.Text = temp.ToString();
			}

			//Обновление таблиц выполнения директив
			//На каждую из директив детали создается отдельная таблица выполнения
			//После каждая таблица помещается в плавающую панель для отображения

			List<ComponentDirective> detailDirectives = new List<ComponentDirective>(((Component)_currentComponent).ComponentDirectives.ToArray());
			for (int i = 0; i < detailDirectives.Count; i++)
			{
				ComponentSummaryCompliancePerformanceControl summaryCompliancePerformanceControl = new ComponentSummaryCompliancePerformanceControl(detailDirectives[i]);
				
				summaryCompliancePerformanceControl.UpdateInformation();
				
				_detailDirectivesPerformances.Add(summaryCompliancePerformanceControl);
				flowLayoutPanel_Compliance.Controls.Add(summaryCompliancePerformanceControl);
			}          
		}

		#endregion

		#endregion
	}
}

