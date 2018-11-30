/*
using System.Collections.Generic;
using System.Windows.Forms;
using Auxiliary;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CASReports.Builders;
using CASReports.Datasets;
using CASTerms;

namespace CASReports
{
    public class AvionicsInventoryStatusReportBuilder : DetailListReportBuilder
    {
        #region Constructor

        #region public AvionicsInventoryStatusReportBuilder():base()
        public AvionicsInventoryStatusReportBuilder():base()
        {
            ReportTitle = "Avionics Inventory Status";
            ReportType = ReportTitle;
        }
        #endregion


        #endregion

        #region Methods

        #region protected override void AddDetailToDataset(AbstractDetail detail, ref int previousNumber, DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="detail">Добавляемый агрегат</param>
        /// <param name="previousNumber">Порядковый номер агрегата</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected override void AddDetailToDataset(AbstractDetail detail, ref int previousNumber, DetailListDataSet destinationDataSet)
        {
            string atachapter = detail.AtaChapter.ShortName;
            string atachapterfull = detail.AtaChapter.FullName;
            string mpdItem = detail.MPDItem;
            string partNumber = detail.PartNumber;
            string description = detail.Description;
            string serialNumber = detail.SerialNumber;
            string positionNumber = detail.PositionNumber;
            string instalationDate = UsefulMethods.NormalizeDate(detail.InstallationDate);
            Lifelength installationLifelength = detail.GetLifelength(detail.InstallationDate);
            Lifelength current = detail.GetLifelength();
            string installationTSNCSN = lifelengthFormatter.GetHoursData(installationLifelength, " hrs\r\n") +
                                        lifelengthFormatter.GetCyclesData(installationLifelength, " cyc\r\n");
            string currentTSNCSN = lifelengthFormatter.GetHoursData(current, " hrs\r\n") +
                                   lifelengthFormatter.GetCyclesData(current, " cyc\r\n");
            string condition = detail.ConditionState.GetHashCode().ToString();
            string remarks = detail.Remarks;
            string componentNumber = (previousNumber++).ToString();
            List<DetailDirective> detailDirectives = new List<DetailDirective>(detail.GetDetailDirectives());
            if (detail.LifeLimit != Lifelength.NullLifelength)
            {
                string workType = "RMV";
                string nextTSNCSN = lifelengthFormatter.GetHoursData(detail.LifeLimit, " hrs\r\n") +
                                    lifelengthFormatter.GetCyclesData(detail.LifeLimit, " cyc\r\n");
                string nextDate = detail.ApproximateDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                string remains = lifelengthFormatter.GetCalendarData(detail.Remains, " d\r\n") +
                                 lifelengthFormatter.GetHoursData(detail.Remains, " h\r\n") +
                                 lifelengthFormatter.GetCyclesData(detail.Remains, " c\r\n");
                if (remains == "")
                {
                    nextDate = "";
                    nextTSNCSN = "";
                }
                destinationDataSet.ItemsTable.AddItemsTableRow(componentNumber, atachapter, atachapterfull, partNumber, description, serialNumber, positionNumber, "", instalationDate, "", "", workType, nextTSNCSN, nextDate, remains, "", condition, "", "", "", "", "", "", mpdItem, installationTSNCSN, remarks, currentTSNCSN);
                for (int i = 0; i < detailDirectives.Count; i++)
                    AddDetailDirectiveToDatatSet("", "", "", "", "", "", "", "", "", detailDirectives[i], detail.AtaChapter, destinationDataSet);
            }
            else if (detailDirectives.Count > 0)
            {
                AddDetailDirectiveToDatatSet(componentNumber, mpdItem, partNumber, description, serialNumber, positionNumber, instalationDate, installationTSNCSN, currentTSNCSN, detailDirectives[0], detail.AtaChapter, destinationDataSet);
                for (int i = 1; i < detailDirectives.Count; i++)
                    AddDetailDirectiveToDatatSet("", "", "", "", "", "", "", "", "", detailDirectives[i], detail.AtaChapter, destinationDataSet);
            }
            else
            {
                destinationDataSet.ItemsTable.AddItemsTableRow(componentNumber, atachapter, atachapterfull, partNumber, description, serialNumber, positionNumber, "", instalationDate, "", "", "", "", "", "", "", condition, "", "", "", "", "", "", mpdItem, installationTSNCSN, remarks, currentTSNCSN);
            }
        }

        #endregion

        #region private void AddDetailDirectiveToDatatSet(string number, string mpdItem, string partNumber, string description, string serialNumber, string positionNumber, string installationDate, string installationTSNCSN, string currentTSNCSN, DetailDirective directive, ATAChapter ataChapter, DetailListDataSet destinationDataSet)

        private void AddDetailDirectiveToDatatSet(string number, string mpdItem, string partNumber, string description, string serialNumber, string positionNumber, string installationDate, string installationTSNCSN, string currentTSNCSN, DetailDirective directive, ATAChapter ataChapter, DetailListDataSet destinationDataSet)
        {
            string workType = directive.WorkType.ShortName;
            string lastComplianceTSNCSN = "";
            string lastComplianceDate = "";
            string nextTSNCSN = lifelengthFormatter.GetHoursData(directive.NextCompliance, " hrs\r\n") + lifelengthFormatter.GetCyclesData(directive.NextCompliance, " cyc\r\n");
            string nextDate = directive.NextComplianceDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            string remains = lifelengthFormatter.GetCalendarData(directive.Remains, " d\r\n") + lifelengthFormatter.GetHoursData(directive.Remains, " h\r\n") + lifelengthFormatter.GetCyclesData(directive.Remains, " c\r\n");
            if (remains == "")
            {
                nextDate = "";
                nextTSNCSN = "";
            }
            string directiveRemarks = "";
            DirectiveRecord lastPerform = directive.GetLastPerform();
            if (lastPerform != null)
            {
                lastComplianceTSNCSN = lifelengthFormatter.GetHoursData(directive.LastCompliance, " hrs\r\n") + lifelengthFormatter.GetCyclesData(directive.LastCompliance, " cyc\r\n");
                lastComplianceDate = directive.LastComplianceDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                directiveRemarks = lastPerform.Description;
            }
            string condition = ((int)directive.ConditionState).ToString();
            destinationDataSet.ItemsTable.AddItemsTableRow(number,
                                                           ataChapter.ShortName, ataChapter.FullName, partNumber, description,
                                                           serialNumber, positionNumber,
                                                           "",
                                                           installationDate,
                                                           lastComplianceTSNCSN,
                                                           lastComplianceDate,
                                                           workType, nextTSNCSN,
                                                           nextDate,
                                                           "",
                                                           "", condition, "", remains, "", "", "", "", mpdItem, installationTSNCSN,
                                                           directiveRemarks, currentTSNCSN);
        }

        #endregion

        #endregion



    }
}
*/
