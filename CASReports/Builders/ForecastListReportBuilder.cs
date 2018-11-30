using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using System.Windows.Forms;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчетов для списка директив
    /// </summary>
    public class ForecastListReportBuilder : AbstractReportBuilder
    {

        #region Fields

        /// <summary>
        /// Формировщик вывода информации о наработке
        /// </summary>
        private readonly LifelengthFormatter _lifelengthFormatter = new LifelengthFormatter();
        /// <summary>
        /// ВС включаемые в отчет
        /// </summary>
        private List <Aircraft> _reportedAircrafts = new List<Aircraft>();
        /// <summary>
        /// Базовый агрегат, включаемый в отчет
        /// </summary>
        private BaseComponent _reportedBaseComponent;
        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        private List<BaseEntityObject> _reportedDirectives = new List<BaseEntityObject>();

        private string _dateAsOf = "";

        private string _forecastDateAndUtilizationData = "";

        private readonly ForecastData _forecastData;

        //readonly AllDirectiveFilter defaultFilter = new AllDirectiveFilter();
        private string _reportTitle = "Forecast list report";
        private bool _isFiltered;
        private byte[] _operatorLogotype;

        private Lifelength _lifelengthAircraftSinceNew;
        private Lifelength _lifelengthAircraftSinceOverhaul;

        #endregion

        #region Properties

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС включаемыое в отчет
        /// </summary>
        public List<Aircraft> ReportedAircraft
        {
            get
            {
                return _reportedAircrafts;
            }
            set
            {
                _reportedAircrafts = value;
				OperatorLogotype = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircrafts[0].OperatorId).LogoTypeWhite;
				//    reportedDirectives.Clear();
				//   reportedDirectives.AddRange(GlobalObjects.CasEnvironment.Loader.GetAdDirectives(reportedAircrafts));
			}
        }

        #endregion

        #region public List<BaseEntityObject> ReportedDirectives

        /// <summary>
        /// Директивы включаемые в отчет
        /// </summary>
        public List<BaseEntityObject> ReportedDirectives
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

        #region public LifelengthFormatter LifelengthFormatter

        /// <summary>
        /// Формировщик вывода информации о наработке
        /// </summary>
        public LifelengthFormatter LifelengthFormatter
        {
            get { return _lifelengthFormatter; }
        }

        #endregion

        #region public bool IsFiltered
        /// <summary>
        /// Используется ли филтр в отчете
        /// </summary>
        public bool IsFiltered
        {
            get { return _isFiltered; }
            set { _isFiltered = value; }
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

        #region public ForecastListReportBuilder

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public ForecastListReportBuilder(ForecastData forecastdata)
        {
            _forecastData = forecastdata;
        }

        #endregion

        #region public void AddDirectives(IEnumerable<BaseEntityObject> directives)

        public void AddDirectives(IEnumerable<BaseEntityObject> directives)
        {
            _reportedDirectives.Clear();
            _reportedDirectives.AddRange(directives);
            if (_reportedDirectives.Count == 0)
                MessageBox.Show("0 ForecastReportBuilderDirectives");
                return;
        }

        #endregion

        #region public object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            ForecastListReport report = new ForecastListReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region public virtual DirectiveListReportDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual ForecastListDataSet GenerateDataSet()
        {
            ForecastListDataSet dataset = new ForecastListDataSet();
        //    AddAircraftToDataset(dataset);
            AddDirectivesToDataSet(dataset);
            AddAdditionalDataToDataSet(dataset);
        //    if (ReportedBaseDetail != null)
        //        AddBaseDetailToDataSet(dataset);
            return dataset;
        }

        #endregion

        #region protected virtual void AddDirectivesToDataSet(DirectiveListReportDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDirectivesToDataSet(ForecastListDataSet dataset)
        {
            bool bFlag = false;

            for (int i = 0; i < _reportedDirectives.Count; i++)
            {
                if(_reportedDirectives[i] is Directive)
                {
                    AddDirectiveToDataset((Directive) _reportedDirectives[i], dataset);
                    bFlag = true;
                    
                }
                if (_reportedDirectives[i] is DeferredItem)
                {
                    AddDefferedItemToDataset((DeferredItem)_reportedDirectives[i], dataset);
                    bFlag = true;
                //    CountDirectives++;
                }
                if (_reportedDirectives[i] is Component)
                {
                    AddDetailItemToDataset((Component)_reportedDirectives[i], dataset);
                    bFlag = true;
                    //    CountDirectives++;
                }
            }

            if(bFlag == false)
            {
                MessageBox.Show("EmptyDataSet");
            }

        //    MessageBox.Show(CountDirectives.ToString());
        }

        #endregion

        #region public void AddAircraftToDataset(Aircraft aircraft, DirectiveListReportDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        public virtual void AddAircraftToDataset(ForecastListDataSet destinationDataSet)
        {
            if (ReportedAircraft == null)
                return;
            var manufactureDate = ReportedAircraft[0].ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
      //      string SinceNewHours = lifelengthFormatter.GetHoursData(new TimeSpan((int)GlobalObjects.CasEnvironment.Calculator.GetLifelength(reportedAircraft).Hours,0,0)).Trim();
      //      string sinceNewCycles = GlobalObjects.CasEnvironment.Calculator.GetLifelength(reportedAircraft).Cycles.ToString().Trim();
            var registrationNumber = ReportedAircraft[0].RegistrationNumber;
            var frameSerialNumber = GlobalObjects.ComponentCore.GetBaseComponentById(ReportedAircraft[0].AircraftFrameId).ToString();
			var aircraftModel = ReportedAircraft[0].Model.ToString();
            destinationDataSet.
                AircraftInformationTable.
                    AddAircraftInformationTableRow(registrationNumber, frameSerialNumber, 
                                                   manufactureDate, aircraftModel);
        }

        #endregion

        #region public void AddDirectiveToDataset(Directive directive, DirectiveListReportDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="directive">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        public virtual void AddDirectiveToDataset(Directive directive, ForecastListDataSet destinationDataSet)
        {
            GlobalObjects.PerformanceCalculator.GetNextPerformance(directive, _forecastData);

            var ataCapter = "";// directive.ATAChapter.ToString();
			var reference = "";// directive.References;
			var description = "";// directive.Description;
			var lastPerformance = (directive.LastPerformance == null ? "" : directive.LastPerformance.ToString());
			var mansHours = directive.ManHours;
			var overdue = (directive.Remains == null ? "" : directive.Remains.ToString());// ADStatusItem.ToString();
			var cost = directive.Cost;
			var approxDate = directive.NextPerformanceDate != null 
                ? SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)directive.NextPerformanceDate)
                : "";

			var groupName = "ADStatusItem";
            
			//TODO:(Evgenii Babak) пересмотреть использование ParenAircraftId здесь
            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(directive.ParentBaseComponent.ParentAircraftId);
			var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);
			var aircraftRegAndFrameSN = $"{directive.ParentBaseComponent.GetParentAircraftRegNumber()} | {aircraftFrame} | {groupName}";

			destinationDataSet.
                Items.
                    AddItemsRow(ataCapter, reference, description, "Work Type",
                                mansHours, groupName, cost, overdue, approxDate, lastPerformance,
                                aircraftRegAndFrameSN);
        }

        #endregion

        #region public override void AddDefferedItemToDataset(DefferedItem defferedItem, WorkPackageDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент CpcpItem в таблицу данных
        /// </summary>
        /// <param name="defferedItem">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        public void AddDefferedItemToDataset(DeferredItem defferedItem, ForecastListDataSet destinationDataSet)
        {
            //Lifelength nextPerform;
            //Lifelength remain;
            //ConditionState conditionState;
            //DateTime? approx;
            //GlobalObjects.CasEnvironment.Calculator.GetNextPerformance((DefferedItem)defferedItem,
            //                                                            out nextPerform, out remain, out approx,
            //                                                            out conditionState);

            //string ataCapter = defferedItem.ATAChapter.ToString();
            //string DefferenceNumber = defferedItem.References;
            //string subject = defferedItem.Subject;
            //string lastPerformance = defferedItem.LastPerformance.ToString();
            //string overdue = defferedItem.NextPerformance.ToString();
            //double mansHours = defferedItem.ManHours;
            //double cost = defferedItem.Cost;
            ////     ((DefferedItem)item).LastPerformance == null ? "" : ((DefferedItem)item).LastPerformance.ToString(),
            ////      remain == null ? "" : remain.ToString();
            ////              "Work Type",
            ////      approx == null ? "" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime) approx);
            ////             ((DefferedItem)item).ManHours.ToString(),
            ////              ((DefferedItem)item).Cost.ToString()
            //string approxDate = SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)approx);

            //Aircraft parentAircraft = defferedItem.ParentAircraft;
            //string groupName = "DefferedItem";

            //string aircraftRegAndFrameSN = parentAircraft.RegistrationNumber + " | " +
            //                               parentAircraft.Frame.ToString() + " | " + groupName;
            //destinationDataSet.
            //    Items.
            //        AddItemsRow(ataCapter, DefferenceNumber, subject, "Work Type",
            //                    mansHours, groupName, cost, overdue, approxDate, lastPerformance,
            //                    aircraftRegAndFrameSN);

        }

        #endregion

        #region public override void AddDefferedItemToDataset(DefferedItem defferedItem, WorkPackageDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент CpcpItem в таблицу данных
        /// </summary>
        /// <param name="componentItemобавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        public void AddDetailItemToDataset(Component componentItem, ForecastListDataSet destinationDataSet)
        {
            GlobalObjects.PerformanceCalculator.GetNextPerformance(componentItem, _forecastData);

            var ataCapter = componentItem.ATAChapter.ToString();
			var description = componentItem.Description;
			var remarks = componentItem.Remarks;
			var mansHours = componentItem.ManHours;
			var cost = componentItem.Cost;
			var approxDate = componentItem.NextPerformanceDate != null
                ? SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)componentItem.NextPerformanceDate) 
                : "";

            var parentAircraft = GlobalObjects.AircraftsCore.GetAircraftById(componentItem.ParentAircraftId);
			var groupName = "Detail";

			var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(parentAircraft.AircraftFrameId);

			//TODO:(Evgenii Babak) пересмотреть использование ParenAircraftId здесь
			var aircraftRegAndFrameSn = $"{componentItem.GetParentAircraftRegNumber()} | {aircraftFrame} | {groupName}";
			destinationDataSet.
                Items.
                    AddItemsRow(ataCapter, description, remarks, "Work Type",
                                mansHours, groupName, cost, null, approxDate, null,
                                aircraftRegAndFrameSn);

        }

        #endregion

        #region protected void AddAdditionalDataToDataSet(DirectiveListReportDataSet destinationDateSet, bool addRegistrationNumber)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        private void AddAdditionalDataToDataSet(ForecastListDataSet destinationDateSet)
        {
            string reportHeader;
            string forecastDate = SmartCore.Auxiliary.Convert.GetDateFormat(_forecastData.ForecastDate);
            string forecastUtilization;

            if (_forecastData.AverageUtilization.SelectedInterval == UtilizationInterval.Dayly)
            {
                forecastUtilization = _forecastData.AverageUtilization.Hours+" FH/DAY " +
                                      _forecastData.AverageUtilization.Cycles+" FC/DAY";
            }
            else
            {
                forecastUtilization = _forecastData.AverageUtilization.Hours + " FH/MONTH " +
                                      _forecastData.AverageUtilization.Cycles + " FC/MONTH";
            }
            _forecastDateAndUtilizationData = "Calculated to " + forecastDate + "with Aver.Utiliz: " + forecastUtilization;
            
            DateAsOf = SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);

            reportHeader = "ForeCast List ";
            if (_isFiltered)
                reportHeader += ". Filtered";
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.
                AdditionalDataTAble.
                    AddAdditionalDataTAbleRow(GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == _reportedAircrafts[0].OperatorId).LogoTypeWhite,
			reportHeader, _forecastDateAndUtilizationData, DateAsOf, "MYMANSHOURS", reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #endregion

    }
}