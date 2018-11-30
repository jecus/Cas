using System;
using System.Collections.Generic;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Directives;
using LTRReports.Datasets;
using LTRReports.ReprotTemplates;

namespace LTRReports
{
    /// <summary>
    /// Класс, для построения отчетов отклонений
    /// </summary>
    public class DiscrepanciesReportBuilder
    {
        #region Fields
        /// <summary>
        /// Список отклонений - агрегатов
        /// </summary>
        List<Detail> detailDiscrepancies = new List<Detail>();
        /// <summary>
        /// Заголовок отклонений по агрегатам
        /// </summary>
        private string detailDiscrepanciesTitle;
        /// <summary>
        /// Отображаются ли отклонения агрегатов
        /// </summary>
        private bool displayDetailDiscrepancies = false;
        /// <summary>
        /// Список групп отклонений по директивам
        /// </summary>
        List<Directive[]> directiveDiscrepancies = new List<Directive[]>();
        /// <summary>
        /// Заголовоки групп отклонений по директивам
        /// </summary>
        private List<string> containerTitles = new List<string>();
        /// <summary>
        /// Отображать ли отклонения директив
        /// </summary>
        List<bool> displayDirectiveDiscrepancies = new List<bool>();
        /// <summary>
        /// Значение пороговой выборки
        /// </summary>
        private Lifelength thresholdLifelength;
        /// <summary>
        /// Значение Date As Of
        /// </summary>
        private DateTime dateAsOf;
        /// <summary>
        /// Заголовок отчета
        /// </summary>
        private string reportTitle = "Discrepancies report";

        #endregion

        #region Constructors

        /// <summary>
        /// Создается построение отчетов отклонений
        /// </summary>
        /// <param name="thresholdLifelength">Пороговая выборка</param>
        /// <param name="dateAsOf">Дата на которую был создан отчет</param>
        public DiscrepanciesReportBuilder(Lifelength thresholdLifelength, DateTime dateAsOf)
        {
            this.thresholdLifelength = thresholdLifelength;
            this.dateAsOf = dateAsOf;
        }

        /// <summary>
        /// Создается построение отчетов отклонений
        /// </summary>
        /// <param name="thresholdLifelength">Пороговая выборка</param>
        /// <param name="dateAsOf">Дата на которую был создан отчет</param>
        /// <param name="detailDiscrepancies">Отклонения по агрегатам</param>
        /// <param name="detailDiscrepanciesTitle">Заголовок отклонений по агрегатам</param>
        /// <param name="directiveDiscrepancies">Отклонения по директивам</param>
        /// <param name="directiveDiscrepanciesTitles">Заголовки отклонений по директивам</param>
        public DiscrepanciesReportBuilder(Lifelength thresholdLifelength, DateTime dateAsOf, Detail[] detailDiscrepancies, string detailDiscrepanciesTitle, Directive[][] directiveDiscrepancies, string[] directiveDiscrepanciesTitles):this(thresholdLifelength, dateAsOf)
        {
            this.detailDiscrepanciesTitle = detailDiscrepanciesTitle;
            this.detailDiscrepancies.AddRange(detailDiscrepancies);
            this.directiveDiscrepancies.AddRange(directiveDiscrepancies);
            this.containerTitles.AddRange(directiveDiscrepanciesTitles);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Список отклонений - агрегатов
        /// </summary>
        public List<Detail> DetailDiscrepancies
        {
            get { return detailDiscrepancies; }
        }

        /// <summary>
        /// Заголовок отклонений по агрегатам
        /// </summary>
        public string DetailDiscrepanciesTitle
        {
            get { return detailDiscrepanciesTitle; }
            set { detailDiscrepanciesTitle = value; }
        }

        /// <summary>
        /// Список групп отклонений по директивам
        /// </summary>
        public List<Directive[]> DirectiveDiscrepancies
        {
            get { return directiveDiscrepancies; }
        }

        /// <summary>
        /// Заголовоки групп отклонений по директивам
        /// </summary>
        public List<string> ContainerTitles
        {
            get { return containerTitles; }
        }

        /// <summary>
        /// Значение пороговой выборки
        /// </summary>
        public Lifelength ThresholdLifelength
        {
            get { return thresholdLifelength; }
            set { thresholdLifelength = value; }
        }

        /// <summary>
        /// Значение Date As Of
        /// </summary>
        public DateTime DateAsOf
        {
            get { return dateAsOf; }
            set { dateAsOf = value; }
        }

        /// <summary>
        /// Заголовок отчета
        /// </summary>
        public string ReportTitle
        {
            get { return reportTitle; }
            set { reportTitle = value; }
        }

        /// <summary>
        /// Отображаются ли отклонения агрегатов
        /// </summary>
        public bool DisplayDetailDiscrepancies
        {
            get { return displayDetailDiscrepancies; }
            set { displayDetailDiscrepancies = value; }
        }

        /// <summary>
        /// Отображать ли отклонения директив
        /// </summary>
        public List<bool> DisplayDirectiveDiscrepancies
        {
            get { return displayDirectiveDiscrepancies; }
        }

        #endregion

        #region Methods

        #region public DiscrepanciesReport CreateReport()

        /// <summary>
        /// Создается отчет
        /// </summary>
        /// <returns></returns>
        public DiscrepanciesReport CreateReport()
        {
            DiscrepanciesReport report = new DiscrepanciesReport();
            report.SetDataSource(CreateDataSet());
            return report;
        }

        #endregion

        #region public DiscrepanciesDataSet CreateDataSet()

        /// <summary>
        /// Создается DataSet для заданных данных
        /// </summary>
        /// <returns></returns>
        public DiscrepanciesDataSet CreateDataSet()
        {
            DiscrepanciesDataSet dataSet = new DiscrepanciesDataSet();
            FillDataSet(dataSet);
            return dataSet;
        }

        #endregion

        #region public void FillDataSet(DiscrepanciesDataSet dataSet)

        /// <summary>
        /// Заполняется DataSet
        /// </summary>
        /// <param name="dataSet"></param>
        public void FillDataSet(DiscrepanciesDataSet dataSet)
        {
            dataSet.Clear();
            dataSet.AdditionalDataTable.AddAdditionalDataTableRow(1, dateAsOf.ToString("MMM dd yyyy"), reportTitle,
                                                                  thresholdLifelength.ToString());
            FillDetailDiscrepancies(dataSet);
            FillDirectiveDiscrepancies(dataSet);
        }

        #endregion

        #region public void FillDirectiveDiscrepancies(DiscrepanciesDataSet dataSet)

        /// <summary>
        /// Заполняются отклонения по директивам
        /// </summary>
        /// <param name="dataSet"></param>
        public void FillDirectiveDiscrepancies(DiscrepanciesDataSet dataSet)
        {
            int index = 1;
            if (displayDetailDiscrepancies)
                index = 2;
            int counter = detailDiscrepancies.Count;
            for (int i = 0; i < directiveDiscrepancies.Count; i++)
            {
                Directive[] directives = directiveDiscrepancies[i];
                string title = "Directive discrepancies.";
                bool display = false;
                if (containerTitles.Count > i)
                    title = containerTitles[i];
                if (displayDirectiveDiscrepancies.Count > i)
                    display = displayDirectiveDiscrepancies[i];
                if (display)
                {
                    DiscrepanciesDataSet.DiscrepanciesContainersTableRow containerRow = dataSet.DiscrepanciesContainersTable.AddDiscrepanciesContainersTableRow(index, title);
                    for (int j = 0; j < directives.Length; j++)
                    {
                        Directive directive = directives[j];
                        counter++;
                        string itemTitle = directive.Title;
                        string description = directive.Description;
                        string nextLifelength = directive.NextPerformance.ToString();
                        string nextDate = directive.NextPerformance.ToCalendarString();
                        string remains = directive.LeftTillNextPerformance.ToString();
                        string workType = "Perform";
                        dataSet.DiscrepanciesTable.AddDiscrepanciesTableRow(counter, j, itemTitle, description,
                                                                            nextLifelength, nextDate, remains, workType,
                                                                            containerRow);
                    }
                }
            }
        }

        #endregion

        #region public void FillDetailDiscrepancies(DiscrepanciesDataSet dataSet)

        /// <summary>
        /// Добавляются элементы отклонений по агрегатам
        /// </summary>
        /// <param name="dataSet"></param>
        public void FillDetailDiscrepancies(DiscrepanciesDataSet dataSet)
        {
            if (!displayDetailDiscrepancies)
                return;
            DiscrepanciesDataSet.DiscrepanciesContainersTableRow container = dataSet.DiscrepanciesContainersTable.AddDiscrepanciesContainersTableRow(1, detailDiscrepanciesTitle);
            for (int i = 0; i < detailDiscrepancies.Count; i++)
            {
                Detail detail = (Detail) detailDiscrepancies[i];
                string title = detail.SerialNumber;
                string description = detail.Description;
                string nextLifelength = detail.Limitation.NextPerformance.ToString();
                string nextDate = detail.Limitation.NextPerformance.ToCalendarString();
                string remains = detail.Limitation.LeftTillNextPerformance.ToString();
                string workType = "";
                if (detail.Limitation.NextWorkType != null) 
                    workType = detail.Limitation.NextWorkType.ShortName;
                dataSet.DiscrepanciesTable.AddDiscrepanciesTableRow(i, i, title, description, nextLifelength, nextDate,
                                                                    remains, workType, container);
            }
        }

        #endregion

        #endregion


    }
}
