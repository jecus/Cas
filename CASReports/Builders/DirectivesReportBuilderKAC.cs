using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;

namespace CASReports.Builders
{
    public class DirectivesReportBuilderKAC : DirectivesReportBuilder
    {

        #region Fields

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            DirectivesListReportKAC report = new DirectivesListReportKAC();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected override void AddAdditionalDataToDataSet(DirectivesListDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        protected override void AddAdditionalDataToDataSet(DirectivesListDataSet destinationDateSet)
        {
            string firsttitle = "";
            string discriptiontitle = "";
            string secondtitle = "";

            if (DirectiveType == SmartCore.Entities.Dictionaries.DirectiveType.AirworthenessDirectives)
            {
                firsttitle = "AD #";
                discriptiontitle = "Title";
                secondtitle = "Reference";
            }
            if (DirectiveType == SmartCore.Entities.Dictionaries.DirectiveType.EngineeringOrders)
            {
                firsttitle = "EO";
                secondtitle = "AD\n (SB)";
                discriptiontitle = "Title";
            }
            if (DirectiveType == SmartCore.Entities.Dictionaries.DirectiveType.SB)
            {
                firsttitle = "SB #";
                secondtitle = "Reference";
                discriptiontitle = "Title";
            }
            if (DirectiveType == SmartCore.Entities.Dictionaries.DirectiveType.OutOfPhase)
            {
                firsttitle = "\n ITEM #";
                secondtitle = "\n (EO, MJC)";
                discriptiontitle = "REQUIREMENT";
            }
            if (DirectiveType == SmartCore.Entities.Dictionaries.DirectiveType.DamagesRequiring)
            {
                firsttitle = "\n ITEM #";
                secondtitle = "\n (EO, MJC)";
                discriptiontitle = "DESCRIPTION";
            }
            string reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
            string reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
            string reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
            destinationDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, DateAsOf, firsttitle, secondtitle, discriptiontitle, reportFooter, reportFooterPrepared, reportFooterLink);

        }

        #endregion

        #endregion

    }
}
