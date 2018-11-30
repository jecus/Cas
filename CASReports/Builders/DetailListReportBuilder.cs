using System.Collections.Generic;
using System.Linq;
using Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета для списка агрегатов
    /// </summary>
    public class DetailListReportBuilder : AbstractReportBuilder
    {

        #region Fields

        /// <summary>
        /// Формировщик вывода информации о наработке
        /// </summary>
        protected LifelengthFormatter LifelengthFormatter = new LifelengthFormatter();
        /// <summary>
        /// Оператор ВС
        /// </summary>
        private Operator _reportedOperator;
        /// <summary>
        /// ВС для которого генерируется отчет
        /// </summary>
        private Aircraft _reportedAircraft;

        /// <summary>
        /// Список агрегатов для которых генерируется отчет
        /// </summary>
        private readonly List<Component> _reportedDetails = new List<Component>();

        private string _dateAsOfData = "Print date";

        private string _reportTitle = "Component Status";
        private string _reportType = "Component Status";
        private bool _isFiltered;
        private string _model = "";

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #region public Operator ReportedOperator

        /// <summary>
        /// Оператор ВС
        /// </summary>
        public Operator ReportedOperator
        {
            get { return _reportedOperator; }
        }

        #endregion

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС для которого генерируется отчет
        /// </summary>
        public Aircraft ReportedAircraft
        {
            get { return _reportedAircraft; }
        }

        #endregion

        #region public List<Detail> ReportedDetails

        /// <summary>
        /// Список агрегатов для которых генерируется отчет
        /// </summary>
        public List<Component> ReportedDetails
        {
            get { return _reportedDetails; }
        }

        #endregion
        
        #region public string DateAsOf

        /// <summary>
        /// Текст поля DateAsOf
        /// </summary>
        public string DateAsOfData
        {
            get { return _dateAsOfData; }
            set { _dateAsOfData = value; }
        }

        #endregion

        #region public string ReportTitle

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public string ReportTitle
        {
            get
            {
                return _reportTitle;
            }
            set
            {
                _reportTitle = value;
            }
        }

        #endregion

        #region public string ReportType
        /// <summary>
        /// Тип отчета
        /// </summary>
        public string ReportType
        {
            get { return _reportType; }
            set { _reportType = value; }
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

        #region public string Model

        /// <summary>
        /// Текст - модель отображаемого элемента и дополнительный параметры
        /// </summary>
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        #endregion

        #endregion
        
        #region Methods

        #region public void AddResources(Aircraft aircraft, Detail[] details, string dateAsOf)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aircraft">Элемент для которого создается отчет</param>
        /// <param name="componentsписок агрегатов для отображения</param>
        /// <param name="dateAsOf">Дата создания отчета</param>
        public void AddResources(Aircraft aircraft, Component[] components, string dateAsOf)
        {
            Clear();
            _dateAsOfData = dateAsOf;
            Add(GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId));
            Add(aircraft);
            Add(components);
        }
        #endregion

        #region public void Add(Aircraft aircraft)
        /// <summary>
        /// Добавление воздушного судна
        /// </summary>
        /// <param name="aircraft">ВС</param>
        public void Add(Aircraft aircraft)
        {
            if (aircraft == null) return;
            if (_reportedAircraft == aircraft) return;
            _reportedAircraft = aircraft;
        }

        #endregion

        #region public void Add(Operator _operator)
        /// <summary>
        /// Добавление оператора
        /// </summary>
        /// <param name="operator">Оператор</param>
        private void Add(Operator @operator)
        {
            if (@operator == null) return;
            if (_reportedOperator == @operator) return;
            _reportedOperator = @operator;
        }
        #endregion

        #region public void Add(Detail detail)
        /// <summary>
        /// Добавления агрегата в список
        /// </summary>
        /// <param name="componentгрегат</param>
        public void Add(Component component)
        {
            if (component == null) return;
            if (_reportedDetails.Contains(component)) return;
            _reportedDetails.Add(component);
        }
        #endregion

        #region public void Add(Detail[] details)
        /// <summary>
        /// Добавления деталей
        /// </summary>
        /// <param name="componentsассив деталей</param>
        public void Add(Component[] components)
        {
            foreach (Component detail in components)
            {
                Add(detail);
            }
        }
        #endregion

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            ComponentStatusReport report = new ComponentStatusReport();
            report.SetDataSource(GenerateDataSet());
            return report;

        }

        #endregion

        #region public virtual DetailListDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public virtual DetailListDataSet GenerateDataSet()
        {
            DetailListDataSet dataset = new DetailListDataSet();
            AddOperatorToDataset(dataset);
            AddAircraftToDataset(dataset);
            AddDetailsToDataset(dataset);
            AddAdditionalInformation(dataset, true);
            return dataset;
        }

        #endregion

        #region protected void AddAdditionalInformation(DetailListDataSet destinationDateSet, bool addRegistrationNumber)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        /// <param name="addRegistrationNumber">Добавлять ли регистрационный номер ВС в название отчета</param>
        protected void AddAdditionalInformation(DetailListDataSet destinationDateSet, bool addRegistrationNumber)
        {
            string reportHeader = ReportTitle;
            if (addRegistrationNumber) 
                reportHeader = _reportedAircraft.RegistrationNumber + ". " + ReportTitle;
            if (_isFiltered)
                reportHeader += ". Filtered";
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ReportFooterLink"].ToString();
            destinationDateSet.AdditionalDataTable.AddAdditionalDataTableRow(ReportType , reportHeader, _dateAsOfData, reportFooter,
                                                                             reportFooterPrepared, reportFooterLink);
        }

        #endregion

        #region protected void AddOperatorToDataset(DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется оператора в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected virtual void AddOperatorToDataset(DetailListDataSet destinationDataSet)
        {
            destinationDataSet.OperatorInfomationTable.AddOperatorInfomationTableRow(_reportedOperator.Name, _reportedOperator.LogoTypeWhite);
        }

        #endregion

        #region protected virtual void AddAircraftToDataset(DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected void AddAircraftToDataset(DetailListDataSet destinationDataSet)
        {
            var registrationNumber = _reportedAircraft.RegistrationNumber;
            var serialNumber = _reportedAircraft.SerialNumber;
            var manufactureDate = _reportedAircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var lineNumberCaption = "";
            var variableNumberCaption = "";
            var lifelength = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(_reportedAircraft);
            var sinceNewHours = lifelength.Hours.ToString();
            var sinceNewCycles = lifelength.Cycles.ToString().Trim();
            string averageUtilizationHours; 
            string averageUtilizationCycles;
            string averageUtilizationHoursTitle;
            string averageUtilizationCyclesTitle;

			var aircraftFrame = GlobalObjects.ComponentCore.GetBaseComponentById(_reportedAircraft.AircraftFrameId);
			var averageUtilization = GlobalObjects.AverageUtilizationCore.GetAverageUtillization(aircraftFrame);
			if (averageUtilization.SelectedInterval == UtilizationInterval.Dayly)
            {
                averageUtilizationHoursTitle = "FH/DAY: ";
                averageUtilizationHours = averageUtilization.Hours.ToString();
                averageUtilizationCyclesTitle = "FC/DAY: ";
                averageUtilizationCycles = averageUtilization.Cycles.ToString();
            }
            else
            {
                averageUtilizationHoursTitle = "FH/MONTH: ";
                averageUtilizationHours = averageUtilization.Hours.ToString();
                averageUtilizationCyclesTitle = "FC/MONTH: ";
                averageUtilizationCycles = averageUtilization.Cycles.ToString();
            }

            /*if (reportedAircraft is AircraftProxy)
            {*/
            var lineNumber = (_reportedAircraft).LineNumber;
            var variableNumber = (_reportedAircraft).VariableNumber;
            if (lineNumber != "")
                lineNumberCaption = "L/N:";
            if (variableNumber != "")
                variableNumberCaption = "V/N:";
           /* }
            if (reportedAircraft is WestAircraft)
            {
                lineNumber = ((WestAircraft)reportedAircraft).LineNumber;
                variableNumber = ((WestAircraft)reportedAircraft).VariableNumber;
                if (lineNumber != "")
                    lineNumberCaption = "L/N:";
                if (variableNumber != "")
                    variableNumberCaption = "V/N:";
            }//todo что то надо сделать с этим...так не пойдет*/
            destinationDataSet.AircraftInformationTable.AddAircraftInformationTableRow(registrationNumber, 
                                                                                       serialNumber,
                                                                                       manufactureDate, 
                                                                                       lineNumberCaption, 
                                                                                       variableNumberCaption, 
                                                                                       lineNumber, 
                                                                                       variableNumber, 
                                                                                       sinceNewHours, 
                                                                                       sinceNewCycles, 
                                                                                       "", 
                                                                                       "", 
                                                                                       _reportedAircraft.Model.ToString(), 
                                                                                       averageUtilizationHours, 
                                                                                       averageUtilizationCycles,
                                                                                       averageUtilizationHoursTitle,
                                                                                       averageUtilizationCyclesTitle);
            
        }

        #endregion

        #region protected virtual void AddDetailToDataset(Detail detail, ref int previousNumber, DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="componentобавляемый агрегат</param>
        /// <param name="previousNumber">Порядковый номер агрегата</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected virtual void AddDetailToDataset(Component component, ref int previousNumber, DetailListDataSet destinationDataSet)
        {
            string atachapter;
            string componentNumber;
            string atachapterfull;
            string partNumber;
            string description;
            string serialNumber;
            string positionNumber;
            string maintanceType;
            string instalationDate;

            AtaChapter ata = component.ATAChapter;
            atachapter = ata.ShortName;
            componentNumber = (previousNumber++).ToString();
            atachapterfull = ata.FullName;
            partNumber = component.PartNumber;
            description = component.Description;
            serialNumber = component.SerialNumber;
            positionNumber = component.TransferRecords.Count > 0
                ? component.TransferRecords.GetLast().Position : "";
            maintanceType = "";//((Detail) detail).MaintenanceType.ShortName;
            instalationDate = component.TransferRecords.Count > 0
                ? UsefulMethods.NormalizeDate(component.TransferRecords.GetLast().TransferDate) : "";

            string complianceTSN = "";
            string complianceDate = "";
            string complianceWorkType = "";

     /*       if ((Deta)detail. != null)
            {
                complianceDate = UsefulMethods.NormalizeDate(detail.Limitation.LastPerformance.RecordDate);
                if (complianceDate != "")
                    complianceTSN = lifelengthFormatter.GetHoursData(detail.Limitation.LastPerformance.Lifelength, " hrs\r\n") +
                                    lifelengthFormatter.GetCyclesData(detail.Limitation.LastPerformance.Lifelength, " cyc\r\n");
                else
                    complianceTSN = lifelengthFormatter.GetData(detail.Limitation.LastPerformance.Lifelength, " hrs\r\n", " cyc\r\n", " day");
                complianceWorkType = detail.Limitation.LastPerformance.RecordType.ShortName;
            }*/

            string nextTSN = "";
            string nextDate ="";
            string nextRemains = "";
            string nextWorkType = "";
            
/*
            nextDate = UsefulMethods.NormalizeDate(detail.Limitation.NextDate);
            nextRemains = lifelengthFormatter.GetData(detail.Limitation.LeftTillNextPerformance, " hrs\r\n", " cyc\r\n", " day");
            if (detail.Limitation.NextPerformance != null)
            {
                if (nextDate != "")
                    nextTSN = lifelengthFormatter.GetHoursData(detail.Limitation.NextPerformance, " hrs\r\n") +
                              lifelengthFormatter.GetCyclesData(detail.Limitation.NextPerformance, " cyc\r\n");
                else
                    nextTSN = lifelengthFormatter.GetData(detail.Limitation.NextPerformance, " hrs\r\n", " cyc\r\n", " day");
            }
            if (detail.Limitation.NextWorkType != null)
            {
                nextWorkType = detail.Limitation.NextWorkType.ShortName;                
            }
*/

            GlobalObjects.PerformanceCalculator.GetNextPerformance(component);

            string condition = component.Condition.GetHashCode().ToString();


            destinationDataSet.ItemsTable.AddItemsTableRow(componentNumber,
                                                           atachapter, atachapterfull, partNumber, description,
                                                           serialNumber, positionNumber,
                                                           maintanceType,
                                                           instalationDate,
                                                           complianceTSN,
                                                           complianceDate,
                                                           complianceWorkType, nextTSN,
                                                           nextDate,
                                                           nextRemains,
                                                           nextWorkType, condition, "", "", "", "", "","", "", "", "", "");
        }

        #endregion

        #region protected virtual void AddDetailsToDataset(DetailListDataSet dataset)

        /// <summary>
        /// Добавление базовых агрегатов в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDetailsToDataset(DetailListDataSet dataset)
        {
            int number = 1;
            foreach (Component t in _reportedDetails)
            {
                AddDetailToDataset(t, ref number, dataset);
            }
        }

        #endregion

        #region public void Clear()

        /// <summary>
        /// Очистка содержащихся элементов
        /// </summary>
        public void Clear()
        {        
            _reportedDetails.Clear();
        }

        #endregion

        #region Перегрузка операторов сравнения

        #region public override bool Equals(object obj)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (IsFiltered != ((DetailListReportBuilder)obj)._isFiltered) return false;
            if (Model != ((DetailListReportBuilder)obj).Model) return false;
            if (ReportedAircraft!= ((DetailListReportBuilder)obj).ReportedAircraft) return false;
            if (ReportedOperator != ((DetailListReportBuilder)obj).ReportedOperator) return false;
            if (ReportTitle!= ((DetailListReportBuilder)obj).ReportTitle) return false;
            if (_reportedDetails.Count != ((DetailListReportBuilder)obj)._reportedDetails.Count) return false;
            return true;
        }
        #endregion

        #region public override int GetHashCode()
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
        #endregion

        #endregion

        #endregion
        
    }
}