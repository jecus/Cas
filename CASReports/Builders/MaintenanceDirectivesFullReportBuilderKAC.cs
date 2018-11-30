using Auxiliary;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CASReports.Builders
{
    public class MaintenanceDirectivesReportBuilderKAC : MaintenanceDirectivesFullReportBuilder
    {

        public MaintenanceDirectivesReportBuilderKAC()
        {
            ReportTitle = "AMP Tasks Status";
        }

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            MaintenanceDirectiveFullReportKAC report = new MaintenanceDirectiveFullReportKAC();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected override void AddDirectiveToDataset(object directive, DefferedListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="reportedDirective">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected override void AddDirectiveToDataset(MaintenanceDirective reportedDirective, MaintenanceDirectivesDataSet destinationDataSet)
        {
            if (reportedDirective == null)
                return;

            string status = "";
            Lifelength used = Lifelength.Null;

            //string remarks = reportedDirective.LastPerformance != null ? reportedDirective.LastPerformance.Remarks : reportedDirective.Remarks;
            string remarks = reportedDirective.Remarks;
            string directiveType = reportedDirective.WorkType.ShortName;
            double cost = reportedDirective.Cost;
            double mh = reportedDirective.ManHours;
            if (reportedDirective.Status == DirectiveStatus.Closed) status = "C";
            if (reportedDirective.Status == DirectiveStatus.Open) status = "O";
            if (reportedDirective.Status == DirectiveStatus.Repetative) status = "R";
            if (reportedDirective.Status == DirectiveStatus.NotApplicable) status = "N/A";

            string effectivityDate = UsefulMethods.NormalizeDate(reportedDirective.Threshold.EffectiveDate);
            string kits = "";
            int num = 1;
            foreach (AccessoryRequired kit in reportedDirective.Kits)
            {
                kits += num + ": " + kit.PartNumber + "\n";
                num++;
            }

            //расчет остатка с даты производства и с эффективной даты
            //расчет остатка от выполнения с даты производтсва
            string firstPerformanceString = "";
            string repeatPerformanceToString = reportedDirective.Threshold.RepeatPerformanceToStrings();

            if (reportedDirective.LastPerformance != null)
            {
                used.Add(Current);
                used.Substract(reportedDirective.LastPerformance.OnLifelength);
                if (!reportedDirective.Threshold.RepeatInterval.IsNullOrZero())
                    used.Resemble(reportedDirective.Threshold.RepeatInterval);
                else if (!reportedDirective.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                    used.Resemble(reportedDirective.Threshold.FirstPerformanceSinceNew);
            }
            else
            {
                firstPerformanceString = reportedDirective.Threshold.FirstPerformanceToStrings();    
            }

            destinationDataSet.ItemsTable.AddItemsTableRow(reportedDirective.Applicability,
                                                           remarks,
                                                           reportedDirective.HiddenRemarks,
                                                           reportedDirective.Description.Replace("\r\n", " "),
                                                           reportedDirective.TaskNumberCheck,
                                                           reportedDirective.Access,
                                                           directiveType,
                                                           status,
                                                           effectivityDate,
                                                           firstPerformanceString,
                                                           reportedDirective.LastPerformance != null ? reportedDirective.LastPerformance.ToStrings() : "",
                                                           reportedDirective.NextPerformance != null ? reportedDirective.NextPerformance.ToStrings() : "",
                                                           reportedDirective.Remains.ToStrings(),
                                                           reportedDirective.Condition.ToString(),
                                                           mh,
                                                           cost,
                                                           kits,
                                                           reportedDirective.Zone,
                                                           reportedDirective.ATAChapter != null ? reportedDirective.ATAChapter.ShortName : "",
                                                           reportedDirective.ATAChapter != null ? reportedDirective.ATAChapter.FullName : "",
                                                           reportedDirective.TaskCardNumber,
                                                           reportedDirective.Program.ToString(),
                                                           repeatPerformanceToString,
                                                           used.ToStrings(),
                                                           reportedDirective.MaintenanceCheck != null ? reportedDirective.MaintenanceCheck.ToString() : "N/A");
        }

        #endregion

        #endregion

    }
}