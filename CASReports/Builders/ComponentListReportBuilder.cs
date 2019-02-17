using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;
using TempUIExtentions;

namespace CASReports.Builders
{
    public class ComponentListReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        private Aircraft _reportedAircraft;
        private BaseComponent _reportedBaseComponent;
        private List<object> _reportedItems = new List<object>();
        private Forecast _forecast;

        private string _dateAsOf = "";

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "COMPONENT STATUS";
        private string _filterSelection;
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;
        private Lifelength _current;
        private DateTime _manufactureDate;

        #endregion

        #region Properties

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС включаемыое в отчет
        /// </summary>
        public Aircraft ReportedAircraft
        {
            get
            {
                return _reportedAircraft;
            }
            set
            {
                _reportedAircraft = value;
                if(value == null)return;
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
            get
            {
                return _reportedBaseComponent;
            }
            set
            {
                if (value == null) return;
                _reportedBaseComponent = value;
                _manufactureDate = _reportedBaseComponent.ManufactureDate;
                _current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);
                _operatorLogotype = GlobalObjects.CasEnvironment.Operators[0].LogotypeReportLarge;
                _reportedItems.Clear();
            }
        }
        #endregion

        #region public List<object> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public List<object> ReportedDirectives
        {
            get
            {
                return _reportedItems;
            }
            set
            {
                _reportedItems = value;
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

        #region public CommonFilterCollection ReportTitle

        /// <summary>
        /// Текст фильтра отчета
        /// </summary>
        public CommonFilterCollection FilterSelection
        {
            set { GetFilterSelection(value); }
        }

        #endregion
        /*#region public virtual DirectiveFilter DefaultFilter

        /// <summary>
        /// Фильтр по умолчанию
        /// </summary>
        public virtual DirectiveFilter DefaultFilter
        {
            get
            {
                return defaultFilter;
            }
        }

        #endregion*/

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
            get
            {
                return _operatorLogotype;
            }
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

        #region Methods

        #region public void AddDirectives(object[] directives)

        public void AddDirectives(object[] directives)
        {
            _reportedItems.Clear();
            _reportedItems.AddRange(directives);
            if (_reportedItems.Count == 0)
                return;

        }

        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            var report = new ComponentListReport();
			report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual ComponentListDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual ComponentListDataSet GenerateDataSet()
        {
            ComponentListDataSet dataset = new ComponentListDataSet();
            AddAircraftToDataset(dataset);
            AddBaseDetailToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
            AddForecastToDataSet(dataset);
            return dataset;
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

        #region protected virtual void AddDirectivesToDataSet(ComponentListDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(ComponentListDataSet dataset)
        {
            /* List<String> colors = new List<string>();
            for (int i = 0; i < HighlightCollection.Instance.Count; i++ )
            {
                colors.Add(HighlightCollection.Instance[i].Color.R.ToString()+" "+
                            HighlightCollection.Instance[i].Color.G.ToString()+" "+
                            HighlightCollection.Instance[i].Color.B.ToString());
            }
            MessageBox.Show(string.Join("\r\n",colors.ToArray()));*/
            foreach (object t in _reportedItems)
            {
                AddDirectiveToDataset(t, dataset);
            }
        }

        #endregion

        #region private void AddAircraftToDataset(ComponentListDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddAircraftToDataset(ComponentListDataSet destinationDataSet)
        {
            if (_reportedAircraft == null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);

            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var serialNumber = _reportedAircraft.SerialNumber;
            var model = _reportedAircraft.Model.ShortName;
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
                                                                         averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);
        }

        #endregion

        #region private void AddBaseDetailToDataset(ComponentListDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddBaseDetailToDataset(ComponentListDataSet destinationDataSet)
        {
            if (_reportedAircraft != null)
                return;

            var reportAircraftLifeLenght = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedBaseComponent);

            var manufactureDate = _reportedBaseComponent.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var deliveryDate = _reportedBaseComponent.DeliveryDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var status = _reportedBaseComponent.Serviceable ? "Serviceable" : "Unserviceable";
            var sinceNewHours = reportAircraftLifeLenght.Hours != null ? (int)reportAircraftLifeLenght.Hours : 0;
            var sinceNewCycles = reportAircraftLifeLenght.Cycles != null ? (int)reportAircraftLifeLenght.Cycles : 0;
            var sinceNewDays = reportAircraftLifeLenght.Days != null ? reportAircraftLifeLenght.Days.ToString() : "";

            var lifeLimit = _reportedBaseComponent.LifeLimit;
            var lifeLimitHours = lifeLimit.Hours != null ? lifeLimit.Hours.ToString() : "";
            var lifeLimitCycles = lifeLimit.Cycles != null ? lifeLimit.Cycles.ToString() : "";
            var lifeLimitDays = lifeLimit.Days != null ? lifeLimit.Days.ToString() : "";
            var remain = new Lifelength(lifeLimit);
            remain.Substract(reportAircraftLifeLenght);
            var remainHours = remain.Hours != null ? remain.Hours.ToString() : "";
            var remainCycles = remain.Cycles != null ? remain.Cycles.ToString() : "";
            var remainDays = remain.Days != null ? remain.Days.ToString() : "";
            var installationDate = _reportedBaseComponent.TransferRecords.GetLast().TransferDate;
			//TODO:(Evgenii Babak)  нужно брать наработку с записи о выполнении, а не пересчитывать заново
			var onInstall = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(_reportedBaseComponent, installationDate);
            var onInstallDate = installationDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var onInstallHours = onInstall.Hours != null ? onInstall.Hours.ToString() : "";
            var onInstallCycles = onInstall.Cycles != null ? onInstall.Cycles.ToString() : "";
            var onInstallDays = onInstall.Days != null ? onInstall.Days.ToString() : "";
            var sinceInstall = new Lifelength(reportAircraftLifeLenght);
            sinceInstall.Substract(onInstall);
            var sinceInstallHours = sinceInstall.Hours != null ? sinceInstall.Hours.ToString() : "";
            var sinceInstallCycles = sinceInstall.Cycles != null ? sinceInstall.Cycles.ToString() : "";
            var sinceInstallDays = sinceInstall.Days != null ? sinceInstall.Days.ToString() : "";
            var warranty = _reportedBaseComponent.Warranty;
            var warrantyRemain = new Lifelength(warranty);
            warrantyRemain.Substract(reportAircraftLifeLenght);
            warrantyRemain.Resemble(warranty);
            var warrantyHours = warranty.Hours != null ? warranty.Hours.ToString() : "";
            var warrantyCycles = warranty.Cycles != null ? warranty.Cycles.ToString() : "";
            var warrantyDays = warranty.Days != null ? warranty.Days.ToString() : "";
            var warrantyRemainHours = warrantyRemain.Hours != null ? warrantyRemain.Hours.ToString() : "";
            var warrantyRemainCycles = warrantyRemain.Cycles != null ? warrantyRemain.Cycles.ToString() : "";
            var warrantyRemainDays = warrantyRemain.Days != null ? warrantyRemain.Days.ToString() : "";
            var parentAircaft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedBaseComponent.ParentAircraftId);
	        var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircaft.AircraftFrameId);
			var aircraftOnInstall = GlobalObjects.CasEnvironment.Calculator.GetFlightLifelengthOnEndOfDay(aircraftFrame, installationDate);
            var aircraftOnInstallHours = aircraftOnInstall.Hours != null ? aircraftOnInstall.Hours.ToString() : "";
            var aircraftOnInstallCycles = aircraftOnInstall.Cycles != null ? aircraftOnInstall.Cycles.ToString() : "";
            var aircraftOnInstallDays = aircraftOnInstall.Days != null ? aircraftOnInstall.Days.ToString() : "";
            var aircraftCurrent = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(parentAircaft);
            var aircraftCurrentCycles = aircraftCurrent.Cycles ?? 0;

            var sinceOverhaul = Lifelength.Null;
            var lastOverhaulDate = DateTime.MinValue;
            var lastOverhaulDateString = "";

			#region поиск последнего ремонта и расчет времени, прошедшего с него
			//поиск директив деталей
			var directives = GlobalObjects.ComponentCore.GetComponentDirectives(_reportedBaseComponent, true);
            //поиск директивы ремонта
            var overhauls = directives.Where(d => d.DirectiveType == ComponentRecordType.Overhaul).ToList();
            //поиск последнего ремонта
            ComponentDirective lastOverhaul = null;
            foreach (ComponentDirective d in overhauls)
            {
                if (d.LastPerformance == null || d.LastPerformance.RecordDate <= lastOverhaulDate) continue;

                lastOverhaulDate = d.LastPerformance.RecordDate;
                lastOverhaul = d;
            }

            if (lastOverhaul != null)
            {
                sinceOverhaul.Add(reportAircraftLifeLenght);
                sinceOverhaul.Substract(lastOverhaul.LastPerformance.OnLifelength);
                lastOverhaulDateString = lastOverhaul.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            }

            #endregion

            destinationDataSet.BaseDetailTable.AddBaseDetailTableRow(_reportedBaseComponent.ATAChapter.ToString(),
                                                                     _reportedBaseComponent.AvionicsInventory.ToString(),
                                                                     _reportedBaseComponent.PartNumber,
                                                                     _reportedBaseComponent.SerialNumber,
                                                                     _reportedBaseComponent.Model != null ? _reportedBaseComponent.Model.ToString() : "",
                                                                     _reportedBaseComponent.BaseComponentType.ToString(),
																	 _reportedBaseComponent.GetParentAircraftRegNumber(),
																	 _reportedBaseComponent.TransferRecords.GetLast().Position,
                                                                     _reportedBaseComponent.Manufacturer,
                                                                     manufactureDate,
                                                                     deliveryDate,
                                                                     _reportedBaseComponent.MPDItem,
                                                                     _reportedBaseComponent.Suppliers != null ? _reportedBaseComponent.Suppliers.ToString() : "",
                                                                     status,
                                                                     _reportedBaseComponent.Cost,
                                                                     _reportedBaseComponent.CostOverhaul,
                                                                     _reportedBaseComponent.CostServiceable,
                                                                     lifeLimitHours,
                                                                     lifeLimitCycles,
                                                                     lifeLimitDays,
                                                                     sinceNewHours,
                                                                     sinceNewCycles,
                                                                     sinceNewDays,
                                                                     remainCycles,
                                                                     remainHours,
                                                                     remainDays,
                                                                     onInstallDate,
                                                                     onInstallHours,
                                                                     onInstallCycles,
                                                                     onInstallDays,
                                                                     sinceInstallHours,
                                                                     sinceInstallCycles,
                                                                     sinceInstallDays,
                                                                     warrantyHours,
                                                                     warrantyCycles,
                                                                     warrantyDays,
                                                                     warrantyRemainHours,
                                                                     warrantyRemainCycles,
                                                                     warrantyRemainDays,
                                                                     aircraftOnInstallHours,
                                                                     aircraftOnInstallCycles,
                                                                     aircraftOnInstallDays,
                                                                     lastOverhaulDateString,
                                                                     sinceOverhaul.Hours ?? 0,
                                                                     sinceOverhaul.Cycles ?? 0);

            int averageUtilizationHours;
            int averageUtilizationCycles;
            string averageUtilizationType;
            if (_forecast == null)
            {
				var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);
				//TODO:(Evgenii Babak) убрать повторяющийся код при использовании AverageUtilization
				averageUtilizationHours = (int)averageUtilization.Hours;
				averageUtilizationCycles = (int)averageUtilization.Cycles;
				averageUtilizationType = averageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";
			}
            else
            {
				//TODO:(Evgenii Babak) убрать повторяющийся код при использовании AverageUtilization
				averageUtilizationHours = (int)_forecast.ForecastDatas[0].AverageUtilization.Hours;
                averageUtilizationCycles = (int)_forecast.ForecastDatas[0].AverageUtilization.Cycles;
                averageUtilizationType =
                    _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval == UtilizationInterval.Dayly ? "Day" : "Month";

            }

            var serialNumber = parentAircaft.SerialNumber;
            var model = parentAircaft.Model.ShortName;
            var registrationNumber = parentAircaft.RegistrationNumber;
            var lineNumber = parentAircaft.LineNumber;
            var variableNumber = parentAircaft.VariableNumber;

            //destinationDataSet.AircraftDataTable.AddAircraftDataTableRow(serialNumber,
            //                                                             manufactureDate,
            //                                                             aircraftCurrent.ToHoursMinutesFormat(""),
            //                                                             aircraftCurrentCycles,
            //                                                             registrationNumber, model, lineNumber, variableNumber,
            //                                                             averageUtilizationHours, averageUtilizationCycles, averageUtilizationType);

        }

        #endregion

        #region public void AddDirectiveToDataset(object DetailDirective, ComponentListDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="reportedDirective">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddDirectiveToDataset(object reportedDirective, ComponentListDataSet destinationDataSet)
        {
            //if (!DefaultFilter.Acceptable(directive))
            //  return;
            Component component;
            ComponentDirective directive;
            NextPerformance nextDueAtAircraftUtilization = null;
            DirectiveRecord lastPerformance = null;
            string positionString = "";
            string remarks = "", condition = "";
            string workType = "", lastComplianceDate = "", nextComplianceDate = "", ampReference = "";
            double mansHours = 0, cost = 0;
            DateTime installationDate = DateTimeExtend.GetCASMinDateTime();
            string kits = "", equipment = "", status = "";
            Lifelength lifeLimit, componentCurrent = Lifelength.Null;
            Lifelength repeat = Lifelength.Null, lastCompliance = Lifelength.Null;
            Lifelength used = Lifelength.Null, nextPerformanceSource = Lifelength.Null, remain = Lifelength.Null;
            
            if(reportedDirective is ComponentDirective)
            {
                directive = (ComponentDirective) reportedDirective;
                component = directive.ParentComponent;
                positionString = component.TransferRecords.GetLast().Position;
                installationDate = component.TransferRecords.GetLast().TransferDate;

                componentCurrent = directive.ParentComponent.IsBaseComponent 
                    ? GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseComponent)component) 
                    : GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(component);
                
                remarks = directive.Remarks;
                workType = directive.DirectiveType.ToString();
                repeat = directive.Threshold.RepeatInterval;
                lifeLimit = component.LifeLimit;

                //nextCompliance = GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(directive);
                GlobalObjects.PerformanceCalculator.GetNextPerformance(directive);
                nextPerformanceSource = directive.NextPerformanceSource;
                
                if(directive.MaintenanceDirective != null)
                {
                    ampReference = directive.MaintenanceDirective.TaskNumberCheck;
                }
                if(nextPerformanceSource != null && directive.Status != DirectiveStatus.Closed)
                {
                    nextComplianceDate = directive.NextPerformanceDate != null
                                     ? ((DateTime) directive.NextPerformanceDate).ToString(
                                         new GlobalTermsProvider()["DateFormat"].ToString())
                                     : "";
                    remain.Add(nextPerformanceSource); 
                    remain.Substract(componentCurrent);
                    used.Add(componentCurrent);

                    if (_reportedAircraft != null)
                    {
                        nextDueAtAircraftUtilization = new NextPerformance
                        {
                            PerformanceDate = directive.NextPerformanceDate,
                            PerformanceSource = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft)
                        };

                        nextDueAtAircraftUtilization.PerformanceSource.Add(remain);
                    }
                }
                else nextPerformanceSource = Lifelength.Null;
                
                
                if(directive.LastPerformance != null && directive.Status != DirectiveStatus.Closed)
                {
                    lastPerformance = directive.LastPerformance;
                    lastComplianceDate =
                        directive.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                    lastCompliance = directive.LastPerformance.OnLifelength;

                    used.Substract(lastCompliance);
                    used.Resemble(directive.Threshold.RepeatInterval);
                    remain.Resemble(directive.Threshold.RepeatInterval);
                    if (nextDueAtAircraftUtilization != null)
                        nextDueAtAircraftUtilization.PerformanceSource.Resemble(directive.Threshold.RepeatInterval);
                }
                else
                {
                    used.Resemble(directive.Threshold.FirstPerformanceSinceNew);
                    remain.Resemble(directive.Threshold.FirstPerformanceSinceNew);
                    if (nextDueAtAircraftUtilization != null)
                        nextDueAtAircraftUtilization.PerformanceSource.Resemble(directive.Threshold.FirstPerformanceSinceNew);
                }

                int num = 1;
                foreach (AccessoryRequired kit in directive.Kits)
                {
                    kits += num + ": " + kit.PartNumber + "\n";
                    num ++;
                }

                condition = directive.Condition.ToString();
				

            }
            //Если объект является деталью или базовой деталью с директивами
            //то надо возвратится, т.к. данные по детали/базовой детали будут
            //добавлены при добавлении их директив в набор данных
            //Если деталь.базовая деталь без директив, тогда в набор данных надо добавить и данные сразу
            else if (reportedDirective is Component)
            {
                component = (Component)reportedDirective;
                lifeLimit = component.LifeLimit; 
                if(component.ComponentDirectives.Count != 0) return;
            }
            else
            {
                throw new ArgumentException();
            }

            Lifelength lifeLimitUsed = Lifelength.Null;
            lifeLimitUsed.Add(componentCurrent);
            lifeLimitUsed.Resemble(lifeLimit);
            Lifelength lifeLimitRemain = Lifelength.Null;
            lifeLimitRemain.Add(lifeLimit);
            lifeLimitRemain.Substract(componentCurrent);
            lifeLimitRemain.Resemble(lifeLimit);
            
            //string status = "";
            //if (.Status == DirectiveStatus.Closed) status = "C";
            //if (directive.Status == DirectiveStatus.Open) status = "O";
            //if (directive.Status == DirectiveStatus.Repetative) status = "R";
            //if (directive.Status == DirectiveStatus.NotApplicable) status = "N/A";

            destinationDataSet.ItemsTable.AddItemsTableRow(component.ATAChapter.ShortName,
                                                           ampReference,
                                                           component.PartNumber,
                                                           component.SerialNumber,
                                                           positionString,
                                                           component.Description,
                                                           component.MaintenanceControlProcess.ToString(),
                                                           installationDate,
                                                           lifeLimit.Days != null ? lifeLimit.Days.ToString() : "",
                                                           lifeLimit.Hours != null ? lifeLimit.Hours.ToString() : "",
                                                           lifeLimit.Cycles != null ? lifeLimit.Cycles.ToString() : "",
                                                           lifeLimitUsed.Days != null
                                                               ? lifeLimitUsed.Days.ToString()
                                                               : "",
                                                           lifeLimitUsed.Hours != null
                                                               ? lifeLimitUsed.Hours.ToString()
                                                               : "",
                                                           lifeLimitUsed.Cycles != null
                                                               ? lifeLimitUsed.Cycles.ToString()
                                                               : "",
                                                           lifeLimitRemain.Days != null
                                                               ? lifeLimitRemain.Days.ToString()
                                                               : "",
                                                           lifeLimitRemain.Hours != null
                                                               ? lifeLimitRemain.Hours.ToString()
                                                               : "",
                                                           lifeLimitRemain.Cycles != null
                                                               ? lifeLimitRemain.Cycles.ToString()
                                                               : "",
                                                           workType,
                                                           repeat.Days != null
                                                               ? repeat.Days.ToString()
                                                               : "",
                                                           repeat.Hours != null
                                                               ? repeat.Hours.ToString()
                                                               : "",
                                                           repeat.Cycles != null
                                                               ? repeat.Cycles.ToString()
                                                               : "",
                                                           repeat.ToHoursMinutesAndCyclesStrings(" FH", " FC"),
                                                           lastComplianceDate,
                                                           lastCompliance.Hours != null
                                                               ? lastCompliance.Hours.ToString()
                                                               : "",
                                                           lastCompliance.Cycles != null
                                                               ? lastCompliance.Cycles.ToString()
                                                               : "",
                                                           lastPerformance != null
                                                               ? lastPerformance.ToStrings("/")
                                                               : "",
                                                           used.Days != null ? used.Days.ToString() : "",
                                                           used.Hours != null ? used.Hours.ToString() : "",
                                                           used.Cycles != null ? used.Cycles.ToString() : "",
                                                           nextComplianceDate,
                                                           nextPerformanceSource.Hours != null
                                                               ? nextPerformanceSource.Hours.ToString()
                                                               : "",
                                                           nextPerformanceSource.Cycles != null
                                                               ? nextPerformanceSource.Cycles.ToString()
                                                               : "",
                                                           nextDueAtAircraftUtilization != null
                                                               ? nextDueAtAircraftUtilization.ToStrings("/")
                                                               : "",
                                                           remain.Days != null ? remain.Days.ToString() : "",
                                                           remain.Hours != null ? remain.Hours.ToString() : "",
                                                           remain.Cycles != null ? remain.Cycles.ToString() : "",
                                                           remain.ToHoursMinutesAndCyclesStrings(" FH", " FC"),
                                                           condition, mansHours, cost, kits, 
                                                           equipment, remarks, status);
        }

        #endregion

        #region private void AddAdditionalDataToDataSet(ComponentListDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(ComponentListDataSet destinationDateSet)
        {
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #region protected virtual void AddForecastToDataSet(ComponentListDataSet destinationDataSet)

        protected virtual void AddForecastToDataSet(ComponentListDataSet destinationDataSet)
        {
            //string manufactureDate = UsefulMethods.NormalizeDate(ReportedBaseDetail.ManufactureDate);
            //string sinceNewHours = "";// LifelengthFormatter.GetHoursData(ReportedBaseDetail.Limitation.ResourceSinceNew.Hours).Trim() + " hrs";
            //string sinceNewCycles = "";//ReportedBaseDetail.Limitation.ResourceSinceNew.Cycles.ToString().Trim() + " cyc";
            //string sinceOverhaulHours = "";// LifelengthFormatter.GetHoursData(ReportedBaseDetail.Limitation.ResourceSinceOverhaul.Hours).Trim() + " hrs";
            //string sinceOverhaulCycles = "";//ReportedBaseDetail.Limitation.ResourceSinceOverhaul.Cycles.ToString().Trim() + " cyc";
            //string sinceHotSectionInspectionHours = "";//LifelengthFormatter.GetHoursData(ReportedBaseDetail.Limitation.ResourceSinceHotSectionInspection.Hours).Trim() + " hrs";
            //string sinceHotSectionInspectionCycles = "";//ReportedBaseDetail.Limitation.ResourceSinceHotSectionInspection.Cycles.ToString().Trim() + " cyc";
            //string baseDetailType = "";
            //if (ReportedBaseDetail.DetailType==DetailType.Engine)
            //    baseDetailType = "Engine";
            //else if (ReportedBaseDetail.DetailType == DetailType.Apu)
            //    baseDetailType = "APU";
            double avgUtilizationCycles = _forecast != null ? _forecast.ForecastDatas[0].AverageUtilization.Cycles : 0;
            double avgUtilizationHours = _forecast != null ? _forecast.ForecastDatas[0].AverageUtilization.Hours : 0;
            string avgUtilizationType = _forecast != null
                                            ? _forecast.ForecastDatas[0].AverageUtilization.SelectedInterval.ToString()
                                            : "";
            int forecastCycles = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastLifelength.Cycles != null 
                    ? (int)_forecast.ForecastDatas[0].ForecastLifelength.Cycles 
                    : 0
                : 0;
            int forecastHours = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastLifelength.Hours != null
                    ? (int)_forecast.ForecastDatas[0].ForecastLifelength.Hours 
                    : 0
                : 0;
            int forecastDays = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastLifelength.Days != null 
                    ? (int)_forecast.ForecastDatas[0].ForecastLifelength.Days 
                    : 0
                : 0;
            string forecastDate = _forecast != null
                ? _forecast.ForecastDatas[0].ForecastDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString())
                : "";
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
