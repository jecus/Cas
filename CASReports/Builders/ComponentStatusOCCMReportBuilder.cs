using Auxiliary;
using CASTerms;

using CASReports.Datasets;
using CASReports.ReportTemplates;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета для ComponentStatus OCCM
    /// </summary>
    public abstract class ComponentStatusOCCMReportBuilder : DetailListReportBuilder
    {

        #region Constructors

        #region public ComponentStatusOCCMReportBuilder()

        public ComponentStatusOCCMReportBuilder()
        {
            ReportTitle = "OC/CM Component Status";
        }

        #endregion


        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            ComponentStatusOCCMReport report = new ComponentStatusOCCMReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected override void AddDetailToDataset(Detail detail, ref int previousNumber, DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="componentобавляемый агрегат</param>
        /// <param name="previousNumber">Порядковый номер агрегата</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected override void AddDetailToDataset(Component component, ref int previousNumber, DetailListDataSet destinationDataSet)
        {
            var ata =component.ATAChapter;
            var atachapter = ata.ShortName;
            var componentNumber = (previousNumber++).ToString();
            var atachapterfull = ata.FullName;
            var partNumber = component.PartNumber;
            var description = component.Description;
            var serialNumber = component.SerialNumber;
	        var lastTransferRecord = component.TransferRecords.GetLast();
            var positionNumber = lastTransferRecord.Position;
            var instalationDate = UsefulMethods.NormalizeDate(lastTransferRecord.TransferDate);
			var installationLifelength = lastTransferRecord.OnLifelength;
			var remarks = component.Remarks;
            GlobalObjects.PerformanceCalculator.GetNextPerformance(component);
            var current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(component);
            var installationTsncsn = LifelengthFormatter.GetHoursData(installationLifelength, " hrs\r\n") +
                                     LifelengthFormatter.GetCyclesData(installationLifelength, " cyc\r\n");
            var currentTsncsn = LifelengthFormatter.GetHoursData(current, " hrs\r\n") +
                                LifelengthFormatter.GetCyclesData(current, " cyc\r\n");
            var condition = component.Condition.GetHashCode().ToString();
            var lifelengthAircraftTime = current;
            lifelengthAircraftTime.Substract(installationLifelength);
            var aircraftTime = LifelengthFormatter.GetHoursData(lifelengthAircraftTime, " hrs\r\n") +
                               LifelengthFormatter.GetCyclesData(lifelengthAircraftTime, " cyc\r\n");

            destinationDataSet.ItemsTable.AddItemsTableRow(componentNumber, atachapter, atachapterfull, partNumber, description, serialNumber, positionNumber, "",
                                                           instalationDate, "", "", "", "", "",
                                                           "", "", condition, aircraftTime, "", "", "", "", "", "",
                                                           installationTsncsn, remarks, currentTsncsn);
            

        }

        #endregion

        #endregion

    }
}