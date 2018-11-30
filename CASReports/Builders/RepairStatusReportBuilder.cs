/*using System;
using Auxiliary;
using CAS.Core.Types.Directives;
using CASReports.Builders;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CAS.Core.Types.ReportFilters;

namespace CASReports.Builders
{
    /// <summary>
    /// Построение отчета AD Status
    /// </summary>
    public class RepairStatusReportBuilder : DirectiveListReportBuilder
    {

        #region Fileds

        private readonly RepairFilter defaultFilter = new RepairFilter();

        #endregion
        
        #region Constructor

        /// <summary>
        /// Создается объект для создания отчетов. Изначально пустой
        /// </summary>
        public RepairStatusReportBuilder()
        {
            ReportTitle = "Repair Status";
        }

        #endregion
        
        #region Properties
        
        /// <summary>
        /// Фильтр по умолчанию
        /// </summary>
        public override DirectiveFilter DefaultFilter
        {
            get
            {
                return defaultFilter;
            }
        }
        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            RepairStatusReport report = new RepairStatusReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected override void AddDirectivesToDataSet(DirectiveListReportDataSet dataset)

        protected override void AddDirectivesToDataSet(DirectiveListReportDataSet dataset)
        {
            ReportedDirectives.Sort(new ATAChapterComparer());
            for (int i = 0; i < ReportedDirectives.Count; i++)
            {
                AddDirectiveToDataset(ReportedDirectives[i], dataset);
            }
        }

        #endregion

        #region public override void AddDirectiveToDataset(BaseDetailDirective directive, DirectiveListReportDataSet destinationDataSet)

        public override void AddDirectiveToDataset(BaseDetailDirective directive, DirectiveListReportDataSet destinationDataSet)
        {
            if (!DefaultFilter.Acceptable(directive))
                return;
            string title = directive.Title;
            string references = directive.References;
            string subject = directive.Description;
            string repeatIntervals = "";
            if (!directive.Closed)
                repeatIntervals = LifelengthFormatter.GetData(directive.RepeatPerform, " hrs\r\n", " cyc\r\n", " day");
            string compliance = LifelengthFormatter.GetData(directive.LastPerformanceLifelength, " hrs\r\n", " cyc\r\n", "");
            string complianceDate = "";
            if (directive.LastPerformance != null)
                complianceDate = UsefulMethods.NormalizeDate(directive.LastPerformance.RecordDate);
            string nextLifelength = LifelengthFormatter.GetData(directive.NextPerformance, " hrs\r\n", " cyc\r\n", "");
            string nextDate = UsefulMethods.NormalizeDate(directive.NextPerformanceDate);
            string remains = LifelengthFormatter.GetData(directive.LeftTillNextPerformance, " hrs\r\n", " cyc\r\n", "day");
            string remarks = directive.Remarks;
            if (directive.LastPerformance != null && directive.LastPerformance.Description != "")
            {
                if (remarks != "")
                    remarks += "." + Environment.NewLine + directive.GetLastPerformance().Description;
                else
                    remarks += directive.GetLastPerformance().Description;
            }
            string conditionState = directive.Condition.GetHashCode().ToString();
            destinationDataSet.ItemsTable.AddItemsTableRow(directive.ID, "", remarks, subject, title, references, "", "",
                                                           "", "", repeatIntervals, compliance, complianceDate, nextLifelength, nextDate, remains, conditionState, "",
                                                           directive.AtaChapter.ShortName, directive.AtaChapter.FullName, "","");
        }

        #endregion

        #endregion
    }
}*/