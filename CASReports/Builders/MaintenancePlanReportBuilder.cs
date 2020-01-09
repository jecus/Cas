using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
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
using SmartCore.Filters;
using Convert = System.Convert;

namespace CASReports.Builders
{
    public class MaintenancePlanReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private string _reportTitle = "MAINTENANCE PLAN";
        private string _filterSelection;
        private byte[] _operatorLogotype;
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private WorkPackage _workPackage;
        private Operator _reportedOperator;
        private IEnumerable<BaseEntityObject> _reportedDirectives;

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Forecast _forecast;
        private string _dateAsOf = "";
        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;

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
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;
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

        #region public CommonFilterCollection FilterSelection

        /// <summary>
        /// фильтры отчета
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

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// Рабочий пакет по которому строится workscope
        /// </summary>
        public WorkPackage WorkPackage
        {
            set
            {
                _workPackage = value;
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

        #region public MaintenancePlanReportBuilder(Operator @operator, IEnumerable<BaseEntityObject> performances)

        public MaintenancePlanReportBuilder(Operator @operator, IEnumerable<BaseEntityObject> performances)
        {
            _reportedOperator = @operator;

            if (_reportedOperator != null)
                _operatorLogotype = _reportedOperator.LogotypeReportLarge;

            _reportedDirectives = performances;
        }
        #endregion

        #region public MaintenancePlanReportBuilder(Operator @operator, IEnumerable<BaseEntityObject> performances)

        public MaintenancePlanReportBuilder(Aircraft aircraft, IEnumerable<BaseEntityObject> performances)
        {
            _reportedAircraft = aircraft;

            if (_reportedAircraft != null)
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircraft.OperatorId).LogotypeReportLarge;

            _reportedDirectives = performances;
        }
        #endregion

        #region Methods

        #region private DateTime GetDate(BaseEntityObject item)

        private DateTime GetDate(BaseEntityObject item)
        {
            if (item is NextPerformance)
            {
                DateTime? performanceDate = ((NextPerformance)item).PerformanceDate;
                if (performanceDate == null)
                    return DateTimeExtend.GetCASMinDateTime();
                return performanceDate.Value.Date;
            }
            if (item is AbstractPerformanceRecord)
            {
                return ((AbstractPerformanceRecord)item).RecordDate.Date;
            }
            return DateTimeExtend.GetCASMinDateTime();
        }
        #endregion

        #region private IBaseEntityObject GetParent(BaseEntityObject item)

        private IBaseEntityObject GetParent(BaseEntityObject item)
        {
            if (item == null)
                return null;

            IBaseEntityObject parent;
            if (item is NextPerformance)
            {
                parent = ((NextPerformance)item).Parent;
            }
            else if (item is AbstractPerformanceRecord)
            {
                parent = ((AbstractPerformanceRecord)item).Parent;
            }
            else parent = item;

            return parent;
        }
        #endregion

        #region private string GetAccessoryTypeString(AbstractAccessory accessory)

        private string GetAccessoryTypeString(AbstractAccessory accessory)
        {
            return accessory.GoodsClass.ToString();
        }
        #endregion

        #region protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        protected virtual void GetFilterSelection(CommonFilterCollection filterCollection)
        {
            if (_reportedAircraft != null)
            {
                _filterSelection = "All";
                if (filterCollection == null || filterCollection.IsEmpty) 
                    return;
                _filterSelection = filterCollection.ToStrings();
            }
            else  if (_reportedBaseComponent != null)
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
				IEnumerable<IGrouping<Aircraft, BaseEntityObject>> groupByAircraft =
				   _reportedDirectives.GroupBy(GlobalObjects.AircraftsCore.GetParentAircraft)
									  .OrderBy(g => g.Key.ToString() + " " + g.Key.Model.ToString());

				_filterSelection = "All";
	            if (GlobalObjects.AircraftsCore.GetAircraftsCount() == groupByAircraft.Count())
	            {
					if (filterCollection == null || filterCollection.IsEmpty)
						return;
					_filterSelection = filterCollection.ToStrings();
				}
				else
				{
					foreach (IGrouping<Aircraft, BaseEntityObject> byAircraft in groupByAircraft)
					{
						_filterSelection += (byAircraft.Key + "; ");
					}
					if (filterCollection == null || filterCollection.IsEmpty)
						return;
					_filterSelection = $"{_filterSelection} {filterCollection}";
				}
			}           
        }
        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            MaintenancePlanReport report = new MaintenancePlanReport();
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
            MaintenancePlanDataSet dataset = new MaintenancePlanDataSet();
            AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(MaintenancePlanDataSet dataset)
        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(MaintenancePlanDataSet dataset)
        {
            //группировка по родительскому самолету
            IEnumerable<IGrouping<Aircraft, BaseEntityObject>> groupByAircraft =
                _reportedDirectives.GroupBy(GlobalObjects.AircraftsCore.GetParentAircraft)
                                   .OrderBy(g => g.Key.ToString() + " " + g.Key.Model.ToString());
            foreach (IGrouping<Aircraft, BaseEntityObject> byAircraft in groupByAircraft)
            {
                IEnumerable<IGrouping<DateTime, BaseEntityObject>> groupedItems =
                    byAircraft.GroupBy(GetDate)
                              .OrderBy(g => g.Key);

                //сбор всех китов ВС в одну коллекцию
                List<AbstractAccessory> aircraftKits =
                    byAircraft.Select(ba => ba)
                              .Select(GetParent)
                              .Where(i => i is IKitRequired)
                              .SelectMany(i => ((IKitRequired)i).Kits)
                              .Cast<AbstractAccessory>()
                              .ToList();

                foreach (IGrouping<DateTime, BaseEntityObject> groupedItem in groupedItems)
                {
                    //Группировка элементов по датам выполнения
                    DateTime dateTime = groupedItem.Key.Date;
                    //Формирование первой части названия группы, состоящей из даты выполнения
                    string temp = "";
                    string kitString = "";
                    double manHours = 0;
                    //Собрание всех выполнений на данную дату в одну коллекцию
                    IEnumerable<BaseEntityObject> performances = groupedItem.Select(lvi => lvi).ToArray();
                    //Собрание всех КИТов на данную дату в одну коллекцию
                    IEnumerable<AccessoryRequired> kits =
                        performances.Select(GetParent)
                                    .Where(i => i is IKitRequired)
                                    .SelectMany(i => ((IKitRequired)i).Kits);
                    IEnumerable<IGrouping<string, AccessoryRequired>> groupByType = kits.GroupBy(GetAccessoryTypeString);
                    foreach (IGrouping<string, AccessoryRequired> grouping in groupByType)
                    {
                        if (!string.IsNullOrEmpty(kitString))
                            kitString += Environment.NewLine;
                        kitString += grouping.Key + Environment.NewLine;
                        
                        kitString =
                            grouping.Select(g=>g)
                                    .Distinct(new AccessoryRequired())
                                    .Aggregate(kitString, (current, kit) => current + (kit.ToString() + "; "));
                    }
                    //Добавление в название присутствующих на данную дату чеков программы обслуживания
                    IEnumerable<BaseEntityObject> maintenanceCheckPerformances =
                        performances.Where(np => GetParent(np) is MaintenanceCheck);

                    foreach (BaseEntityObject mcp in maintenanceCheckPerformances)
                    {
                        if (mcp is MaintenanceNextPerformance)
                        {
                            MaintenanceNextPerformance mnp = mcp as MaintenanceNextPerformance;

                            temp += mnp.PerformanceGroup.GetGroupName();
                            if (byAircraft.Key != null && byAircraft.Key.MSG < MSG.MSG3)
                                temp += "( " + mnp.PerformanceGroup.ToStringCheckNames() + ")";
                        }
                        else if (mcp is NextPerformance)
                        {
                            NextPerformance np = mcp as NextPerformance;
                            temp += ((MaintenanceCheck)np.Parent).Name;
                        }
                        else if (mcp is MaintenanceCheckRecord)
                        {
                            MaintenanceCheckRecord mcr = mcp as MaintenanceCheckRecord;
                            temp += string.IsNullOrEmpty(mcr.ComplianceCheckName)
                                ? mcr.ParentCheck.Name
                                : mcr.ComplianceCheckName;
                        }
                        else if (mcp is MaintenanceCheck)
                        {
                            MaintenanceCheck mc = (MaintenanceCheck)mcp;
                            if (mc.Grouping)
                            {
                                MaintenanceNextPerformance mnp =
                                    mc.GetNextPergormanceGroupWhereCheckIsSenior();
                                if (mnp != null)
                                    temp += mnp.PerformanceGroup.GetGroupName();
                                else temp += mc.Name;
                            }
                            else temp += mc.Name;
                        }
                        temp += " ";
                    }
                    IEnumerable<IBaseEntityObject> allDirectives = performances.Select(GetParent).ToArray();
                    //Добавление в название присутствующих на данную дату директив летной годности
                    IEnumerable<Directive> directivesPerformances = allDirectives.OfType<Directive>().ToArray();
                    if (directivesPerformances.Any())
                    {
                        IEnumerable<IGrouping<DirectiveType, Directive>> groupByDirectiveType =
                            directivesPerformances.GroupBy(d => d.DirectiveType);

                        foreach (IGrouping<DirectiveType, Directive> grouping in groupByDirectiveType)
                        {
                            if (!string.IsNullOrEmpty(temp))
                                temp += Environment.NewLine;
                            temp += grouping.Key.ShortName + " " + Environment.NewLine;

                            foreach (Directive ad in grouping)
                            {
                                temp += ad.Title + " § " + ad.Paragraph + " " + ad.WorkType;
                                temp += "; ";
                            }    
                        }

                        manHours += directivesPerformances.Sum(dp => dp.ManHours);
                    }

                    //Добавление в название присутствующих на данную дату компонентов или задач по ним
                    IEnumerable<IBaseEntityObject> componentPerformances =
                        allDirectives.Where(np => np is Component || np is ComponentDirective).ToArray();
                    if (componentPerformances.Any())
                    {
                        if (!string.IsNullOrEmpty(temp))
                            temp += Environment.NewLine;
                        temp += "Component" + Environment.NewLine;

                        foreach (IBaseEntityObject componentPerformance in componentPerformances)
                        {
                            Component d;
                            if (componentPerformance is ComponentDirective)
                            {
                                ComponentDirective dd = (ComponentDirective)componentPerformance;
                                d = ((ComponentDirective)componentPerformance).ParentComponent;
                                if (d != null)
                                    temp += "P/N:" + d.PartNumber + " S/N:" + d.SerialNumber + " " + dd.DirectiveType;
                                else temp += dd.DirectiveType;
                                manHours += dd.ManHours;

                                if(dd.DirectiveType == ComponentRecordType.Remove ||
                                   dd.DirectiveType == ComponentRecordType.Discard ||
                                   dd.DirectiveType == ComponentRecordType.Overhaul)
                                {
                                    //типом работ является удаление или уничтожение компонента

                                    //Добавление в коллекцию Китов ВС данного компонента, 
                                    //т.к. его необходимо будет приобрести
                                    aircraftKits.Add(d);    
                                }
                            }
                            else
                            {
                                d = componentPerformance as Component;
                                if (d != null)
                                {
                                    temp += "P/N:" + d.PartNumber + " S/N:" + d.SerialNumber + " Discard";
                                    manHours += d.ManHours;
                                    //Добавление в коллекцию Китов ВС данного компонента, 
                                    //т.к. его необходимо будет приобрести
                                    aircraftKits.Add(d);  
                                }
                            }
                            temp += "; ";
                        }
                    }
                    //Добавление в название присутствующих на данную дату MPD 
                    //Вывод только тех MPD что не привязаны к чекам
                    IEnumerable<MaintenanceDirective> mpdPerformances = 
                        allDirectives.OfType<MaintenanceDirective>().ToArray();
                    if (mpdPerformances.Any())
                    {
                        if (!string.IsNullOrEmpty(temp))
                            temp += Environment.NewLine;
                        temp += "MPD " + Environment.NewLine;

                        foreach (MaintenanceDirective mpd in mpdPerformances)
                        {
                            temp += mpd.TaskNumberCheck + " " + mpd.WorkType.ShortName + "; ";
                            manHours += mpd.ManHours;
                        }
                    }
                    dataset.ItemsTable.AddItemsTableRow("",
                                                        "",
                                                        temp,
                                                        dateTime,
                                                        manHours,
                                                        0,
                                                        kitString,
                                                        byAircraft.Key != null ? byAircraft.Key + " " + byAircraft.Key.Model : "Unk");
                }


                IEnumerable<IGrouping<Product, AbstractAccessory>> products =
                    aircraftKits.GroupBy(ak => ak.Product ?? 
                                               new Product{GoodsClass =  ak.GoodsClass, 
                                                           Standart = ak.Standart, 
                                                           PartNumber = ak.ParentString, 
                                                           Description = ak.Description}
                                                                        );
                foreach (IGrouping<Product, AbstractAccessory> product in products)
                {
                    string type = GetAccessoryTypeString(product.First());
                    double quantity = 0;
                    double totalProductCost = 0;

                    if(product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools) ||
                       product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ControlTestEquipment))
                    {
                        quantity = product.Max(p => p.Quantity);
                        totalProductCost = 0;
                    }
                    else if (product.Key.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ComponentsAndParts))
                    {
                        foreach (AbstractAccessory accessoryRequired in product)
                        {
                            int qty = accessoryRequired.Quantity < 1 ? 1 : (int)accessoryRequired.Quantity;
                            quantity += qty;
                            totalProductCost += (qty * accessoryRequired.CostNew);
                        }     
                    }
                    else
                    {
                        foreach (AbstractAccessory accessoryRequired in product)
                        {
                            quantity += accessoryRequired.Quantity;
                            totalProductCost += (accessoryRequired.Quantity * accessoryRequired.CostNew);
                        }    
                    }

                    dataset.KitsTable.AddKitsTableRow(product.Key.ToString(),
                                                      quantity,
                                                      totalProductCost,
                                                      byAircraft.Key != null ? byAircraft.Key + " " + byAircraft.Key.Model : "Unk",
                                                      type);
                }
            }
        }
        #endregion

        #region private void AddAircraftToDataset(MaintenancePlanDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(MaintenancePlanDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
            {
                destinationDataSet.AircraftDataTable.AddAircraftDataTableRow("", "", -1, -1,
                                                                             "", "", "", "",
                                                                             -1, -1, "");
                return;
            }

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = _reportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ToString();
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
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

            var lineNumber = _reportedAircraft.LineNumber;
            var variableNumber = _reportedAircraft.VariableNumber;
            destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(serialNumber,
                                                                         manufactureDate,
                                                                         sinceNewHours,
                                                                         sinceNewCycles,
                                                                         registrationNumber, model, lineNumber, variableNumber,
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(MaintenancePlanDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(MaintenancePlanDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);
        }

        #endregion

        #region protected virtual void AddForecastToDataSet(MaintenancePlanDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(MaintenancePlanDataSet destinationDataSet)
        {
			ForecastData fd = _forecast != null ? _forecast.GetForecastDataFrame() : null;
			if (fd == null)
			{
				destinationDataSet.ForecastTable.AddForecastTableRow(0,
																	 0,
																	 "",
																	 0,
																	 0,
																	 0,
																	 "");
				return;
			}
			double avgUtilizationCycles = fd.AverageUtilization.Cycles;
			double avgUtilizationHours = fd.AverageUtilization.Hours;
			string avgUtilizationType = fd.AverageUtilization.SelectedInterval.ToString();
			int forecastCycles = fd.ForecastLifelength.Cycles != null
									 ? (int)fd.ForecastLifelength.Cycles
									 : 0;
			int forecastHours = fd.ForecastLifelength.Hours != null
									? (int)fd.ForecastLifelength.Hours
									: 0;
			int forecastDays = fd.ForecastLifelength.Days != null
								   ? (int)fd.ForecastLifelength.Days
								   : 0;
			string forecastDate = "";

			if (fd.SelectedForecastType == ForecastType.ForecastByDate)
			{
				forecastDate = SmartCore.Auxiliary.Convert.GetDateFormat(fd.ForecastDate);
			}
			else if (fd.SelectedForecastType == ForecastType.ForecastByPeriod)
			{
				forecastDate = SmartCore.Auxiliary.Convert.GetDateFormat(fd.LowerLimit) + " - " +
							   SmartCore.Auxiliary.Convert.GetDateFormat(fd.ForecastDate);
			}
			else if (fd.SelectedForecastType == ForecastType.ForecastByCheck)
			{
				if (fd.NextPerformanceByDate)
				{
					forecastDate = fd.NextPerformanceString;
				}
				else
				{
					forecastDate =
						$"{fd.CheckName}. {SmartCore.Auxiliary.Convert.GetDateFormat(Convert.ToDateTime(fd.NextPerformance.PerformanceDate))}";
				}
			}
			destinationDataSet.ForecastTable.AddForecastTableRow(avgUtilizationCycles,
																 avgUtilizationHours,
																 avgUtilizationType,
																 forecastCycles,
																 forecastHours,
																 forecastDays,
																 forecastDate);
		}

        #endregion

        #endregion

    }
}