using System;
using System.Collections.Generic;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.ReportFilters;
using LTR.Settings;
using LTRReports.Datasets;
using LTRReports.ReprotTemplates;

namespace LTRReports
{
    /// <summary>
    /// 
    /// </summary>
    public class DetailListReportBuilder
    {
        #region Fields
        /// <summary>
        /// Формировщик вывода информации о наработке
        /// </summary>
        LifelengthFormatter lifelengthFormatter = new LifelengthFormatter();
        /// <summary>
        /// Оператор ВС
        /// </summary>
        private Operator reportedOperator;
        /// <summary>
        /// ВС для которого генерируется отчет
        /// </summary>
        private Aircraft reportedAircraft;
        /// <summary>
        /// Список агрегатов для которых генерируется отчет
        /// </summary>
        private List<Detail> reportedDetails = new List<Detail>();

        private string dateAsOfData = "Print date";

        AllDetailFilter defaultFilter = new AllDetailFilter();
        private string model = "";

        #endregion

        #region Constructors

        #region public DetailListReportBuilder(Aircraft reportedAircraft , Detail[] details, string dateAsOf)

        /// <summary>
        /// Создается объект для создания отчетов компонент для заданного ВС
        /// </summary>
        /// <param name="reportedAircraft">Элемент для которого создается отчет</param>
        /// <param name="details">Список агрегатов для отображения</param>
        /// <param name="dateAsOf">Дата создания отчета</param>
        public DetailListReportBuilder(Aircraft reportedAircraft , Detail[] details, string dateAsOf)
        {
            dateAsOfData = dateAsOf;
            Add(reportedAircraft.Operator);
            Add(reportedAircraft);
            Add(details);
        }

        #endregion

        #region public DetailListReportBuilder()

        /// <summary>
        /// Создается объект для создания отчетов. Изначально пустой
        /// </summary>
        public DetailListReportBuilder()
        {
        }

        #endregion

        #endregion

        #region Properties

        #region public Operator ReportedOperator

        /// <summary>
        /// Оператор ВС
        /// </summary>
        public Operator ReportedOperator
        {
            get { return reportedOperator; }
        }

        #endregion

        #region public Aircraft ReportedAircraft

        /// <summary>
        /// ВС для которого генерируется отчет
        /// </summary>
        public Aircraft ReportedAircraft
        {
            get { return reportedAircraft; }
        }

        #endregion

        #region public string DateAsOf

        /// <summary>
        /// Текст поля DateAsOf
        /// </summary>
        public string DateAsOfData
        {
            get { return dateAsOfData; }
            set { dateAsOfData = value; }
        }

        #endregion

        #region public virtual string ReportTitle

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public virtual string ReportTitle
        {
            get { return "Component Status list report"; }
        }

        #endregion

        #region public virtual DetailFilter DefaultFilter

        /// <summary>
        /// Фильтр по умолчанию
        /// </summary>
        public virtual DetailFilter DefaultFilter
        {
            get
            {
                return defaultFilter;
            }
        }

        #endregion

        #region public string Model

        /// <summary>
        /// Текст - модель отображаемого элемента и дополнительный параметры
        /// </summary>
        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        #endregion

        #endregion
        
        #region Methods

        #region public void AddResources(Aircraft aircraft, Detail[] details, string dateAsOf)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="aircraft">Элемент для которого создается отчет</param>
        /// <param name="details">Список агрегатов для отображения</param>
        /// <param name="dateAsOf">Дата создания отчета</param>
        public void AddResources(Aircraft aircraft, Detail[] details, string dateAsOf)
        {
            dateAsOfData = dateAsOf;
            Add(aircraft.Operator);
            Add(aircraft);
            Add(details);
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
            if (reportedAircraft == aircraft) return;
            reportedAircraft = aircraft;
        }

        #endregion

        #region public void Add(Operator _operator)
        /// <summary>
        /// Добавление оператора
        /// </summary>
        /// <param name="_operator">Оператор</param>
        public void Add(Operator _operator)
        {
            if (_operator == null) return;
            if (reportedOperator == _operator) return;
            reportedOperator = _operator;
        }
        #endregion

        #region public void Add(Detail detail)
        /// <summary>
        /// Добавления агрегата в список
        /// </summary>
        /// <param name="detail">агрегат</param>
        public void Add(Detail detail)
        {
            if (detail == null) return;
            if (reportedDetails.Contains(detail)) return;
            reportedDetails.Add(detail);
        }
        #endregion

        #region public void Add(Detail[] details)
        /// <summary>
        /// Добавления деталей
        /// </summary>
        /// <param name="details">массив деталей</param>
        public void Add(Detail[] details)
        {
            foreach (Detail detail in details)
            {
                Add(detail);
            }
        }
        #endregion

        #region public ComponentStatusReport GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public ComponentStatusReport GenerateReport()
        {
            ComponentStatusReport report = new ComponentStatusReport();
            report.SetDataSource(GenerateDataSet());
                return report;
        }

        #endregion

        #region public DetailListDataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        public DetailListDataSet GenerateDataSet()
        {
            DetailListDataSet dataset = new DetailListDataSet();
            AddOperatorToDataset(dataset);
            AddAircraftToDataset(dataset);
            AddDetailsToDataset(dataset);
            AddAdditionalInformation(dataset);
            return dataset;
        }

        #endregion

        #region protected void AddAdditionalInformation(DetailListDataSet destinationDateSet)
        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        protected void AddAdditionalInformation(DetailListDataSet destinationDateSet)
        {
            destinationDateSet.AdditionalDataTable.AddAdditionalDataTableRow(0, ReportTitle, dateAsOfData,
                                                                             ProgramSettings.ReportFooter,
                                                                             ProgramSettings.ReportFooterPrepared,
                                                                             ProgramSettings.WebSite);
        }
        #endregion

        #region protected void AddOperatorToDataset(DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется оператора в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected virtual void AddOperatorToDataset(DetailListDataSet destinationDataSet)
        {
            destinationDataSet.OperatorInfomationTable.AddOperatorInfomationTableRow(reportedOperator.ID, reportedOperator.Name, reportedOperator.ICAOCode);
        }

        #endregion

        #region protected virtual void AddAircraftToDataset(DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected virtual void AddAircraftToDataset(DetailListDataSet destinationDataSet)
        {
            int operatorId = destinationDataSet.OperatorInfomationTable.FindByOperatorId(reportedAircraft.Parent.ID).OperatorId;
            string registrationNumber = reportedAircraft.RegistrationNumber;
            string serialNumber = reportedAircraft.SerialNumber;
            string manufactureDate = reportedAircraft.ManufactureDate.ToString("MMM dd, yyyy");
            string lineNumber = "";
            string variableNumber = "";
            string SinceNewHours = lifelengthFormatter.GetHoursData(reportedAircraft.Limitation.ResourceSinceNew.Hours).Trim();
            int sinceNewCycles = reportedAircraft.Limitation.ResourceSinceNew.Cycles;
            string SinceOverhaulHours = lifelengthFormatter.GetHoursData(reportedAircraft.Limitation.ResourceSinceOverhaul.Hours).Trim();
            int sinceOverhaulCycles = reportedAircraft.Limitation.ResourceSinceOverhaul.Cycles;
            if (reportedAircraft is WestAircraft)
            {
                lineNumber = ((WestAircraft)reportedAircraft).LineNumber;
                variableNumber = ((WestAircraft)reportedAircraft).VariableNumber;
            }
            string model = reportedAircraft.Model;
            destinationDataSet.AircraftInformationTable.AddAircraftInformationTableRow(reportedAircraft.ID, operatorId, registrationNumber, serialNumber,
                                                                     manufactureDate, lineNumber, variableNumber, SinceNewHours,  sinceNewCycles,  SinceOverhaulHours, sinceOverhaulCycles, model);
        }

        #endregion

        #region protected virtual void AddDetailToDataset(Detail detail, DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="detail">Добавляемый агрегат</param>
        /// <param name="number">Порядковый номер агрегата</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected virtual void AddDetailToDataset(Detail detail,int number,DetailListDataSet destinationDataSet)
        {
            if (!DefaultFilter.Acceptable(detail))
                return;
            int aircraftId = ReportedAircraft.ID;
            string atachapter = detail.AtaChapter.ShortName;
            string componentNumber = number.ToString();
            string atachapterfull = detail.AtaChapter.FullName;
            string partNumber = detail.PartNumber;
            string description = detail.Description;
            string serialNumber = detail.SerialNumber;
            string positionNumber = detail.PositionNumber;
            string maintanceType = detail.MaintenanceType.ShortName;
            string instalationDate = detail.InstallationDate.ToString("MMM dd, yyyy");
            string complianceTSN = "";
            string complianceDate = "";
            string complianceWorkType = "";
            if (detail.Limitation.LastPerformance != null)
            {
                complianceTSN = lifelengthFormatter.GetData(detail.Limitation.LastPerformance.Lifelength, "h\r\n", "cyc\r\n", "");
                DateTime tempDateTime = new DateTime(detail.Limitation.LastPerformance.Lifelength.Calendar.Ticks);
                complianceDate = tempDateTime.ToString("MMM dd, yyyy");
                complianceWorkType = detail.Limitation.LastPerformance.DetailRecordType.ShortName;
            }
            string nextTSN = "";
            string nextDate = "";
            string nextRemains = "";
            string nextWorkType = "";
            if (detail.Limitation.NextPerformance !=null)
            {
                
            }
            string condition = detail.LimitationCondition.GetHashCode().ToString();
            

            destinationDataSet.ItemsTable.AddItemsTableRow(detail.ID,aircraftId, componentNumber,
                                                           atachapter, atachapterfull, partNumber, description,
                                                           serialNumber, positionNumber,
                                                           maintanceType,
                                                           instalationDate,
                                                           complianceTSN,
                                                           complianceDate,
                                                           complianceWorkType, nextTSN, 
                                                               nextDate,
                                                               nextRemains,
                                                               nextWorkType,condition);
        }

        #endregion

        #region protected virtual void AddDetailsToDataset(DetailListDataSet dataset)

        /// <summary>
        /// Добавление базовых агрегатов в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        protected virtual void AddDetailsToDataset(DetailListDataSet dataset)
        {
            for (int i = 0; i < reportedDetails.Count; i++)
            {
                AddDetailToDataset(reportedDetails[i] ,i+1, dataset);
            }
        }

        #endregion

        #region public void Clear()

        /// <summary>
        /// Очистка содержащихся элементов
        /// </summary>
        public void Clear()
        {        
            reportedDetails.Clear();
        }

        #endregion
        
        
        #endregion
        
    }
}
