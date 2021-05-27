using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AvControls;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls;
using CAS.UI.UIControls.AircraftTechnicalLogBookControls.AircraftFlightLight;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentChangeReport;
using CAS.UI.UIControls.ComponentControls;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.Discrepancies;
using CAS.UI.UIControls.DocumentationControls;
using CAS.UI.UIControls.ForecastControls;
using CAS.UI.UIControls.LDND;
using CAS.UI.UIControls.MaintananceProgram;
using CAS.UI.UIControls.MonthlyUtilizationsControls;
using CAS.UI.UIControls.MTOP;
using CAS.UI.UIControls.NonRoutineJobsControls;
using CAS.UI.UIControls.PurchaseControls;
using CAS.UI.UIControls.SMSControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using EntityCore.DTO.General;
using EntityCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.SMS;
using SmartCore.Filters;
using Component = SmartCore.Entities.General.Accessory.Component;

namespace CAS.UI.UIControls.AircraftsControls
{
	///<summary>
	/// Экран для отображения полной информации о состоянии ВС
	///</summary>
	public partial class AircraftScreen : ScreenControl
	{
		#region Fields

		#endregion

		#region Constructors
		///<summary>
		/// Конструктор по умолчанию
		///</summary>
		private AircraftScreen()
		{
			InitializeComponent();
			DoubleBuffered = true;
		}

		///<summary>
		/// Создает ЭУ на основе переданного ВС
		///</summary>
		///<param name="currentAircraft">ВС которое требуется отобразить</param>
		///<exception cref="ArgumentNullException"></exception>
		public AircraftScreen(Aircraft currentAircraft) : this()
		{
			if (currentAircraft == null)
				throw new ArgumentNullException("currentAircraft", "Cannot display null-aircraft");
			CurrentAircraft = currentAircraft;

//#if !DEBUG
//           LinkAircraftSummary.Visible = false;
//#endif
		}

		#endregion

		#region public override void OnInitCompletion(object sender)
		/// <summary>
		/// Метод, вызывается после добавления содежимого на отображатель(вкладку)
		/// </summary>
		/// <returns></returns>
		public override void OnInitCompletion(object sender)
		{
			AnimatedThreadWorker.RunWorkerAsync();

			base.OnInitCompletion(sender);
		}
		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				return;

			//baseDetailButtons.Aircraft = CurrentAircraft;
		}
		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			#region Загрузка элементов

			AnimatedThreadWorker.ReportProgress(0, "Check Aircraft");
			GlobalObjects.AircraftsCore.ResetAircraft(CurrentAircraft);

			var aircraftEquip = GlobalObjects.CasEnvironment.NewLoader.GetObjectList<AircraftEquipmentDTO, AircraftEquipments>(new Filter("AircraftId", EntityCore.Attributte.FilterType.Equal, CurrentAircraft.ItemId), true);
			CurrentAircraft.AircraftEquipments.Clear();
			CurrentAircraft.AircraftEquipments.AddRange(aircraftEquip);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(3, "Load Aircraft Flights");
			GlobalObjects.AircraftFlightsCore.LoadAircraftFlights(CurrentAircraft.ItemId);
			GlobalObjects.CasEnvironment.Calculator.ResetMath(CurrentAircraft);

			//if (AnimatedThreadWorker.CancellationPending)
			//{
			//	e.Cancel = true;
			//	return;
			//}
			//TODO:(Evgenii Babak) Переименовать Detail в Component
			AnimatedThreadWorker.ReportProgress(6, "Check Base Details");
			GetBaseComponents(AnimatedThreadWorker);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(13, "Check Statuses");
			GetComponentStatus(AnimatedThreadWorker, e);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(25, "Check Directives");
			GetDirectivesStatus(AnimatedThreadWorker, e);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(38, "Check General Info");
			GetGeneralInfoStatus(AnimatedThreadWorker, e);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(50, "Check Maintenance");
			GetMaintenanceStatus(AnimatedThreadWorker, e);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(63, "Check Planning");
			GetPlanningStatus(AnimatedThreadWorker, e);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(75, "Check Purchase");
			GetPurchaseStatus(AnimatedThreadWorker, e);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(88, "Check SMS");
			GetSmsStatus(AnimatedThreadWorker, e);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			AnimatedThreadWorker.ReportProgress(100, "Complete");
			
			#endregion
		}
		#endregion

		#region private void GetBaseComponents(AnimatedThreadWorker bgw)

		private void GetBaseComponents(AnimatedThreadWorker bgw)
		{
			try
			{
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				bgw.ReportProgress(0, "Check Base Details");

				BeginInvoke(new Action(() => _baseComponentButtons.Reset()));
				//извлечение и собрание всех компонентов самолета
				//(деталей и базовых деталей) в одну коллекцию
				var baseComponents = GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId);

				if (baseComponents.Length == 0)return;

				#region проверка Base Details
				//TODO:(Evgenii Babak) Переименовать Detail в Component
				bgw.ReportProgress(0, "Check Base Details");

				BaseComponent[] frameApus =
					baseComponents.Where(bd => bd.BaseComponentType == BaseComponentType.Frame || 
									  bd.BaseComponentType == BaseComponentType.Apu).ToArray();
				BaseComponent[] engines =
					baseComponents.Where(bd => bd.BaseComponentType == BaseComponentType.Engine && bd.TransferRecords.GetLast().DODR).ToArray();
				BaseComponent[] propellers =
					baseComponents.Where(bd => bd.BaseComponentType == BaseComponentType.Propeller && bd.TransferRecords.GetLast().DODR).ToArray();
				BaseComponent[] landingGears =
					baseComponents.Where(bd => bd.BaseComponentType == BaseComponentType.LandingGear && bd.TransferRecords.GetLast().DODR).ToArray();

				foreach (var baseComponent in frameApus)
					Invoke(new Action<BaseComponent>(s => _baseComponentButtons.Add(s)), baseComponent);
				Thread.Sleep(300);

				foreach (var baseComponent in engines)
					Invoke(new Action<BaseComponent>(s => _baseComponentButtons.Add(s)), baseComponent);
				Thread.Sleep(300);

				foreach (var baseComponent in propellers)
					Invoke(new Action<BaseComponent>(s => _baseComponentButtons.Add(s)), baseComponent);
				Thread.Sleep(300);

				foreach (var baseComponent in landingGears)
					Invoke(new Action<BaseComponent>(s => _baseComponentButtons.Add(s)), baseComponent);
				Thread.Sleep(300);

				#endregion

				BeginInvoke(new Action(() => _baseComponentButtons.CheckContainers()));
				_baseComponentButtons.ComponentMovedTo += _baseComponentButtons_ComponentMovedTo;

			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check component status", exception);
			}
		}

		private void _baseComponentButtons_ComponentMovedTo(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void GetComponentStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)

		private void GetComponentStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)
		{
			try
			{
				bgw.ReportProgress(13, "Check Components");
				//извлечение и собрание всех компонентов самолета
				//(деталей и базовых деталей) в одну коллекцию
				var components = GlobalObjects.ComponentCore.GetComponents(CurrentAircraft.ItemId);
				var baseComponents = new BaseComponentCollection(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
				if (components.Count == 0 && baseComponents.Count == 0)
				{
					BeginInvoke(new Action(() => LinkAvionxInventory.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkComponentStatus.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkComponentStatusHT.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkComponentStatusOCCM.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkLandingGearStatus.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => ContainerComponents.UpperLeftIcon = Properties.Resources.BlueArrow));
				}
				else
				{
					#region проверка Base details

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}
					//TODO:(Evgenii Babak) Переименовать Detail в Component
					bgw.ReportProgress(13, "Check Components: Base details");

					var baseComponentsStatuses = new Dictionary<BaseComponent, Statuses>();
					Statuses baseComponentsStatus = Statuses.NotActive;

					foreach (var baseComponent in baseComponents)
					{
						baseComponentsStatuses.Add(baseComponent, Statuses.NotActive);
						//Определение статуса текущей базовой детали и общего статуса по всем базовым деталям
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(baseComponent);
						if (directiveCond == ConditionState.NotEstimated && baseComponentsStatus == Statuses.NotActive)
							baseComponentsStatus = Statuses.NotActive;

						if (directiveCond == ConditionState.Satisfactory && 
							baseComponentsStatus != Statuses.Notify && 
							baseComponentsStatus != Statuses.NotSatisfactory)
							baseComponentsStatus = Statuses.Satisfactory;

						if (directiveCond == ConditionState.Notify && baseComponentsStatus != Statuses.NotSatisfactory)
							baseComponentsStatus = Statuses.Notify;

						if (directiveCond == ConditionState.Overdue)
							baseComponentsStatus = Statuses.NotSatisfactory;
						
						//Поиск кнокпи, отображающей тек. Базовую деталь
						BaseComponentControl control = _baseComponentButtons.GetByBaseDetail(baseComponent);
						//Если кнопки нет, переход на след. итерацию
						if (control == null) continue;
						//Присвоение расчитанного статуса кнопке с тек. базовой деталью
						control.BaseComponentCondition = directiveCond;
					}
					#endregion

					#region проверка Avionics Inventory

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(15, "Check Components: Avionics inventory");

					Statuses allAvionxInvStatus = Statuses.NotActive;
					IEnumerable<Component> avionx =
						components.Where(d => d.AvionicsInventory != AvionicsInventoryMarkType.None);
					//группировка компонентов по их родитеским деталям
					IEnumerable<IGrouping<BaseComponent,Component>> groupAvionx = avionx.GroupBy(d => d.ParentBaseComponent); //TODO:(Evgenii Babak) заменить на использование ComponentCore
					foreach (IGrouping<BaseComponent, Component> groupAvionic in groupAvionx)
					{
						Statuses bdAvionxInvStatus = Statuses.NotActive;
						foreach (var component in groupAvionic)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(component);
							if (directiveCond == ConditionState.NotEstimated && bdAvionxInvStatus == Statuses.NotActive)
								bdAvionxInvStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdAvionxInvStatus != Statuses.Notify)
								bdAvionxInvStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdAvionxInvStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdAvionxInvStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по базовой детали
						if (bdAvionxInvStatus == Statuses.NotActive && 
							baseComponentsStatuses[groupAvionic.Key] == Statuses.NotActive)
							baseComponentsStatuses[groupAvionic.Key] = Statuses.NotActive;

						if (bdAvionxInvStatus == Statuses.Satisfactory &&
							baseComponentsStatuses[groupAvionic.Key] != Statuses.Notify &&
							baseComponentsStatuses[groupAvionic.Key] != Statuses.NotSatisfactory)
							baseComponentsStatuses[groupAvionic.Key] = Statuses.Satisfactory;

						if (bdAvionxInvStatus == Statuses.Notify &&
							baseComponentsStatuses[groupAvionic.Key] != Statuses.NotSatisfactory)
							baseComponentsStatuses[groupAvionic.Key] = Statuses.Notify;

						if (bdAvionxInvStatus == Statuses.NotSatisfactory)
							baseComponentsStatuses[groupAvionic.Key] = Statuses.NotSatisfactory;
						#endregion

						#region Пересчет общего статуса по авионике
						if (bdAvionxInvStatus == Statuses.NotActive && allAvionxInvStatus == Statuses.NotActive)
							allAvionxInvStatus = Statuses.NotActive;

						if (bdAvionxInvStatus == Statuses.Satisfactory &&
							allAvionxInvStatus != Statuses.Notify &&
							allAvionxInvStatus != Statuses.NotSatisfactory)
							allAvionxInvStatus = Statuses.Satisfactory;

						if (bdAvionxInvStatus == Statuses.Notify && allAvionxInvStatus != Statuses.NotSatisfactory)
							allAvionxInvStatus = Statuses.Notify;

						if (bdAvionxInvStatus == Statuses.NotSatisfactory)
							allAvionxInvStatus = Statuses.NotSatisfactory;
						#endregion
					}

					BeginInvoke(new Action<Statuses>(s => LinkAvionxInventory.Status = s),allAvionxInvStatus);

					#endregion

					#region проверка Component Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(17, "Check Components: Component Status");

					Statuses allComponentStatus = Statuses.NotActive;
					//группировка компонентов по их родитеским деталям
					IEnumerable<IGrouping<BaseComponent, Component>> groupDetails = components.GroupBy(d => d.ParentBaseComponent);//TODO:(Evgenii Babak) заменить на использование ComponentCore
					foreach (IGrouping<BaseComponent, Component> groupDetail in groupDetails)
					{
						Statuses bdComponentStatus = Statuses.NotActive;
						foreach (Component detail in groupDetail)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(detail);
							if (directiveCond == ConditionState.NotEstimated && bdComponentStatus == Statuses.NotActive)
								bdComponentStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdComponentStatus != Statuses.Notify)
								bdComponentStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdComponentStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdComponentStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по базовой детали

						if (groupDetail.Key != null && baseComponentsStatuses.ContainsKey(groupDetail.Key))
						{
							if (bdComponentStatus == Statuses.NotActive &&
							    baseComponentsStatuses[groupDetail.Key] == Statuses.NotActive)
								baseComponentsStatuses[groupDetail.Key] = Statuses.NotActive;

							if (bdComponentStatus == Statuses.Satisfactory &&
							    baseComponentsStatuses[groupDetail.Key] != Statuses.Notify &&
							    baseComponentsStatuses[groupDetail.Key] != Statuses.NotSatisfactory)
								baseComponentsStatuses[groupDetail.Key] = Statuses.Satisfactory;

							if (bdComponentStatus == Statuses.Notify &&
							    baseComponentsStatuses[groupDetail.Key] != Statuses.NotSatisfactory)
								baseComponentsStatuses[groupDetail.Key] = Statuses.Notify;

							if (bdComponentStatus == Statuses.NotSatisfactory)
								baseComponentsStatuses[groupDetail.Key] = Statuses.NotSatisfactory;
						}

						#endregion

						#region Пересчет общего статуса по всем компонентам
						if (bdComponentStatus == Statuses.NotActive && allComponentStatus == Statuses.NotActive)
							allComponentStatus = Statuses.NotActive;

						if (bdComponentStatus == Statuses.Satisfactory &&
							allComponentStatus != Statuses.Notify &&
							allComponentStatus != Statuses.NotSatisfactory)
							allComponentStatus = Statuses.Satisfactory;

						if (bdComponentStatus == Statuses.Notify && allComponentStatus != Statuses.NotSatisfactory)
							allComponentStatus = Statuses.Notify;

						if (bdComponentStatus == Statuses.NotSatisfactory)
							allComponentStatus = Statuses.NotSatisfactory;
						#endregion
					}

					BeginInvoke(new Action<Statuses>(s => LinkComponentStatus.Status = s), allComponentStatus);
					#endregion

					#region проверка Component HT Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(19, "Check Components: Component HT Status");

					Statuses allComponentStatusHT = Statuses.NotActive;
					//группировка компонентов по их родитеским деталям
					var groupComponentsHT = components.Where(d => d.MaintenanceControlProcess == MaintenanceControlProcess.HT)
													  .GroupBy(d => d.ParentBaseComponent);
					foreach (IGrouping<BaseComponent, Component> groupComponent in groupComponentsHT)
					{
						Statuses bdComponentHTStatus = Statuses.NotActive;
						foreach (var component in groupComponent)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(component);
							if (directiveCond == ConditionState.NotEstimated && bdComponentHTStatus == Statuses.NotActive)
								bdComponentHTStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdComponentHTStatus != Statuses.Notify)
								bdComponentHTStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdComponentHTStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdComponentHTStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по всем Hard Time компонентам
						if (bdComponentHTStatus == Statuses.NotActive && allComponentStatusHT == Statuses.NotActive)
							allComponentStatusHT = Statuses.NotActive;

						if (bdComponentHTStatus == Statuses.Satisfactory &&
							allComponentStatusHT != Statuses.Notify &&
							allComponentStatusHT != Statuses.NotSatisfactory)
							allComponentStatusHT = Statuses.Satisfactory;

						if (bdComponentHTStatus == Statuses.Notify && allComponentStatusHT != Statuses.NotSatisfactory)
							allComponentStatusHT = Statuses.Notify;

						if (bdComponentHTStatus == Statuses.NotSatisfactory)
							allComponentStatusHT = Statuses.NotSatisfactory;
						#endregion
					}

					BeginInvoke(new Action<Statuses>(s => LinkComponentStatusHT.Status = s), allComponentStatusHT);
					#endregion

					#region проверка Component OCCM Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(21, "Check Components: Component OC/CM Status");

					Statuses allComponentStatusOCCM = Statuses.NotActive;
					//группировка компонентов по их родитеским деталям
					var groupComponentsOCCM = components.Where(d => d.MaintenanceControlProcess == MaintenanceControlProcess.OC || 
																	d.MaintenanceControlProcess == MaintenanceControlProcess.CM)
														.GroupBy(d => d.ParentBaseComponent);
					foreach (var groupComponent in groupComponentsOCCM)
					{
						Statuses bdComponentOCCMStatus = Statuses.NotActive;
						foreach (var component in groupComponent)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(component);
							if (directiveCond == ConditionState.NotEstimated && bdComponentOCCMStatus == Statuses.NotActive)
								bdComponentOCCMStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdComponentOCCMStatus != Statuses.Notify)
								bdComponentOCCMStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdComponentOCCMStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdComponentOCCMStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по всем On Condition/Condition Monitoring компонентам
						if (bdComponentOCCMStatus == Statuses.NotActive && allComponentStatusOCCM == Statuses.NotActive)
							allComponentStatusOCCM = Statuses.NotActive;

						if (bdComponentOCCMStatus == Statuses.Satisfactory &&
							allComponentStatusOCCM != Statuses.Notify &&
							allComponentStatusOCCM != Statuses.NotSatisfactory)
							allComponentStatusOCCM = Statuses.Satisfactory;

						if (bdComponentOCCMStatus == Statuses.Notify && allComponentStatusOCCM != Statuses.NotSatisfactory)
							allComponentStatusOCCM = Statuses.Notify;

						if (bdComponentOCCMStatus == Statuses.NotSatisfactory)
							allComponentStatusOCCM = Statuses.NotSatisfactory;
						#endregion
					}
					BeginInvoke(new Action<Statuses>(s => LinkComponentStatusOCCM.Status = s), allComponentStatusOCCM);

					#endregion

					#region проверка LG Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(23, "Check Components: LG Status");

					Statuses allLGStatus = Statuses.NotActive;
					var groupLG = components
						.Where(d => (d.ParentBaseComponent != null && d.ParentBaseComponent.BaseComponentTypeId == BaseComponentType.LandingGear.ItemId) 
								 || (d is BaseComponent && ((BaseComponent)d).BaseComponentTypeId == BaseComponentType.LandingGear.ItemId))
						.GroupBy(d => d.ParentBaseComponent);
					foreach (IGrouping<BaseComponent, Component> groupComponent in groupLG)
					{
						Statuses bdComponentLGStatus = Statuses.NotActive;
						foreach (var component in groupComponent)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(component);
							if (directiveCond == ConditionState.NotEstimated && bdComponentLGStatus == Statuses.NotActive)
								bdComponentLGStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdComponentLGStatus != Statuses.Notify)
								bdComponentLGStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdComponentLGStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdComponentLGStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по всем Шасси
						if (bdComponentLGStatus == Statuses.NotActive && allLGStatus == Statuses.NotActive)
							allLGStatus = Statuses.NotActive;

						if (bdComponentLGStatus == Statuses.Satisfactory &&
							allLGStatus != Statuses.Notify &&
							allLGStatus != Statuses.NotSatisfactory)
							allLGStatus = Statuses.Satisfactory;

						if (bdComponentLGStatus == Statuses.Notify && allLGStatus != Statuses.NotSatisfactory)
							allLGStatus = Statuses.Notify;

						if (bdComponentLGStatus == Statuses.NotSatisfactory)
							allLGStatus = Statuses.NotSatisfactory;
						#endregion
					}
					BeginInvoke(new Action<Statuses>(s => LinkLandingGearStatus.Status = s), allLGStatus);

					#endregion

					#region проверка LLP Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(23, "Check Components: LLP Status");

					var groupLLP = components
						.Where(d => d.ParentBaseComponent != null && d.ParentBaseComponent.BaseComponentTypeId == BaseComponentType.Engine.ItemId)
						.GroupBy(d => d.ParentBaseComponent);
					foreach (var groupComponent in groupLLP)
					{
						Statuses bdComponentLLPStatus = Statuses.NotActive;
						foreach (var component in groupComponent)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(component);
							if (directiveCond == ConditionState.NotEstimated && bdComponentLLPStatus == Statuses.NotActive)
								bdComponentLLPStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdComponentLLPStatus != Statuses.Notify)
								bdComponentLLPStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdComponentLLPStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdComponentLLPStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по базовой детали

						//Поиск кнокпи, отображающей тек. Базовую деталь
						BaseComponentControl control = _baseComponentButtons.GetByBaseDetail(groupComponent.Key);
						//Если кнопки нет, переход на след. итерацию
						if (control == null) continue;
						//Присвоение расчитанного статуса кнопке с тек. базовой деталью
						control.ComponentsLLPStatus = bdComponentLLPStatus;

						#endregion
					}
					BeginInvoke(new Action<Statuses>(s => LinkLandingGearStatus.Status = s), allLGStatus);

					#endregion

					#region Проверка статуса компонентов каждой базовой детали
					foreach (KeyValuePair<BaseComponent, Statuses> pair in baseComponentsStatuses)
					{
						//Поиск кнокпи, отображающей тек. Базовую деталь
						BaseComponentControl control = _baseComponentButtons.GetByBaseDetail(pair.Key);
						//Если кнопки нет, переход на след. итерацию
						if (control == null) continue;
						//Присвоение расчитанного статуса кнопке с тек. базовой деталью
						control.ComponentsStatus = pair.Value;
					}
					#endregion

					#region Проверка статуса контейнера компонентов

					List<Statuses> compStatuses = new List<Statuses>(new[]{baseComponentsStatus, allAvionxInvStatus, allComponentStatus, allComponentStatusHT,
																		   allComponentStatusOCCM, allLGStatus});
					Image componentsContainerImage = Properties.Resources.BlueArrow;
					foreach (Statuses dirStat in compStatuses)
					{
						if (dirStat == Statuses.Satisfactory && componentsContainerImage != Properties.Resources.OrangeArrow)
							componentsContainerImage = Properties.Resources.GreenArrow;
						if (dirStat == Statuses.Notify)
							componentsContainerImage = Properties.Resources.OrangeArrow;
						if (dirStat == Statuses.NotSatisfactory)
						{
							componentsContainerImage = Properties.Resources.RedArrow;
							break;
						}
					}
					BeginInvoke(new Action<Image>(s => ContainerComponents.UpperLeftIcon = s), componentsContainerImage);
					#endregion
				}
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check component status", exception);
			}
		}
		#endregion

		#region private void GetDirectivesStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)

		private void GetDirectivesStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)
		{
			try
			{
				bgw.ReportProgress(25, "Check Directives");
				DirectiveCollection directives = GlobalObjects.DirectiveCore.GetDirectives(CurrentAircraft, DirectiveType.All);
				DirectiveCollection deferreds = GlobalObjects.DirectiveCore.GetDeferredItems(parentAircraft: CurrentAircraft);
				DirectiveCollection damages = GlobalObjects.DirectiveCore.GetDamageItems(parentAircraft: CurrentAircraft);
				if (directives.Count == 0 && deferreds.Count == 0 && damages.Count == 0)
				{
					BeginInvoke(new Action(() => LinkADStatus.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkADStatusAF.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkADStatusAP.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkCPCPStatus.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkDamages.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkDeferredItems.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkEOStatus.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkModifications.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkOoPStatus.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkSBStatus.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => ContainerDirectives.UpperLeftIcon = Properties.Resources.BlueArrow));
				}
				else
				{
					#region проверка ADStatus

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(25, "Check Directives: AD Status");

					Statuses allADStatus = Statuses.NotActive;
					IEnumerable<Directive> ads =
						directives.Where(p => p.DirectiveType == DirectiveType.AirworthenessDirectives);
					//группировка компонентов по их родитеским деталям
					IEnumerable<IGrouping<BaseComponent, Directive>> groupADs = ads.GroupBy(d => d.ParentBaseComponent);
					foreach (IGrouping<BaseComponent, Directive> groupAd in groupADs)
					{
						Statuses bdADStatus = Statuses.NotActive;
						foreach (Directive primaryDirective in groupAd)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
							if (directiveCond == ConditionState.NotEstimated && bdADStatus == Statuses.NotActive)
								bdADStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdADStatus != Statuses.Notify)
								bdADStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdADStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdADStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по базовой детали

						//Поиск кнокпи, отображающей тек. Базовую деталь
						BaseComponentControl control = _baseComponentButtons.GetByBaseDetail(groupAd.Key);
						//Если кнопки нет, переход на след. итерацию
						if (control == null) continue;
						//Присвоение расчитанного статуса кнопке с тек. базовой деталью
						control.ADStatus = bdADStatus;

						#endregion

						#region Пересчет общего статуса по всем директивам
						if (bdADStatus == Statuses.NotActive && allADStatus == Statuses.NotActive)
							allADStatus = Statuses.NotActive;

						if (bdADStatus == Statuses.Satisfactory &&
							allADStatus != Statuses.Notify &&
							allADStatus != Statuses.NotSatisfactory)
							allADStatus = Statuses.Satisfactory;

						if (bdADStatus == Statuses.Notify && allADStatus != Statuses.NotSatisfactory)
							allADStatus = Statuses.Notify;

						if (bdADStatus == Statuses.NotSatisfactory)
							allADStatus = Statuses.NotSatisfactory;
						#endregion
					}

					BeginInvoke(new Action<Statuses>(s => LinkADStatus.Status = s), allADStatus);

					Statuses adStatusAF = Statuses.NotActive;
					IEnumerable<Directive> adafs = ads.Where(p => p.ADType == (short)ADType.Airframe);
					foreach (Directive primaryDirective in adafs)
					{
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
						if (directiveCond == ConditionState.NotEstimated && adStatusAF == Statuses.NotActive)
							adStatusAF = Statuses.NotActive;
						if (directiveCond == ConditionState.Satisfactory && adStatusAF != Statuses.Notify)
							adStatusAF = Statuses.Satisfactory;
						if (directiveCond == ConditionState.Notify)
							adStatusAF = Statuses.Notify;
						if (directiveCond == ConditionState.Overdue)
						{
							adStatusAF = Statuses.NotSatisfactory;
							break;
						}
					}
					BeginInvoke(new Action<Statuses>(s => LinkADStatusAF.Status = s), adStatusAF);

					Statuses adStatusAP = Statuses.NotActive;
					IEnumerable<Directive> adaps = ads.Where(p => p.ADType == ADType.Appliance);
					foreach (Directive primaryDirective in adaps)
					{
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
						if (directiveCond == ConditionState.NotEstimated && adStatusAP == Statuses.NotActive)
							adStatusAP = Statuses.NotActive;
						if (directiveCond == ConditionState.Satisfactory && adStatusAP != Statuses.Notify)
							adStatusAP = Statuses.Satisfactory;
						if (directiveCond == ConditionState.Notify)
							adStatusAP = Statuses.Notify;
						if (directiveCond == ConditionState.Overdue)
						{
							adStatusAP = Statuses.NotSatisfactory;
							break;
						}
					}

					BeginInvoke(new Action<Statuses>(s => LinkADStatusAP.Status = s), adStatusAP);

					#endregion

					#region проверка Damage Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(27, "Check Directives: Damages Status");

					Statuses damageStatus = Statuses.NotActive;

					foreach (Directive primaryDirective in damages)
					{
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
						if (directiveCond == ConditionState.NotEstimated && damageStatus == Statuses.NotActive)
							damageStatus = Statuses.NotActive;
						if (directiveCond == ConditionState.Satisfactory && damageStatus != Statuses.Notify)
							damageStatus = Statuses.Satisfactory;
						if (directiveCond == ConditionState.Notify)
							damageStatus = Statuses.Notify;
						if (directiveCond == ConditionState.Overdue)
						{
							damageStatus = Statuses.NotSatisfactory;
							break;
						}
					}
					BeginInvoke(new Action<Statuses>(s => LinkDamages.Status = s), damageStatus);

					#endregion

					#region проверка Deferred Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(30, "Check Directives: Deferred Status");

					Statuses deferredStatus = Statuses.NotActive;

					foreach (Directive primaryDirective in deferreds)
					{
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
						if (directiveCond == ConditionState.NotEstimated && deferredStatus == Statuses.NotActive)
							deferredStatus = Statuses.NotActive;
						if (directiveCond == ConditionState.Satisfactory && deferredStatus != Statuses.Notify)
							deferredStatus = Statuses.Satisfactory;
						if (directiveCond == ConditionState.Notify)
							deferredStatus = Statuses.Notify;
						if (directiveCond == ConditionState.Overdue)
						{
							deferredStatus = Statuses.NotSatisfactory;
							break;
						}
					}
					BeginInvoke(new Action<Statuses>(s => LinkDeferredItems.Status = s), deferredStatus);

					#endregion

					#region проверка EO Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(31, "Check Directives: Engineering order Status");

					Statuses allEOStatus = Statuses.NotActive;
					//группировка компонентов по их родитеским деталям
					IEnumerable<IGrouping<BaseComponent, Directive>> groupEOs =
						directives.Where(p => p.DirectiveType == DirectiveType.EngineeringOrders || 
											  p.EngineeringOrders != "" || 
											  p.EngineeringOrderFile != null)
								  .GroupBy(d => d.ParentBaseComponent);
					foreach (IGrouping<BaseComponent, Directive> groupEO in groupEOs)
					{
						Statuses bdEOStatus = Statuses.NotActive;
						foreach (Directive primaryDirective in groupEO)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
							if (directiveCond == ConditionState.NotEstimated && bdEOStatus == Statuses.NotActive)
								bdEOStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdEOStatus != Statuses.Notify)
								bdEOStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdEOStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdEOStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по базовой детали

						//Поиск кнокпи, отображающей тек. Базовую деталь
						BaseComponentControl control = _baseComponentButtons.GetByBaseDetail(groupEO.Key);
						//Если кнопки нет, переход на след. итерацию
						if (control == null) continue;
						//Присвоение расчитанного статуса кнопке с тек. базовой деталью
						control.EOStatus = bdEOStatus;

						#endregion

						#region Пересчет общего статуса по всем директивам
						if (bdEOStatus == Statuses.NotActive && allEOStatus == Statuses.NotActive)
							allEOStatus = Statuses.NotActive;

						if (bdEOStatus == Statuses.Satisfactory &&
							allEOStatus != Statuses.Notify &&
							allEOStatus != Statuses.NotSatisfactory)
							allEOStatus = Statuses.Satisfactory;

						if (bdEOStatus == Statuses.Notify && allEOStatus != Statuses.NotSatisfactory)
							allEOStatus = Statuses.Notify;

						if (bdEOStatus == Statuses.NotSatisfactory)
							allEOStatus = Statuses.NotSatisfactory;
						#endregion
					}

					BeginInvoke(new Action<Statuses>(s => LinkEOStatus.Status = s), allEOStatus);

					#endregion

					#region проверка Modification Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(33, "Check Directives: Modification Status");

					Statuses modificationStatus = Statuses.NotActive;
					IEnumerable<Directive> mods =
						directives.Where(d => d.WorkType == DirectiveWorkType.Modification);
					foreach (Directive primaryDirective in mods)
					{
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
						if (directiveCond == ConditionState.NotEstimated && modificationStatus == Statuses.NotActive)
							modificationStatus = Statuses.NotActive;
						if (directiveCond == ConditionState.Satisfactory && modificationStatus != Statuses.Notify)
							modificationStatus = Statuses.Satisfactory;
						if (directiveCond == ConditionState.Notify)
							modificationStatus = Statuses.Notify;
						if (directiveCond == ConditionState.Overdue)
						{
							modificationStatus = Statuses.NotSatisfactory;
							break;
						}
					}
					BeginInvoke(new Action<Statuses>(s => LinkModifications.Status = s), modificationStatus);

					#endregion

					#region проверка Out of Phase Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(34, "Check Directives: Out of Phase Status");

					Statuses oopStatus = Statuses.NotActive;
					IEnumerable<Directive> oops = directives.Where(p => p.DirectiveType == DirectiveType.OutOfPhase);
					foreach (Directive primaryDirective in oops)
					{
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
						if (directiveCond == ConditionState.NotEstimated && oopStatus == Statuses.NotActive)
							oopStatus = Statuses.NotActive;
						if (directiveCond == ConditionState.Satisfactory && oopStatus != Statuses.Notify)
							oopStatus = Statuses.Satisfactory;
						if (directiveCond == ConditionState.Notify)
							oopStatus = Statuses.Notify;
						if (directiveCond == ConditionState.Overdue)
						{
							oopStatus = Statuses.NotSatisfactory;
							break;
						}
					}
					BeginInvoke(new Action<Statuses>(s => LinkOoPStatus.Status = s), oopStatus);

					#endregion

					#region проверка SB Status

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(36, "Check Directives: Service bulletins Status");

					Statuses allSBStatus = Statuses.NotActive;
					IEnumerable<IGrouping<BaseComponent, Directive>> groupSBs =
						directives.Where(p => p.DirectiveType == DirectiveType.SB || 
											  p.ServiceBulletinNo != "" || 
											  p.ServiceBulletinFile != null )
								  .GroupBy(d => d.ParentBaseComponent);
					foreach (IGrouping<BaseComponent, Directive> groupSB in groupSBs)
					{
						Statuses bdSBStatus = Statuses.NotActive;
						foreach (Directive primaryDirective in groupSB)
						{
							ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(primaryDirective);
							if (directiveCond == ConditionState.NotEstimated && bdSBStatus == Statuses.NotActive)
								bdSBStatus = Statuses.NotActive;
							if (directiveCond == ConditionState.Satisfactory && bdSBStatus != Statuses.Notify)
								bdSBStatus = Statuses.Satisfactory;
							if (directiveCond == ConditionState.Notify)
								bdSBStatus = Statuses.Notify;
							if (directiveCond == ConditionState.Overdue)
							{
								bdSBStatus = Statuses.NotSatisfactory;
								break;
							}
						}

						#region Пересчет общего статуса по базовой детали

						//Поиск кнокпи, отображающей тек. Базовую деталь
						BaseComponentControl control = _baseComponentButtons.GetByBaseDetail(groupSB.Key);
						//Если кнопки нет, переход на след. итерацию
						if (control == null) continue;
						//Присвоение расчитанного статуса кнопке с тек. базовой деталью
						control.SBStatus = bdSBStatus;

						#endregion

						#region Пересчет общего статуса по всем директивам
						if (bdSBStatus == Statuses.NotActive && allSBStatus == Statuses.NotActive)
							allSBStatus = Statuses.NotActive;

						if (bdSBStatus == Statuses.Satisfactory &&
							allSBStatus != Statuses.Notify &&
							allSBStatus != Statuses.NotSatisfactory)
							allSBStatus = Statuses.Satisfactory;

						if (bdSBStatus == Statuses.Notify && allSBStatus != Statuses.NotSatisfactory)
							allSBStatus = Statuses.Notify;

						if (bdSBStatus == Statuses.NotSatisfactory)
							allSBStatus = Statuses.NotSatisfactory;
						#endregion
					}
					BeginInvoke(new Action<Statuses>(s => LinkSBStatus.Status = s), allSBStatus);

					#endregion

					#region Проверка статуса контейнера директив

					List<Statuses> dirStatuses = new List<Statuses>(new[]{allADStatus, adStatusAF, adStatusAP,
																		  damageStatus, deferredStatus, allEOStatus, 
																		  modificationStatus, oopStatus, allSBStatus});
					Image directivesContainerImage = Properties.Resources.BlueArrow;
					foreach (Statuses dirStat in dirStatuses)
					{
						if (dirStat == Statuses.Satisfactory && directivesContainerImage != Properties.Resources.OrangeArrow)
							directivesContainerImage = Properties.Resources.GreenArrow;
						if (dirStat == Statuses.Notify)
							directivesContainerImage = Properties.Resources.OrangeArrow;
						if (dirStat == Statuses.NotSatisfactory)
						{
							directivesContainerImage = Properties.Resources.RedArrow;
							break;
						}
					}
					BeginInvoke(new Action<Image>(i => ContainerDirectives.UpperLeftIcon = i), directivesContainerImage);

					#endregion

					directives.Clear();
					deferreds.Clear();
					damages.Clear();
				}
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check directives status in " + CurrentAircraft.RegistrationNumber, exception);
			}    
		}
		#endregion

		#region private void GetGeneralInfoStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)

		private void GetGeneralInfoStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)
		{
			try
			{
				bgw.ReportProgress(38, "Check General Info");
				//извлечение и собрание всех компонентов самолета
				//(деталей и базовых деталей) в одну коллекцию
				var abds = new BaseComponentCollection(GlobalObjects.ComponentCore.GetAicraftBaseComponents(CurrentAircraft.ItemId));
				List<Document> docs = GlobalObjects.DocumentCore.GetAircraftDocuments(CurrentAircraft);

				if (abds.Count == 0 && docs.Count == 0)
				{
					BeginInvoke(new Action(() => LinkAircraftGeneralData.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkDocuments.Status = Statuses.Satisfactory));
					BeginInvoke(new Action(() => ContainerGD.UpperLeftIcon = Properties.Resources.BlueArrow));
				}
				else
				{
					#region проверка General Data

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(38, "Check General Info: General Data");

					Statuses gdStatus = Statuses.NotActive;

					foreach (BaseComponent bd in abds)
					{
						ConditionState directiveCond = GlobalObjects.PerformanceCalculator.GetConditionState(bd);
						if (directiveCond == ConditionState.NotEstimated && gdStatus == Statuses.NotActive)
							gdStatus = Statuses.NotActive;
						if (directiveCond == ConditionState.Satisfactory && gdStatus != Statuses.Notify)
							gdStatus = Statuses.Satisfactory;
						if (directiveCond == ConditionState.Notify)
							gdStatus = Statuses.Notify;
						if (directiveCond == ConditionState.Overdue)
						{
							gdStatus = Statuses.NotSatisfactory;
							break;
						}
					}
					BeginInvoke(new Action<Statuses>(s => LinkAircraftGeneralData.Status = s), gdStatus);

					#endregion

					#region проверка Documents

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(44, "Check General Info: Documents");

					Statuses docStatus = Statuses.NotActive;

					foreach (Document doc in docs)
					{
						GlobalObjects.PerformanceCalculator.GetNextPerformance(doc);
						if (doc.Condition == ConditionState.NotEstimated && docStatus == Statuses.NotActive)
							docStatus = Statuses.NotActive;
						if (doc.Condition == ConditionState.Satisfactory && docStatus != Statuses.Notify)
							docStatus = Statuses.Satisfactory;
						if (doc.Condition == ConditionState.Notify)
							docStatus = Statuses.Notify;
						if (doc.Condition == ConditionState.Overdue)
						{
							docStatus = Statuses.NotSatisfactory;
							break;
						}
					}
					BeginInvoke(new Action<Statuses>(s => LinkDocuments.Status = s), docStatus);

					#endregion

					#region Проверка статуса контейнера ТО

					List<Statuses> gdStatuses = new List<Statuses>(new[] { gdStatus, docStatus });
					Image gdContainerImage = Properties.Resources.BlueArrow;
					foreach (Statuses dirStat in gdStatuses)
					{
						if (dirStat == Statuses.Satisfactory && gdContainerImage != Properties.Resources.OrangeArrow)
							gdContainerImage = Properties.Resources.GreenArrow;
						if (dirStat == Statuses.Notify)
							gdContainerImage = Properties.Resources.OrangeArrow;
						if (dirStat == Statuses.NotSatisfactory)
						{
							gdContainerImage = Properties.Resources.RedArrow;
							break;
						}
					}
					BeginInvoke(new Action<Image>(s => ContainerGD.UpperLeftIcon = s), gdContainerImage);
					#endregion
				}
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check general info status", exception);
			}
		}
		#endregion

		#region private void GetMaintenanceStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)

		private void GetMaintenanceStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)
		{
			try
			{
				bgw.ReportProgress(50, "Check Maintenance");
				//извлечение и собрание всех компонентов самолета
				//(деталей и базовых деталей) в одну коллекцию
				MaintenanceCheckCollection maintenanceChecks = 
					new MaintenanceCheckCollection(GlobalObjects.MaintenanceCore.GetMaintenanceCheck(CurrentAircraft));
				List<MaintenanceDirective> mds =
					GlobalObjects.MaintenanceCore.GetMaintenanceDirectives(CurrentAircraft);
				if (maintenanceChecks.Count == 0 && mds.Count == 0)
				{
					BeginInvoke(new Action(() => LinkMaintenanceProgram.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkMaintenanceTasks.Status = Statuses.NotActive));
					BeginInvoke(new Action(() => LinkNonRoutineJobsCategories.Status = Statuses.Satisfactory));
					BeginInvoke(new Action(() => LinkNonRoutineJobs.Status = Statuses.Satisfactory));
					BeginInvoke(new Action(() => ContainerComponents.UpperLeftIcon = Properties.Resources.BlueArrow));
				}
				else
				{
					#region проверка Maintenance Checks

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(50, "Check Maintenance: Maintenance Checks");

					GlobalObjects.MaintenanceCheckCalculator.GetNextPerformanceGroup(maintenanceChecks, CurrentAircraft.Schedule);

					Statuses mpStatus = Statuses.NotActive;

					foreach (MaintenanceCheck check in maintenanceChecks.Where(c => c.Schedule == CurrentAircraft.Schedule))
					{
						//List<MaintenanceCheck> gr;
						//GlobalObjects.CasEnvironment.Calculator
						//    .GetNextPerformance(maintenanceChecks
						//                            .Where(c => c.Schedule == CurrentAircraft.Schedule)
						//                            .ToList(), maintenanceChecks, check, CurrentAircraft, out gr);

						if (check.Condition == ConditionState.Satisfactory && mpStatus != Statuses.Notify) mpStatus = Statuses.Satisfactory;
						if (check.Condition == ConditionState.Notify) mpStatus = Statuses.Notify;
						if (check.Condition == ConditionState.Overdue)
						{
							mpStatus = Statuses.NotSatisfactory;
							break;
						}
					}

					BeginInvoke(new Action<Statuses>(s => LinkMaintenanceProgram.Status = s), mpStatus);

					#endregion

					#region проверка Maintenance Directives

					if (bgw.CancellationPending)
					{
						e.Cancel = true;
						return;
					}

					bgw.ReportProgress(53, "Check Maintenance: Maintenance Tasks");

					Statuses mpdStatus = Statuses.NotActive;
					Statuses cpcpStatus = Statuses.NotActive;
					foreach (MaintenanceDirective directive in mds)
					{
						GlobalObjects.PerformanceCalculator.GetNextPerformance(directive);

						if (directive.Condition == ConditionState.Satisfactory && mpdStatus != Statuses.Notify) 
							mpdStatus = Statuses.Satisfactory;
						if (directive.Condition == ConditionState.Notify) 
							mpdStatus = Statuses.Notify;
						if (directive.Condition == ConditionState.Overdue)
						{
							mpdStatus = Statuses.NotSatisfactory;
						}

						if (directive.Program != MaintenanceDirectiveProgramType.CPCP)
							continue;

						if (directive.Condition == ConditionState.Satisfactory && cpcpStatus != Statuses.Notify)
							cpcpStatus = Statuses.Satisfactory;
						if (directive.Condition == ConditionState.Notify)
							cpcpStatus = Statuses.Notify;
						if (directive.Condition == ConditionState.Overdue)
						{
							cpcpStatus = Statuses.NotSatisfactory;
						}

						if(cpcpStatus == Statuses.NotSatisfactory || mpdStatus == Statuses.NotSatisfactory)
							break;
					}

					BeginInvoke(new Action<Statuses>(s => LinkMaintenanceTasks.Status = s), mpdStatus);
					BeginInvoke(new Action<Statuses>(s => LinkCPCPStatus.Status = s), cpcpStatus);

					#endregion

					#region Проверка статуса контейнера ТО

					List<Statuses> compStatuses = new List<Statuses>(new[]{mpStatus, mpdStatus});
					Image mpContainerImage = Properties.Resources.BlueArrow;
					foreach (Statuses dirStat in compStatuses)
					{
						if (dirStat == Statuses.Satisfactory && mpContainerImage != Properties.Resources.OrangeArrow)
							mpContainerImage = Properties.Resources.GreenArrow;
						if (dirStat == Statuses.Notify)
							mpContainerImage = Properties.Resources.OrangeArrow;
						if (dirStat == Statuses.NotSatisfactory)
						{
							mpContainerImage = Properties.Resources.RedArrow;
							break;
						}
					}
					BeginInvoke(new Action<Image>(s => ContainerMP.UpperLeftIcon = s), mpContainerImage);
					#endregion
				}
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check maintenance status", exception);
			}   
		}
		#endregion

		#region private void GetPlanningStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)

		private void GetPlanningStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)
		{
			try
			{
				bgw.ReportProgress(63, "Check Planning");

				BeginInvoke(new Action<Statuses>(s => LinkWorkPackages.Status = s), Statuses.Satisfactory);
				BeginInvoke(new Action<Image>(s => ContainerPlanning.UpperLeftIcon = s), Properties.Resources.GreenArrow);

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				Thread.Sleep(500); 
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check planning status", exception);
			}
		}
		#endregion

		#region private void GetPurchaseStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)

		private void GetPurchaseStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)
		{
			try
			{
				bgw.ReportProgress(75, "Check Purchase");

				BeginInvoke(new Action<Image>(s => ContainerPurchase.UpperLeftIcon = s), Properties.Resources.GreenArrow);

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				Thread.Sleep(500);
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check purchase status", exception);
			}
		}
		#endregion

		#region private void GetSmsStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)

		private void GetSmsStatus(AnimatedThreadWorker bgw, DoWorkEventArgs e)
		{
			try
			{
				bgw.ReportProgress(88, "Check SMS");

				BeginInvoke(new Action<Image>(s => ContainerSMS.UpperLeftIcon = s), Properties.Resources.GreenArrow);

				if (AnimatedThreadWorker.CancellationPending)
				{
					e.Cancel = true;
					return;
				}

				Thread.Sleep(500);
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while check SMS status", exception);
			}
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			if(!AnimatedThreadWorker.IsBusy)
				AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void LinkADStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkADStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + "AD Status";
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.AirworthenessDirectives);
		}
		#endregion

		#region private void LinkADStatusAFDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkADStatusAFDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + DirectiveType.AirworthenessDirectives.CommonName;
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.AirworthenessDirectives, ADType.Airframe);
		}
		#endregion

		#region private void LinkADStatusAPDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkADStatusAPDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + DirectiveType.AirworthenessDirectives.CommonName;
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.AirworthenessDirectives, ADType.Appliance);
		}
		#endregion

		#region private void LinkAircraftGeneralDataDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkAircraftGeneralDataDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Aircraft General Data";
			e.RequestedEntity = new AircraftGeneralDataScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkAircraftSummaryDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkAircraftSummaryDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Aircraft Summary";
			e.RequestedEntity = new AircraftSummaryScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkAtlBsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkAtlBsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". List of Aircraft Technical Log Books";
			e.RequestedEntity = new ATLBListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkRegisterFlightDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkRegisterFlightDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". New Flight";
			e.RequestedEntity = new FlightScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkRegisterFlightDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkRegisterFlightLightDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". New Flight";
			e.RequestedEntity = new FlightScreenLight(CurrentAircraft);
		}
		#endregion

		#region private void LinkAverageUtilizationDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkAverageUtilizationDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			AverageUtilizationForm form = new AverageUtilizationForm(CurrentAircraft);
			form.ShowDialog();
			e.Cancel = true;
		}
		#endregion

		#region private void LinkAvionxInventoryDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkAvionxInventoryDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			CommonFilter<AvionicsInventoryMarkType> avionixFilter = 
				new CommonFilter<AvionicsInventoryMarkType>(Component.AvionicsInventoryProperty,
					SmartCore.Filters.FilterType.In, 
															new[]{AvionicsInventoryMarkType.Optional, 
																  AvionicsInventoryMarkType.Required, 
																  AvionicsInventoryMarkType.Unknown});
			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Avionics inventory";
			e.RequestedEntity = new ComponentsListScreen(CurrentAircraft, new ICommonFilter[]{avionixFilter});
		}
		#endregion

		#region private void LinkComponentChangeReportDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkComponentChangeReportDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + " Component Tracking";
			e.RequestedEntity = new ComponentTrackingListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkComponentChangeReport_DisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkComponentChangeReport_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + " Component Change Report";
			e.RequestedEntity = new ComponentChangeReport.ComponentChangeReport(CurrentAircraft);
		}

		#endregion

		#region private void LinkComponentStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkComponentStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Component Status";
			e.RequestedEntity = new ComponentsListScreen(CurrentAircraft, MaintenanceControlProcess.Items.ToArray(), BaseComponentType.Items.ToArray());
		}
		#endregion

		#region  private void LinkComponentStatusHtDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkComponentStatusHtDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Component Status";
			e.RequestedEntity = new ComponentsListScreen(CurrentAircraft, new[] { MaintenanceControlProcess.HT }, BaseComponentType.Items.ToArray());
		}
		#endregion

		#region private void LinkComponentStatusOCCMDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkComponentStatusOCCMDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Component Status";
			e.RequestedEntity = new ComponentsListScreen(CurrentAircraft, new[] { MaintenanceControlProcess.OC, MaintenanceControlProcess.CM }, BaseComponentType.Items.ToArray());
		}
		#endregion

		#region private void LinkCPCPStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkCPCPStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			ICommonFilter<MaintenanceDirectiveProgramType> filter = 
				new CommonFilter<MaintenanceDirectiveProgramType>(MaintenanceDirective.ProgramProperty, MaintenanceDirectiveProgramType.CPCP);
			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + MaintenanceDirectiveProgramType.CPCP.CommonName;
			e.RequestedEntity = new MaintenanceDirectiveListScreen(CurrentAircraft, new ICommonFilter[] { filter });
		}
		#endregion

		#region private void LinkDamageChartsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkDamageChartsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			DamageChartsForm form = new DamageChartsForm(CurrentAircraft);
			form.ShowDialog();
			e.Cancel = true;
		}
		#endregion

		#region private void LinkDamagesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkDamagesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + DirectiveType.DamagesRequiring.CommonName;
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.DamagesRequiring);
		}
		#endregion

		#region private void LinkDeferredCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkDeferredCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			DeferredCategoriesForm form = new DeferredCategoriesForm(CurrentAircraft);
			form.ShowDialog();
			e.Cancel = true;
		}
		#endregion

		#region private void LinkDeferredItemsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkDeferredItemsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + DirectiveType.DeferredItems.CommonName;
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.DeferredItems);
		}
		#endregion

		#region private void LinkDiscrepanciesStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkDiscrepanciesStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Discrepancies";
			e.RequestedEntity = new DiscrepanciesListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkDocumentsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkDocumentsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Documents";
			e.RequestedEntity = new DocumentationListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkEOStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkEOStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + DirectiveType.EngineeringOrders.CommonName;
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.EngineeringOrders);
		}
		#endregion


		private void LinkForecastMTOPDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);

			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				if (MessageBox.Show("Average Utilization for aircraft " + CurrentAircraft.RegistrationNumber + " is not set. Do you want to set it?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
				{
					AverageUtilizationForm form = new AverageUtilizationForm(CurrentAircraft);
					form.ShowDialog();
				}
			}

			averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);
			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				e.Cancel = true;
				return;
			}

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ".MTOP Forecast";
			//e.RequestedEntity = new ForecastMTOPListScreen(CurrentAircraft);
			e.RequestedEntity = new ForecastListScreenMtopNew(CurrentAircraft, DirectiveType.All);
		}

		private void LinkForecastMTOPOldDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			CancelAsync();

			var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);

			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				if (MessageBox.Show("Average Utilization for aircraft " + CurrentAircraft.RegistrationNumber + " is not set. Do you want to set it?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
				{
					AverageUtilizationForm form = new AverageUtilizationForm(CurrentAircraft);
					form.ShowDialog();
				}
			}

			averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);
			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				e.Cancel = true;
				return;
			}

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ".MTOP Forecast";
			//e.RequestedEntity = new ForecastMTOPListScreen(CurrentAircraft);
			e.RequestedEntity = new ForecastListScreenMtopOld(CurrentAircraft, DirectiveType.All);
		}

		#region private void LinkForecastDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkForecastDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);

			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				if (MessageBox.Show("Average Utilization for aircraft " + CurrentAircraft.RegistrationNumber + " is not set. Do you want to set it?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
				{
					AverageUtilizationForm form = new AverageUtilizationForm(CurrentAircraft);
					form.ShowDialog();
				}
			}

			averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);
			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				e.Cancel = true;
				return;
			}
			e.DisplayerText = CurrentAircraft.RegistrationNumber + ".Forecast";
			e.RequestedEntity = new ForecastListScreen(CurrentAircraft, DirectiveType.All);
		}
		#endregion

		#region private void LinkForecastKitsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkForecastKitsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);

			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				if (MessageBox.Show("Average Utilization for aircraft " + CurrentAircraft.RegistrationNumber + " is not set. Do you want to set it?", "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
				{
					AverageUtilizationForm form = new AverageUtilizationForm(CurrentAircraft);
					form.ShowDialog();
				}
			}

			averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(CurrentAircraft);
			if (averageUtilization == null || averageUtilization.CyclesPerMonth == 0 || averageUtilization.HoursPerMonth == 0)
			{
				e.Cancel = true;
				return;
			}
			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Kits Forecast";
			var screen = new ForecastKitsListScreen(CurrentAircraft);
			e.RequestedEntity = screen;
		}
		#endregion

		#region private void LinkLandingGearStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkLandingGearStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Landing Gear Status";
			e.RequestedEntity = new ComponentsListScreen(CurrentAircraft, MaintenanceControlProcess.Items.ToArray(), new[] { BaseComponentType.LandingGear });
		}
		#endregion

		#region private void LinkLLPCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		
		private void LinkLLPCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			if (CurrentAircraft.Model.ItemId == AircraftModel.Unknown.ItemId)
			{
				MessageBox.Show("Please select Aircraft model. For this go to Aircraft General Data and set model in \"Aircraft\" section.",
					(string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (CurrentAircraft.Model.IsDeleted)
			{
				MessageBox.Show("Aircraft model was deleted. Please change Aircraft model. For this go to Aircraft General Data and set model in \"Aircraft\" section.",
					(string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				var form = new LLPLifeLimitCategoriesForm(CurrentAircraft);
				form.ShowDialog();
			}

			e.Cancel = true;
		}
		#endregion

		#region private void LinkMaintenanceProgramDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkMaintenanceProgramDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Maintenance Program";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new MaintenanceScreen(CurrentAircraft);
		}
		#endregion

		private void LinkLinkMTOPDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". MTOP";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new MTOPScreen(CurrentAircraft);
		}

		private void LinkLinkLDNDDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". LDND";
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;
			e.RequestedEntity = new LDNDListScreen(CurrentAircraft);
		}

		#region private void LinkMaintenanceProgramDirectivesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkMaintenanceProgramDirectivesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". MPD";
			MaintenanceDirectiveListScreen maintenanceScreen = new MaintenanceDirectiveListScreen(CurrentAircraft);
			e.TypeOfReflection = ReflectionTypes.DisplayInNew;

			e.RequestedEntity = maintenanceScreen;
		}
		#endregion

		#region private void LinkModificationsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkModificationsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". List of Modifications Performed";
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.ModificationStatus);
		}
		#endregion

		#region private void LinkMonthlyUtilizationDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkMonthlyUtilizationDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Monthly Utilization";
			e.RequestedEntity = new MonthlyUtilizationListScreen(CurrentAircraft);
		}
		#endregion

		private void LinkOilDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Oil Statistics";
			e.RequestedEntity = new OilListScreen(CurrentAircraft);
		}

		#region private void LinkNonRoutineJobsCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkNonRoutineJobsCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Non-Routine Jobs Categories";
			NonRoutineJobCategoriesListScreen screen = new NonRoutineJobCategoriesListScreen(CurrentAircraft);
			e.RequestedEntity = screen;
		}
		#endregion

		#region private void LinkNonRoutineJobsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkNonRoutineJobsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". Non-Routine Jobs";
			var screen = new NonRoutineJobsStatusListScreen(CurrentAircraft);
			e.RequestedEntity = screen;
		}
		#endregion

		#region private void LinkOoPStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkOoPStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + DirectiveType.OutOfPhase.CommonName;
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.OutOfPhase);
		}
		#endregion

		#region private void LinkEquipmentAndMaterialsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkEquipmentAndMaterialsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ".Equipment and Materials";
			e.RequestedEntity = new AccessoryRequiredListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkInitialOrdersDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkInitialOrdersDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ".Initial Orders";
			e.RequestedEntity = new InitialOrderListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkPurchaseOrdersDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkPurchaseOrdersDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = "Purchase Orders";
			e.RequestedEntity = new PurchaseOrderListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkQuotationOrdersDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkQuotationOrdersDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = "Request For Quotation";
			e.RequestedEntity = new RequestForQuotationListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkSBStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkSBStatusDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + "Service Bulletin";
			e.RequestedEntity = new PrimeDirectiveListScreen(CurrentAircraft, DirectiveType.SB);
		}
		#endregion

		#region private void LinkSmsEventsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		private void LinkSmsEventsDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". " + "Events";
			e.RequestedEntity = new EventsListScreen(CurrentAircraft, Event.EventStatusProperty);
		}
		#endregion

		#region private void LinkSmsEventsCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkSmsEventsCategoriesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = "Events Categories";
			e.RequestedEntity = new CommonListScreen(typeof(EventCategory));
		}
		#endregion

		#region private void LinkSmsEventsClassesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkSmsEventsClassesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = "Events Classes";
			e.RequestedEntity = new CommonListScreen(typeof(EventClass));
		}
		#endregion

		#region private void LinkSmsEventsTypesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkSmsEventsTypesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = "Events Types";
			e.RequestedEntity = new EventTypesListScreen(CurrentAircraft);
		}
		#endregion

		#region private void LinkWorkPackagesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)

		private void LinkWorkPackagesDisplayerRequested(object sender, Interfaces.ReferenceEventArgs e)
		{
			CancelAsync();

			e.DisplayerText = CurrentAircraft.RegistrationNumber + ". List of WP";
			e.RequestedEntity = new WorkPackageListScreen(CurrentAircraft);
		}
		#endregion

		private void AllATLB_DisplayerRequested(object sender, ReferenceEventArgs e)
		{
			e.DisplayerText = "ATLB Event";
			e.RequestedEntity = new AllATLBListScreen(CurrentAircraft);
		}
		
	}
}
