using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Auxiliary;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CAS.UI.UIControls.ComponentControls
{

	/// <summary>
	/// Ёлемент управлени€ дл€ отображени€ ссылок на отчеты базового агрегата
	/// </summary>
	public class BaseComponentLinksFlowLayoutPanel : FlowLayoutPanel
	{

		#region Fields

		private readonly BaseComponent _baseComponent;
		private readonly ReferenceStatusImageLinkLabel _linkAdStatus = new ReferenceStatusImageLinkLabel();
		private readonly ReferenceStatusImageLinkLabel _linkDiscrepancies = new ReferenceStatusImageLinkLabel();
		private readonly ReferenceStatusImageLinkLabel _linkEngineeringOrders = new ReferenceStatusImageLinkLabel();
		private readonly ReferenceStatusImageLinkLabel _linkSbStatus = new ReferenceStatusImageLinkLabel();
		private readonly ReferenceStatusImageLinkLabel _linkComponentStatus = new ReferenceStatusImageLinkLabel();
		private readonly ReferenceStatusImageLinkLabel _linkLlpDiskSheetStatus = new ReferenceStatusImageLinkLabel();

		//private readonly DirectiveTypeCollection directiveTypeCollection = DirectiveTypeCollection.Instance;
		private readonly Padding _imageLinkLabelMargin = new Padding(5);
		private readonly Padding _itemPadding = new Padding(1);

		#endregion

		#region Properties

		#region public Statuses LinkADStatus
		///<summary>
		/// ¬озвращает или задает статус ссылки на директивы летной годности
		///</summary>
		public Statuses LinkADStatus
		{
			get { return _linkAdStatus.Status; }
			set
			{
				if (InvokeRequired)
					BeginInvoke(new Action<Statuses>(s => _linkAdStatus.Status = s), value);
				else _linkAdStatus.Status = value;
			}
		}
		#endregion

		#region public Statuses LinkEOStatus
		///<summary>
		/// ¬озвращает или задает статус ссылки на инженерные ордера
		///</summary>
		public Statuses LinkEOStatus
		{
			get { return _linkEngineeringOrders.Status; }
			set
			{
				if (InvokeRequired)
					BeginInvoke(new Action<Statuses>(s => _linkEngineeringOrders.Status = s), value);
				else _linkEngineeringOrders.Status = value;
			}
		}
		#endregion

		#region public Statuses LinkSBStatus
		///<summary>
		/// ¬озвращает или задает статус ссылки на сервисные бюллетени
		///</summary>
		public Statuses LinkSBStatus
		{
			get { return _linkSbStatus.Status; }
			set
			{
				if (InvokeRequired)
					BeginInvoke(new Action<Statuses>(s => _linkSbStatus.Status = s), value);
				else _linkSbStatus.Status = value;
			}
		}
		#endregion

		#region public Statuses LinkComponentStatus
		///<summary>
		/// ¬озвращает или задает статус ссылки на компоненты
		///</summary>
		public Statuses LinkComponentStatus
		{
			get { return _linkComponentStatus.Status; }
			set
			{
				if (InvokeRequired)
					BeginInvoke(new Action<Statuses>(s => _linkComponentStatus.Status = s), value);
				else _linkComponentStatus.Status = value;
			}
		}
		#endregion

		#region public Statuses LinkLLPDiscSheetStatus
		///<summary>
		/// ¬озвращает или задает статус ссылки на вращающиес€ компоненты силовой установки
		///</summary>
		public Statuses LinkLLPDiscSheetStatus
		{
			get { return _linkLlpDiskSheetStatus.Status; }
			set
			{
				if (InvokeRequired)
					BeginInvoke(new Action<Statuses>(s => _linkLlpDiskSheetStatus.Status = s), value);
				else _linkLlpDiskSheetStatus.Status = value;
			}
		}
		#endregion

		#endregion

		#region Constructor

		/// <summary>
		/// —оздает элемент управлени€ дл€ отображени€ ссылок на отчеты базового агрегата
		/// </summary>
		public BaseComponentLinksFlowLayoutPanel(BaseComponent baseComponent, bool isForecast = false)
		{
			_baseComponent = baseComponent;
			//
			// linkADStatus
			//
			_linkAdStatus.Text = "AD Status";
			_linkAdStatus.Margin = _imageLinkLabelMargin;
			_linkAdStatus.Enabled = true;
			_linkAdStatus.Margin = _itemPadding;
			_linkAdStatus.ReflectionType = ReflectionTypes.DisplayInNew;
			_linkAdStatus.DisplayerRequested += LinkAdStatusDisplayerRequested;
			Css.ImageLink.Adjust(_linkAdStatus);
			//
			// linkDiscrepancies
			//
			_linkDiscrepancies.Text = isForecast ? "Forecast" : "Oil Consumption";
			_linkDiscrepancies.Margin = _imageLinkLabelMargin;
			_linkDiscrepancies.Enabled = true;
			_linkDiscrepancies.Margin = _itemPadding;
			Css.ImageLink.Adjust(_linkDiscrepancies);
			_linkDiscrepancies.ReflectionType = ReflectionTypes.DisplayInNew;
			if(isForecast)
				_linkDiscrepancies.DisplayerRequested += LinkDiscrepanciesDisplayerRequested;
			else
				_linkDiscrepancies.DisplayerRequested += LinkOilStatisticsDisplayerRequested;
			
			//
			// linkEngineeringOrders
			//
			_linkEngineeringOrders.Text = "Engineering Orders";
			_linkEngineeringOrders.Margin = _imageLinkLabelMargin;
			_linkEngineeringOrders.Enabled = true;
			_linkEngineeringOrders.Margin = _itemPadding;
			_linkEngineeringOrders.ReflectionType = ReflectionTypes.DisplayInNew;
			_linkEngineeringOrders.DisplayerRequested += LinkEngineeringOrdersDisplayerRequested;
			Css.ImageLink.Adjust(_linkEngineeringOrders);
			//
			// _linkComponentStatus
			//
			_linkComponentStatus.Text = "Component Status";
			_linkComponentStatus.Margin = _imageLinkLabelMargin;
			_linkComponentStatus.Enabled = true;
			_linkComponentStatus.Margin = _itemPadding;
			_linkComponentStatus.ReflectionType = ReflectionTypes.DisplayInNew;
			_linkComponentStatus.DisplayerRequested += LinkComponentStatusDisplayerRequested;
			Css.ImageLink.Adjust(_linkComponentStatus);
			//
			// linkLLPDiskSheetStatus
			//
			_linkLlpDiskSheetStatus.Text = "LLP Disk Sheet Status";
			_linkLlpDiskSheetStatus.Margin = _imageLinkLabelMargin;
			_linkLlpDiskSheetStatus.Enabled = true;
			_linkLlpDiskSheetStatus.Margin = _itemPadding;
			_linkLlpDiskSheetStatus.ReflectionType = ReflectionTypes.DisplayInNew;
			_linkLlpDiskSheetStatus.DisplayerRequested += LinkLLPDiskSheetStatusDisplayerRequested;
			Css.ImageLink.Adjust(_linkLlpDiskSheetStatus);
			//
			// linkSBStatus
			//
			_linkSbStatus.Text = "SB Status";
			_linkSbStatus.Margin = _imageLinkLabelMargin;
			_linkSbStatus.Enabled = true;
			_linkSbStatus.Margin = _itemPadding;
			_linkSbStatus.DisplayerRequested += LinkSbStatusDisplayerRequested;
			Css.ImageLink.Adjust(_linkSbStatus);
			
			BackColor = Css.CommonAppearance.Colors.BackColor;
			Size = new Size(500, 100);
			Controls.Add(_linkAdStatus);
			Controls.Add(_linkEngineeringOrders);
			Controls.Add(_linkDiscrepancies);
			Controls.Add(_linkSbStatus);
			Controls.Add(_linkComponentStatus);
			if (baseComponent != null && baseComponent.BaseComponentType.ItemId == BaseComponentType.Engine.ItemId)
			{
				Controls.Add(_linkLlpDiskSheetStatus);
			}
		}

		private void LinkOilStatisticsDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_baseComponent.ParentAircraftId);
			e.DisplayerText = aircraft.RegistrationNumber + ". Oil Statistics";
			e.RequestedEntity = new OilListScreen(aircraft);
		}

		#endregion

		#region Methods

		#region public void UpdateInformation()

		/// <summary>
		/// ќбновл€ет информацию
		/// </summary>
		public void UpdateInformation()
		{
			DirectiveCollection primarySubDirectives = GlobalObjects.DirectiveCore.GetDirectives(_baseComponent, DirectiveType.AirworthenessDirectives);
			//List<BaseDetailDirective> engineeringOrdersDirectives = GlobalObjects.CasEnvironment.;
			DirectiveCollection sbStatusDirectives = GlobalObjects.DirectiveCore.GetDirectives(_baseComponent, DirectiveType.SB);
		   /* for (int i = 0; i < directives.Length; i++)
			{
				switch (directives[i].DirectiveType.ID)
				{
					case (int)DirectiveTypeID.ADDirectiveTypeID:
						ADDirectives.Add(directives[i]);
						break;
					case (int)DirectiveTypeID.EngeneeringOrdersDirectiveTypeID:
						engineeringOrdersDirectives.Add(directives[i]);
						break;
					case (int)DirectiveTypeID.SBDirectiveTypeID:
						SBStatusDirectives.Add(directives[i]);
						break;
				}
			}*/
			_linkAdStatus.Status =  GetStatus(primarySubDirectives);
			//linkDiscrepancies.Status = (Statuses)baseDetail.ConditionState;
			//linkEngineeringOrders.Status = GetStatus(engineeringOrdersDirectives);
			//DetailCollectionFilter filter = new DetailCollectionFilter(baseDetail.ContainedDetails, new DetailFilter[] { new LLPFilter() });
			//linkLLPDiskSheetStatus.Status = GetStatus(filter.GatherDetails());
			_linkSbStatus.Status = GetStatus(sbStatusDirectives);

			primarySubDirectives.Clear();
			sbStatusDirectives.Clear();
		}

		#endregion

		#region private Statuses GetStatus(IEnumerable<Directive> directives)

		private Statuses GetStatus(IEnumerable<Directive> directives)
		{
			ConditionState cond;
			Statuses directiveStatus = Statuses.NotActive;
			
			foreach (Directive directive in directives)
			{
				cond = GlobalObjects.PerformanceCalculator.GetConditionState(directive);

				if (cond == ConditionState.NotEstimated &&
					directiveStatus == Statuses.NotActive)
					directiveStatus = Statuses.NotActive;

				if (cond == ConditionState.Satisfactory &&
					directiveStatus != Statuses.Notify)
					directiveStatus = Statuses.Satisfactory;

				if (cond == ConditionState.Notify &&
					directiveStatus != Statuses.NotSatisfactory)
					directiveStatus = Statuses.Notify;

				if (cond == ConditionState.Overdue)
					return Statuses.NotSatisfactory;
			}
			/*Statuses status = Statuses.Satisfactory;
			for (int i = 0; i < directives.Count; i++)
			{
				if (directives[i].Condition == DirectiveConditionState.NotSatisfactory)
					status = Statuses.NotSatisfactory;
				if ((directives[i].Condition == DirectiveConditionState.Notify) && (status == Statuses.Satisfactory))
					status = Statuses.Notify;
			}*/
			return directiveStatus;
		}

		#endregion

		#region private Statuses GetStatus(Detail[] details)

		private Statuses GetStatus(Component[] components)
		{

			Statuses status = Statuses.Satisfactory;
			/*for (int i = 0; i < details.Length; i++)
			{
				if (details[i].ConditionState == DirectiveConditionState.NotSatisfactory)
					status = Statuses.NotSatisfactory;
				if ((details[i].ConditionState == DirectiveConditionState.Notify) && (status == Statuses.Satisfactory))
					status = Statuses.Notify;
			}*/
			return status; 
		}

		#endregion

		#region private void LinkAdStatusDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkAdStatusDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			OnAdStatusLinkDisplayRequested(e);
		}

		#endregion

		#region private void LinkDiscrepanciesDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkDiscrepanciesDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			OnDiscrepanciesLinkDisplayRequested(e);
		}

		#endregion

		#region private void LinkEngineeringOrdersDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkEngineeringOrdersDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			OnEngineeringOrdersLinkDisplayRequested(e);
		}

		#endregion

		#region private void LinkComponentStatusDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkComponentStatusDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			OnComponentStatusLinkDisplayRequested(e);
		}

		#endregion

		#region private void LinkLLPDiskSheetStatusDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkLLPDiskSheetStatusDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			OnLLPDiskSheetStatusLinkDisplayRequested(e);
		}

		#endregion

		#region private void LinkSbStatusDisplayerRequested(object sender, ReferenceEventArgs e)

		private void LinkSbStatusDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			OnSBStatusLinkDisplayRequested(e);
		}

		#endregion

		#region public void OnAdStatusLinkDisplayRequested(ReferenceEventArgs e)

		/// <summary>
		/// ћетод, обрабатывающий событие нажати€ ссылки AD Status 
		/// </summary>
		/// <param name="e"></param>
		public void OnAdStatusLinkDisplayRequested(ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//if (_baseDetail.BaseDetailType==BaseDetailType.Frame)
			//{
			//    e.DisplayerText = _baseDetail.ParentAircraft.RegistrationNumber + ". " + PrimaryDirectiveType.AirworthenessDirectives.CommonName;
			//    e.RequestedEntity = new PrimeDirectiveListScreen(_baseDetail.ParentAircraft, PrimaryDirectiveType.AirworthenessDirectives);
			//}
			//else
			//{
			if(_baseComponent.ParentAircraftId > 0)
				e.DisplayerText = $"{_baseComponent.GetParentAircraftRegNumber()}. {_baseComponent}. {DirectiveType.AirworthenessDirectives.CommonName}";
			else
					e.DisplayerText = _baseComponent + ". " + DirectiveType.AirworthenessDirectives.CommonName;
				e.RequestedEntity = new PrimeDirectiveListScreen(_baseComponent, DirectiveType.AirworthenessDirectives);
			//}
		}

		#endregion

		#region public void OnDiscrepanciesLinkDisplayRequested(ReferenceEventArgs e)
		/// <summary>
		/// ћетод, обрабатывающий событие нажати€ ссылки Discrepancies
		/// </summary>
		/// <param name="e"></param>
		public void OnDiscrepanciesLinkDisplayRequested(ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(_baseComponent.ParentAircraftId);//TODO:(Evgenii Babak) пересмотреть использование ParentAircrafId здесь
			var parentStore = GlobalObjects.StoreCore.GetStoreById(_baseComponent.ParentStoreId);
			if (_baseComponent.BaseComponentType==BaseComponentType.Frame)
				e.DisplayerText = $"{_baseComponent.GetParentAircraftRegNumber()}. Aircraft Frame SN {_baseComponent.SerialNumber}. Forecast";
			else
			{
				if (parentAircraft != null)
				{
					e.DisplayerText = $"{_baseComponent.GetParentAircraftRegNumber()}. {_baseComponent}. Forecast";
				}

				if (parentStore != null)
				{
					e.DisplayerText = parentStore.Name + ". " + _baseComponent + ". Forecast";
				}
			}
			ForecastData forecastData = null;
			
			if (parentAircraft != null)
			{
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);
				forecastData = new ForecastData(DateTime.Today, averageUtilization, GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_baseComponent));
			}

			if (parentStore != null)
			{
			   forecastData = new ForecastData(DateTime.Today, new AverageUtilization(10,5,UtilizationInterval.Dayly), GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_baseComponent));
			}

			if (forecastData != null) e.RequestedEntity = new ForecastListScreen(_baseComponent, DirectiveType.All);
		}

		#endregion

		#region public void OnEnginereengOrdersLinkDisplayRequested(ReferenceEventArgs e)

		/// <summary>
		/// ћетод, обрабатывающий событие нажати€ ссылки Engineering Orders
		/// </summary>
		/// <param name="e"></param>
		public void OnEngineeringOrdersLinkDisplayRequested(ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//if (_baseDetail.BaseDetailType == BaseDetailType.Frame)
			//{
			//    e.DisplayerText = _baseDetail.ParentAircraft.RegistrationNumber + ". " + PrimaryDirectiveType.EngineeringOrders.CommonName;
			//    e.RequestedEntity = new PrimeDirectiveListScreen(_baseDetail.ParentAircraft, PrimaryDirectiveType.EngineeringOrders);
			//}
			//else
			//{
			if (_baseComponent.ParentAircraftId > 0)
				e.DisplayerText = $"{_baseComponent.GetParentAircraftRegNumber()}. {_baseComponent}. DirectiveType.EngineeringOrders.CommonName";
			else
					e.DisplayerText = _baseComponent + ". " + DirectiveType.EngineeringOrders.CommonName;
				e.RequestedEntity = new PrimeDirectiveListScreen(_baseComponent, DirectiveType.EngineeringOrders);
			//}
			
		}

		#endregion

		#region public void OnComponentStatusLinkDisplayRequested(ReferenceEventArgs e)

		/// <summary>
		/// ћетод, обрабатывающий событие нажати€ ссылки LLP Disk Sheet Status
		/// </summary>
		/// <param name="e"></param>
		private void OnComponentStatusLinkDisplayRequested(ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = _baseComponent + ". Component Status";
			e.RequestedEntity = new ComponentsListScreen(_baseComponent, MaintenanceControlProcess.Items.ToArray(),false);
		}

		#endregion

		#region public void OnLLPDiskSheetStatusLinkDisplayRequested(ReferenceEventArgs e)

		/// <summary>
		/// ћетод, обрабатывающий событие нажати€ ссылки LLP Disk Sheet Status
		/// </summary>
		/// <param name="e"></param>
		public void OnLLPDiskSheetStatusLinkDisplayRequested(ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.DisplayerText = _baseComponent + ". LLP Disc Sheet Status";
			e.RequestedEntity = new ComponentsListScreen(_baseComponent, MaintenanceControlProcess.Items.ToArray(), true);
		}

		#endregion

		#region public void OnSBStatusLinkDisplayRequested(ReferenceEventArgs e)

		/// <summary>
		/// ћетод, обрабатывающий событие нажати€ ссылки SB Status
		/// </summary>
		/// <param name="e"></param>
		public void OnSBStatusLinkDisplayRequested(ReferenceEventArgs e)
		{
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			//if (_baseDetail.BaseDetailType==BaseDetailType.Frame)
			//{
			//    e.DisplayerText = _baseDetail.ParentAircraft.RegistrationNumber + ". " + PrimaryDirectiveType.SB.CommonName;
			//    e.RequestedEntity = new PrimeDirectiveListScreen(_baseDetail.ParentAircraft, PrimaryDirectiveType.SB);
			//}
			//else
			//{
				if (_baseComponent.ParentAircraftId > 0)
					e.DisplayerText = $"{_baseComponent.GetParentAircraftRegNumber()}. {_baseComponent}. {DirectiveType.SB.CommonName}";
			else
					e.DisplayerText = _baseComponent + ". " + DirectiveType.SB.CommonName;
				e.RequestedEntity = new PrimeDirectiveListScreen(_baseComponent, DirectiveType.SB);
			//}
		}

		#endregion

		#region public void SetEnabled(bool enabled)

		/// <summary>
		/// «адает свойство Enabled ссылкам
		/// </summary>
		/// <param name="enabled"></param>
		public void SetEnabled(bool enabled)
		{
			_linkAdStatus.Enabled = enabled;
			_linkDiscrepancies.Enabled = enabled;
			_linkEngineeringOrders.Enabled = enabled;
			_linkLlpDiskSheetStatus.Enabled = enabled;
			_linkSbStatus.Enabled = enabled;
		}

		#endregion

		#endregion
	}
}
