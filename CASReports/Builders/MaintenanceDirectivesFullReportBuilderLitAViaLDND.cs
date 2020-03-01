using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Auxiliary;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Filters;

namespace CASReports.Builders
{
	public class MaintenanceDirectivesFullReportBuilderLitAViaLDND : AbstractReportBuilder
	{
		private readonly bool _mpLimit;

		#region Fields

		private string _reportTitle = "AMP TASKS STATUS";
		private string _filterSelection;
		private byte[] _operatorLogotype;
		private Aircraft _reportedAircraft;
		private BaseComponent _reportedBaseComponent;
		private List<NextPerformance> _reportedDirectives = new List<NextPerformance>();

		private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
		private Forecast _forecast;
		private string _dateAsOf = "";
		private Lifelength _lifelengthAircraftSinceNew;
		private Lifelength _lifelengthAircraftSinceOverhaul;
		private Lifelength _current;
		private DateTime _manufactureDate;
		private Lifelength reportAircraftLifeLenght;

		#endregion

		#region Properties

		#region public Aircraft ReportedAircraft

		/// <summary>
		/// ВС включаемыое в отчет
		/// </summary>
		public Aircraft ReportedAircraft
		{
			set
			{
				_reportedAircraft = value;
				if (value == null) return;
				_reportedBaseComponent = GlobalObjects.ComponentCore.GetBaseComponentById(value.AircraftFrameId);
				_manufactureDate = value.ManufactureDate;
				_current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
				_operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;
			}
		}

		#endregion

		#region public BaseDetail ReportedBaseDetail

		/// <summary>
		/// Базовый агрегат, включаемый в отчет
		/// </summary>
		public BaseComponent ReportedBaseComponent
		{
			set
			{
				if (value == null) return;
				_reportedBaseComponent = value;
				_manufactureDate = _reportedBaseComponent.ManufactureDate;
				_current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
				_operatorLogotype = GlobalObjects.CasEnvironment.Operators[0].LogotypeReportLarge;
				_reportedDirectives.Clear();
				//  reportedDirectives.AddRange(GlobalObjects.CasEnvironment.Loader.GetDefferedItems(reportedBaseDetail));
			}
		}

		#endregion

		#region public List<NextPerformance> ReportedDirectives

		/// <summary>
		/// Директивы включаемые в отчет
		/// </summary>
		public List<NextPerformance> ReportedDirectives
		{
			get
			{
				return _reportedDirectives;
			}
			set
			{
				_reportedDirectives = value;
			}
		}

		#endregion

		#region public string DateAsOf

		/// <summary>
		/// Текст поля DateAsOf
		/// </summary>
		public string DateAsOf
		{
			get { return _dateAsOf; }
			set { _dateAsOf = value; }
		}

		#endregion

		#region public string ReportTitle

		/// <summary>
		/// Текст заголовка отчета
		/// </summary>
		public string ReportTitle
		{
			get { return _reportTitle; }
			set { _reportTitle = value; }
		}

		#endregion

		#region public Forecast Forecast

		public Forecast Forecast
		{
			set { _forecast = value; }
		}
		#endregion

		#region protected Lifelength Current

		protected Lifelength Current
		{
			get { return _current; }
		}
		#endregion

		#region public CommonFilterCollection ReportTitle

		/// <summary>
		/// Текст фильтра отчета
		/// </summary>
		public CommonFilterCollection FilterSelection
		{
			set { GetFilterSelection(value); }
		}

		#endregion

		#region public LifelengthFormatter LifelengthFormatter

		/// <summary>
		/// Формировщик вывода информации о наработке
		/// </summary>
		public LifelengthFormatter LifelengthFormatter
		{
			get { return _lifelengthFormatter; }
		}

		#endregion

		#region public Image OperatorLogotype

		/// <summary>
		/// Возвращает или устанавливает логтип эксплуатанта
		/// </summary>
		public byte[] OperatorLogotype
		{
			set
			{
				_operatorLogotype = value;
			}
		}

		#endregion

		#region public Lifelength LifelengthAircraftSinceNew

		/// <summary>
		/// Наработка ВС SinceNew
		/// </summary>
		public Lifelength LifelengthAircraftSinceNew
		{
			get { return _lifelengthAircraftSinceNew; }
			set { _lifelengthAircraftSinceNew = value; }
		}

		#endregion

		#region public Lifelength LifelengthAircraftSinceOverhaul

		/// <summary>
		/// Наработка ВС SinceOverhaul
		/// </summary>
		public Lifelength LifelengthAircraftSinceOverhaul
		{
			get { return _lifelengthAircraftSinceOverhaul; }
			set { _lifelengthAircraftSinceOverhaul = value; }
		}

		#endregion

		#endregion

		public MaintenanceDirectivesFullReportBuilderLitAViaLDND(bool mpLimit = false)
		{
			_mpLimit = mpLimit;
		}

		#region Methods

		#region protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
		protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
		{
			if (_reportedAircraft != null)
			{
				_filterSelection = "All";
				if (filterCollection == null || filterCollection.IsEmpty) 
					return;
				_filterSelection = filterCollection.ToString();
			}
			else
			{
				if (_reportedBaseComponent != null)
				{
					_filterSelection = "All";
					if (filterCollection == null) return;
					if (_reportedBaseComponent.BaseComponentType == BaseComponentType.LandingGear)
						_filterSelection = _reportedBaseComponent.TransferRecords.GetLast().Position;
					if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Engine)
						_filterSelection = BaseComponentType.Engine + " " + _reportedBaseComponent.TransferRecords.GetLast().Position;
					if (_reportedBaseComponent.BaseComponentType == BaseComponentType.Apu)
						_filterSelection = BaseComponentType.Apu.ToString();
				}
				else
				{
					_filterSelection = "All";
				}
			}

		}
		#endregion

		#region public void AddDirectives(IEnumerable<NextPerformance> directives)

		public void AddDirectives(IEnumerable<NextPerformance> directives)
		{
			_reportedDirectives.Clear();
			_reportedDirectives.AddRange(directives);
			if (_reportedDirectives.Count == 0)
				return;

		}

		#endregion

		#region public override object GenerateReport()

		/// <summary>
		/// Сгенерировать отчет по данным, добавленным в текущий объект
		/// </summary>
		/// <returns>Построенный отчет</returns>
		public override object GenerateReport()
		{
			var report = new MaintenanceDirectiveReportLitAviaLDND();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region protected virtual DataSet GenerateDataSet()

		/// <summary>
		/// Построить источник данных (DataSet) для вывода в отчет
		/// </summary>
		/// <returns></returns>
		protected virtual DataSet GenerateDataSet()
		{
			var dataset = new MaintenanceDirectivesDataSetLatAvia();
			AddAircraftToDataset(dataset);
			AddDirectivesToDataSet(dataset);
			AddAdditionalDataToDataSet(dataset);
			return dataset;
		}

		#endregion

		#region protected virtual void AddDirectivesToDataSet(MaintenanceDirectivesDataSet dataset)

		/// <summary>
		/// Добавление директив в таблицу данных
		/// </summary>
		/// <param name="dataset">Таблица, в которую добавляются данные</param>
		protected virtual void AddDirectivesToDataSet(MaintenanceDirectivesDataSetLatAvia dataset)
		{
			/* List<String> colors = new List<string>();
			for (int i = 0; i < HighlightCollection.Instance.Count; i++ )
			{
				colors.Add(HighlightCollection.Instance[i].Color.R.ToString()+" "+
							HighlightCollection.Instance[i].Color.G.ToString()+" "+
							HighlightCollection.Instance[i].Color.B.ToString());
			}
			MessageBox.Show(string.Join("\r\n",colors.ToArray()));*/
			foreach (NextPerformance t in _reportedDirectives)
			{
				AddDirectiveToDataset(t, dataset);
			}
		}

		#endregion

		#region private void AddAircraftToDataset(MaintenanceDirectivesDataSet destinationDataSet)

		/// <summary>
		/// Добавляется элемент в таблицу данных
		/// </summary>
		/// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
		private void AddAircraftToDataset(MaintenanceDirectivesDataSetLatAvia destinationDataSet)
		{
			if (_reportedAircraft == null)
				return;

			reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

			var apu = GlobalObjects.ComponentCore.GetAicraftBaseComponents(_reportedAircraft.ItemId)
				.FirstOrDefault(i => i.BaseComponentType == BaseComponentType.Apu);

			var reportApuLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(apu);

			var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
			var serialNumber = _reportedAircraft.SerialNumber;
			var model = _reportedAircraft.Model.FullName;
			var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
			var registrationNumber = _reportedAircraft.RegistrationNumber;
			int averageUtilizationHours;
			int averageUtilizationCycles;
			string averageUtilizationType;
			if (_forecast == null)
			{
				var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId);
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);

				averageUtilizationHours = (int)averageUtilization.Hours;
				averageUtilizationCycles = (int)averageUtilization.Cycles;
				averageUtilizationType = averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
			}
			else
			{
				averageUtilizationHours = (int)_forecast.ForecastDatas[0].AverageUtilization.Hours;
				averageUtilizationCycles = (int)_forecast.ForecastDatas[0].AverageUtilization.Cycles;
				averageUtilizationType =
				   _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

			}

			string lineNumber = _reportedAircraft.LineNumber;
			string variableNumber = _reportedAircraft.VariableNumber;
			destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(serialNumber,
																		 manufactureDate,
																		 reportAircraftLifeLenght.ToHoursMinutesFormat(""),
																		 sinceNewCycles,
																		 registrationNumber, model, lineNumber, variableNumber,
																		 averageUtilizationHours, averageUtilizationCycles, averageUtilizationType, reportApuLifeLenght.Hours.ToString(), reportApuLifeLenght.Cycles.ToString());
		}

		#endregion

		#region protected virtual void AddDirectiveToDataset(object directive, DefferedListDataSet destinationDataSet)

		/// <summary>
		/// Добавляется элемент в таблицу данных
		/// </summary>
		/// <param name="reportedDirective">Добавлямая директива</param>
		/// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
		protected virtual void AddDirectiveToDataset(NextPerformance reportedDirective, MaintenanceDirectivesDataSetLatAvia destinationDataSet)
		{
			if(reportedDirective == null)
				return;

			string status = "";
			Lifelength remain = Lifelength.Null;
			Lifelength used = Lifelength.Null;

			//string remarks = reportedDirective.LastPerformance != null ? reportedDirective.LastPerformance.Remarks : reportedDirective.Remarks;
			if (reportedDirective.Status == DirectiveStatus.Closed) status = "C";
			if (reportedDirective.Status == DirectiveStatus.Open) status = "O";
			if (reportedDirective.Status == DirectiveStatus.Repetative) status = "R";
			if (reportedDirective.Status == DirectiveStatus.NotApplicable) status = "N/A";

			string effectivityDate = UsefulMethods.NormalizeDate(reportedDirective.Parent.Threshold.EffectiveDate);
			string kits = "";
			int num = 1;
			foreach (AccessoryRequired kit in reportedDirective.Kits)
			{
				kits += num + ": " + kit.PartNumber + "\n";
				num++;
			}

			//расчет остатка с даты производства и с эффективной даты
			//расчет остатка от выполнения с даты производтсва
			string firstPerformanceString =
				reportedDirective.Parent.Threshold.FirstPerformanceSinceNew.ToString();

			if (reportedDirective.Parent.LastPerformance != null)
			{
				used.Add(_current);
				used.Substract(reportedDirective.Parent.LastPerformance.OnLifelength);
				if(!reportedDirective.Parent.Threshold.RepeatInterval.IsNullOrZero())
					used.Resemble(reportedDirective.Parent.Threshold.RepeatInterval);
				else if (!reportedDirective.Parent.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
					used.Resemble(reportedDirective.Parent.Threshold.FirstPerformanceSinceNew);

				if (reportedDirective.NextPerformanceSource != null && !reportedDirective.NextPerformanceSource.IsNullOrZero())
				{
					remain.Add(reportedDirective.NextPerformanceSource);
					remain.Substract(_current);
					remain.Resemble(reportedDirective.Parent.Threshold.RepeatInterval);
				}
			}


			var remainCalc = Lifelength.Zero;
			NextPerformance next = reportedDirective.Parent.NextPerformance;

			try
			{
				if (_mpLimit)
				{
					if (reportedDirective.Parent.LastPerformance != null)
					{
						if (!reportedDirective.Parent.Threshold.RepeatInterval.IsNullOrZero() && !reportedDirective.Parent.IsClosed)
						{
							next = reportedDirective.Parent.NextPerformance;

							next.PerformanceSource = Lifelength.Zero;
							next.PerformanceSource.Add(reportedDirective.Parent.LastPerformance.OnLifelength);
							next.PerformanceSource.Add(reportedDirective.Parent.Threshold.RepeatInterval);
							next.PerformanceSource.Resemble(reportedDirective.Parent.Threshold.RepeatInterval);

							if (reportedDirective.Parent.Threshold.RepeatInterval.Days.HasValue)
								next.PerformanceDate =
									reportedDirective.Parent.LastPerformance.RecordDate.AddDays(reportedDirective.Parent.Threshold
										.RepeatInterval.Days.Value);
							else next.PerformanceDate = null;

							remainCalc.Add(next.PerformanceSource);
							remainCalc.Substract(_current);
							remainCalc.Resemble(reportedDirective.Parent.Threshold.RepeatInterval);

							if (next.PerformanceDate != null)
								remainCalc.Days = DateTimeExtend.DifferenceDateTime(DateTime.Today, next.PerformanceDate.Value).Days;
						   
						}
					}
					else if(reportedDirective.NextPerformanceSource != null && !reportedDirective.NextPerformanceSource.IsNullOrZero())
					{
						if (!reportedDirective.Parent.Threshold.RepeatInterval.IsNullOrZero())
						{
							remainCalc.Add(reportedDirective.NextPerformanceSource);
							remainCalc.Substract(_current);
							remainCalc.Resemble(reportedDirective.Parent.Threshold.RepeatInterval);
						}
					}

				}
				else
				{
					remainCalc = reportedDirective.Remains;
					next = reportedDirective.Parent.NextPerformance;
				}

				var title = "";
				var card = "";
				var description = "";

				if (reportedDirective.Parent is MaintenanceDirective mpd)
				{
					title = mpd.Title;
					card = mpd.TaskCardNumber;
					description = mpd.Description;
				}
				else if (reportedDirective.Parent is Directive d)
				{
					if (d.DirectiveType == DirectiveType.AirworthenessDirectives)
						title = d.Title;
					else if (d.DirectiveType == DirectiveType.SB)
						title = d.ServiceBulletinNo;
					else if (d.DirectiveType == DirectiveType.EngineeringOrders)
						title = d.EngineeringOrders;
					card = d.EngineeringOrders;
					description = d.Description;
				}
				else if (reportedDirective.Parent is ComponentDirective c)
				{
					description = c.ParentComponent.ToString();
					title = c.MaintenanceDirective?.TaskNumberCheck ?? "";
					card = c.MaintenanceDirective?.TaskCardNumber ?? "";
				}
				destinationDataSet.ItemsTable.AddItemsTableRow(title, card, description,
					firstPerformanceString,
					reportedDirective.Parent.Threshold.RepeatInterval != null ? reportedDirective.Parent.Threshold.RepeatInterval.Hours?.ToString() : "*",
					reportedDirective.Parent.Threshold.RepeatInterval != null ? reportedDirective.Parent.Threshold.RepeatInterval.Cycles?.ToString() : "*",
					reportedDirective.Parent.Threshold.RepeatInterval != null ? reportedDirective.Parent.Threshold.RepeatInterval.Days?.ToString() : "*",
					reportedDirective.Parent.LastPerformance != null ? reportedDirective.Parent.LastPerformance.OnLifelength.Hours?.ToString() : "*",
					reportedDirective.Parent.LastPerformance != null ? reportedDirective.Parent.LastPerformance.OnLifelength.Cycles?.ToString() : "*",
					reportedDirective.Parent.LastPerformance != null ? reportedDirective.Parent.LastPerformance.RecordDate.Date.ToString("dd.MM.yyyy") : "*",
					next != null ? next.PerformanceSource.Hours.ToString() : "*",
					next != null ? next.PerformanceSource.Cycles.ToString() : "*",
					next?.PerformanceDate != null  ? next.PerformanceDate.Value.ToString("dd.MM.yyyy") : "*" ,
					remainCalc != null ? remainCalc.Hours.ToString() : "*",
					remainCalc != null ? remainCalc.Cycles.ToString() : "*",
					remainCalc != null ? remainCalc.Days.ToString() : "*", "", ""
				);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}

		#endregion

		#region private void AddAdditionalDataToDataSet(MaintenanceDirectivesDataSet destinationDateSet)

		/// <summary>
		/// Добавление дополнительной информации 
		/// </summary>
		/// <param name="destinationDateSet"></param>
		private void AddAdditionalDataToDataSet(MaintenanceDirectivesDataSetLatAvia destinationDateSet)
		{
			string firsttitle = "MPD Item";
			string discriptiontitle = "Description";
			string secondtitle = "Task Card №";

			string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
			string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
			destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, firsttitle, secondtitle, discriptiontitle, reportFooter, reportFooterPrepared, reportFooterLink);

		}

		#endregion

		#endregion

	}
}