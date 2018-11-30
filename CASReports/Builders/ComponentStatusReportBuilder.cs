using System;
using System.Collections.Generic;
using Auxiliary;
using SmartCore.Entities.Dictionaries;
using CASReports.Datasets;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета для ComponentStatus
    /// </summary>
    public abstract class ComponentStatusReportBuilder : DetailListReportBuilder
    {

        #region Constructors

        #region protected ComponentStatusReportBuilder()

        /// <summary>
        /// Создает построитель отчета Component Status
        /// </summary>
        protected ComponentStatusReportBuilder()
        {
            ReportTitle = "Component Status";
        }

        #endregion

        #endregion

        #region Methods

        #region protected override void AddDetailToDataset(Detail detail, ref int previousNumber, DetailListDataSet destinationDataSet)

        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="componentобавляемый агрегат</param>
        /// <param name="previousNumber">Порядковый номер агрегата</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        protected override void AddDetailToDataset(Component component, ref int previousNumber, DetailListDataSet destinationDataSet)
        {
            Lifelength remainsLifelength;
            Lifelength current;
            DateTime? nextDateTime;

            var ataChapter = component.ATAChapter;
            var atachapter = ataChapter.ShortName;
            var atachapterfull = ataChapter.FullName;
            var partNumber = component.PartNumber;
            var description = component.Description;
            var serialNumber = component.SerialNumber;
	        var lastTransferRecord = component.TransferRecords.GetLast();
			var positionNumber = lastTransferRecord.Position;
            var instalationDateTime = lastTransferRecord.TransferDate;
	        var installationLifelength = lastTransferRecord.OnLifelength;
			var remarks = component.Remarks;
            var lifeLimit = component.LifeLimit;
            var mpdItem = component.MPDItem;
            var detailDirectives = new List<ComponentDirective>(component.ComponentDirectives.ToArray());

            GlobalObjects.PerformanceCalculator.GetNextPerformance(component);
            current = GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength((BaseEntityObject) component);
            nextDateTime = component.NextPerformanceDate;
            remainsLifelength = component.Remains;

            var instalationDate = UsefulMethods.NormalizeDate(instalationDateTime);
            var installationTsncsn = LifelengthFormatter.GetHoursData(installationLifelength, " hrs\r\n") +
                                        LifelengthFormatter.GetCyclesData(installationLifelength, " cyc\r\n");
            var currentTsncsn = LifelengthFormatter.GetHoursData(current, " hrs\r\n") +
                                   LifelengthFormatter.GetCyclesData(current, " cyc\r\n");
            var condition = UsefulMethods.GetColorName(component);
            var nextDate = nextDateTime != null 
                                  ? ((DateTime)nextDateTime).ToString(new GlobalTermsProvider()["DateFormat"].ToString()) 
                                  : "";
            var componentNumber = (previousNumber++).ToString();
            
            if (lifeLimit != Lifelength.Null)
            {
                var workType = "RMV";
                var nextTsncsn = LifelengthFormatter.GetHoursData(lifeLimit, " hrs\r\n") +
                                    LifelengthFormatter.GetCyclesData(lifeLimit, " cyc\r\n");
                var remains = LifelengthFormatter.GetCalendarData(remainsLifelength, " d\r\n") +
                                 LifelengthFormatter.GetHoursData(remainsLifelength, " h\r\n") +
                                 LifelengthFormatter.GetCyclesData(remainsLifelength, " c\r\n");
                if (remains=="")
                {
                    nextDate = "";
                    nextTsncsn = "";
                }
                destinationDataSet.ItemsTable.AddItemsTableRow(componentNumber, atachapter, atachapterfull, partNumber, description, serialNumber, positionNumber, "", instalationDate, "", "", workType, nextTsncsn, nextDate, remains, "", condition, "", "", "", "", "", "", mpdItem, installationTsncsn, remarks, currentTsncsn);
                foreach (ComponentDirective t in detailDirectives)
                    AddDetailDirectiveToDatatSet("", "", "", "", "", "", "", "", "", t, ataChapter, destinationDataSet);
            }
            else if (detailDirectives.Count > 0)
            {
                AddDetailDirectiveToDatatSet(componentNumber, mpdItem, partNumber, description, serialNumber, positionNumber, instalationDate, installationTsncsn, currentTsncsn, detailDirectives[0], ataChapter, destinationDataSet);
                for (int i = 1; i < detailDirectives.Count; i++)
                    AddDetailDirectiveToDatatSet("", "", "", "", "", "", "", "", "", detailDirectives[i], ataChapter, destinationDataSet);
            }
            else
            {
                destinationDataSet.ItemsTable.AddItemsTableRow(componentNumber, atachapter, atachapterfull, partNumber, description, serialNumber, positionNumber, "", instalationDate, "", "", "", "", "", "", "", condition, "", "", "", "", "", "", mpdItem, installationTsncsn, remarks, currentTsncsn);
            }
        }

        #endregion

        #region private void AddDetailDirectiveToDatatSet(string number, string mpdItem, string partNumber, string description, string serialNumber, string positionNumber, string installationDate, string installationTSNCSN, string currentTSNCSN, DetailDirective directive, ATAChapter ataChapter, DetailListDataSet destinationDataSet)

        private void AddDetailDirectiveToDatatSet(string number, string mpdItem, string partNumber, string description, string serialNumber, string positionNumber, string installationDate, string installationTsncsn, string currentTsncsn, ComponentDirective directive, AtaChapter ataChapter, DetailListDataSet destinationDataSet)
        {
            var workType = directive.DirectiveType.ShortName;
            var lastComplianceTsncsn = "";
            var lastComplianceDate = "";
            var nextDate="";

            GlobalObjects.PerformanceCalculator.GetNextPerformance(directive);
            var nextTsncsn = LifelengthFormatter.GetHoursData(directive.NextPerformanceSource, " hrs\r\n") + LifelengthFormatter.GetCyclesData(directive.NextPerformanceSource, " cyc\r\n");
            if (directive.NextPerformanceDate != null)
                nextDate = ((DateTime)directive.NextPerformanceDate).ToString(new GlobalTermsProvider()["DateFormat"].ToString());
            var remains = LifelengthFormatter.GetCalendarData(directive.Remains, " d\r\n") + LifelengthFormatter.GetHoursData(directive.Remains, " h\r\n") + LifelengthFormatter.GetCyclesData(directive.Remains, " c\r\n");

            if (remains == "")
            {
                nextDate = "";
                nextTsncsn = "";
            }
            var directiveRemarks = "";
            
            if (directive.LastPerformance != null)
			{
				var lastComplianceTsncsnlLifelength = directive.LastPerformance.OnLifelength;
				lastComplianceTsncsn = LifelengthFormatter.GetHoursData(lastComplianceTsncsnlLifelength, " hrs\r\n") + LifelengthFormatter.GetCyclesData(lastComplianceTsncsnlLifelength, " cyc\r\n");
                lastComplianceDate = directive.LastPerformance.RecordDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
                directiveRemarks = directive.LastPerformance.Remarks;
            }
            
            var condition = directive.Condition.ToString();
            destinationDataSet.ItemsTable.AddItemsTableRow(number,
                                                           ataChapter.ShortName, ataChapter.FullName, partNumber, description,
                                                           serialNumber, positionNumber,
                                                           "",
                                                           installationDate,
                                                           lastComplianceTsncsn,
                                                           lastComplianceDate,
                                                           workType, nextTsncsn,
                                                           nextDate,
                                                           "",
                                                           "", condition, "", remains, "", "", "", "", mpdItem, installationTsncsn,
                                                           directiveRemarks, currentTsncsn);
        }

        #endregion

        #endregion


    }
}