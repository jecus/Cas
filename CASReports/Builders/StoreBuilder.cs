using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по складу
    /// </summary>
    public class StoreBuilder :AbstractReportBuilder
    {

        #region Fields

        private readonly StoreDataSet _dataSet;
        private bool _isFiltered;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает построитель отчета по складу
        /// </summary>
        public StoreBuilder()
        {
            _dataSet = new StoreDataSet();
        }

        #endregion

        #region Properties

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

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Создает отчет по данным, добавленным в текущий источник данных (DataSet)
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            StoreReport report = new StoreReport();
            report.SetDataSource(_dataSet);
            return report;
        }

        #endregion

        #region public void AddAdditionalInformation(Image logotype, string headerText, string location)

        public void AddAdditionalInformation(byte[] logotype, string headerText, string location)
        {
            byte[] operatorLogotype = logotype;
            string reportHeader = headerText;
            if (IsFiltered)
                reportHeader += ". Filtered";
            _dataSet.AdditionalDataTable.AddAdditionalDataTableRow(0, reportHeader, location,
                                                                  new GlobalTermsProvider()["ReportFooter"].ToString(),
                                                                  new GlobalTermsProvider()["ReportFooterPrepared"].ToString(),
                                                                  new GlobalTermsProvider()["ReportFooterLink"].ToString(), operatorLogotype);
        }

        #endregion

        #region public void AddDetails(AbstractDetail[] details)

        public void AddDetails(object [] details)
        {
            foreach (object t in details)
            {
                if (!(t is Component)) continue;
                AtaChapter ataChapter = ((Component)t).ATAChapter;
                _dataSet.Details.AddDetailsRow(((Component)t).ItemId.ToString(),
                                               ataChapter.FullName,
                                               ataChapter.ShortName,
                                               ((Component)t).PartNumber,
                                               ((Component)t).Description,
                                               ((Component)t).SerialNumber,
                                               ((Component)t).Remarks, "");
            }
        }

        #endregion

        #endregion
    }
}
