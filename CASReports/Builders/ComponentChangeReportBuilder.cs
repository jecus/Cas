using CASReports.ReportTemplates;
using SmartCore.Entities.General;

namespace CASReports.Builders
{
    public class ComponentChangeReportBuilder : AbstractReportBuilder
    {
        #region Fields

        private readonly Aircraft _aircraft;

        private readonly TransferRecord[] _records;


        #endregion

        #region Constructor

        /// <summary>
        /// Создает построитель отчета по ComponentChangeReportBuilder
        /// </summary>
        /// <param name="aircraft"></param>
        public ComponentChangeReportBuilder(Aircraft aircraft, TransferRecord[] records)
        {
            _aircraft = aircraft;
            _records = records;
        }

        #endregion

        #region Methods

        #region public override object  GenerateReport()

        /// <summary>
        /// Создает отчет по данным, добавленным в текущий источник данных (DataSet)
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            ComponentChangeReport report = new ComponentChangeReport();
          //  report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private void AddGeneralInformation(ComponentChangeDataSet dataSet)

        //private void AddGeneralInformation(ComponentChangeDataSet dataSet)
        //{
        //    byte[] logotype = aircraft.Operator.LogoTypeWhite;
        //    GlobalTermsProvider provider = new GlobalTermsProvider();
        //    string dateAsOf = DateTime.Today.ToString(provider["DateFormat"].ToString());
        //    string reportFooter = provider["ReportFooter"].ToString();
        //    string reportFooterPrepeared = provider["ReportFooterPrepared"].ToString();
        //    string reportFooterLink = provider["ReportFooterLink"].ToString();

        //    dataSet.GeneralInformation.AddGeneralInformationRow(logotype, aircraft.RegistrationNumber, aircraft.Model,
        //                                                        dateAsOf, reportFooter, reportFooterPrepeared,
        //                                                        reportFooterLink);
        //}

        #endregion

        #region private void AddAircraftInformationToDataset(ComponentChangeDataSet destinationDataSet)

        //private void AddAircraftInformationToDataset(ComponentChangeDataSet destinationDataSet)
        //{
        //    LifelengthFormatter lifelengthFormatter = new LifelengthFormatter();
        //    string serialNumber = aircraft.SerialNumber;
        //    string manufactureDate = aircraft.ManufactureDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
        //    string registrationNumber = aircraft.RegistrationNumber;
        //    string SinceNewHours = lifelengthFormatter.GetHoursData(new TimeSpan((int)GlobalObjects.CasEnvironment.Calculator.GetLifelength(aircraft).Hours,0,0)).Trim();
        //    string sinceNewCycles =
        //        GlobalObjects.CasEnvironment.Calculator.GetLifelength(aircraft).Cycles.ToString().Trim();
        //    string lineNumber = "";
        //    string variableNumber = "";
        //    string lineNumberCaption = "";
        //    string variableNumberCaption = "";
        //        lineNumber = (aircraft).LineNumber;
        //        variableNumber = (aircraft).VariableNumber;
        //        if (lineNumber != "")
        //            lineNumberCaption = "L/N:";
        //        if (variableNumber != "")
        //            variableNumberCaption = "V/N:";
           
        //    destinationDataSet.AircraftInformationTable.AddAircraftInformationTableRow(registrationNumber, serialNumber,
        //                                                                               manufactureDate,
        //                                                                               lineNumberCaption,
        //                                                                               variableNumberCaption, lineNumber,
        //                                                                               variableNumber, SinceNewHours,
        //                                                                               sinceNewCycles);
        //}

        #endregion

        #region private void AddComponentChange(ComponentChangeDataSet dataSet)

        //private void AddComponentChange(ComponentChangeDataSet dataSet)
        //{
        //   for(int i=0;i<records.Length;i++)
        //   {
        //       AddItem(records[i],dataSet);
        //   }
        //}

        #endregion

        #region private void AddItem(detail item, ComponentChangeDataSet dataSet)

        // private void AddItem(TransferRecord item, ComponentChangeDataSet dataSet)
        //{
        //     Detail detail = (Detail) item.ParentDetail;
        //    string description = detail.Description + " " +
        //                             item.Position
        //                             + " P/N:" + detail.PartNumber + " S/N: " + detail.SerialNumber;
        //    if (isTransferContainerIdInBaseDetail(item.ParentID) ||
        //    (item.ParentBaseDetail.DetailType.ItemID==4 && item.ParentID == aircraft.AircraftID))
        //            dataSet.ComponentChangeList.AddComponentChangeListRow(item.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), "", description);
        //        else
        //            dataSet.ComponentChangeList.AddComponentChangeListRow(item.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString()), description, "");
            
        //}

        #endregion

        #endregion

    }
}
