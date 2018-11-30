using System.Collections.Generic;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета по Should Be On Stock
    /// </summary>
    public class ShouldBeOnStockBuilder : AbstractReportBuilder
    {
        
        #region Fields

        private readonly Store _currentStore;
        private readonly Operator _currentOperator;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает построитель отчета по Should Be On Stock
        /// </summary>
        public ShouldBeOnStockBuilder(Store store)
        {
            _currentStore = store;
        }

        /// <summary>
        /// Создает построитель отчета по Should Be On Stock
        /// </summary>
        public ShouldBeOnStockBuilder(Operator op)
        {
            _currentOperator = op;
        }

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Создает отчет по данным, добавленным в текущий источник данных (DataSet)
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            ShouldBeOnStockReport report = new ShouldBeOnStockReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private MaintenanceJobCardDataSet GenerateDataSet()

        private ShouldBeOnStockDataSet GenerateDataSet()
        {
            ShouldBeOnStockDataSet dataSet = new ShouldBeOnStockDataSet();
            AddAdditionalInformation(dataSet);
            AddDetails(dataSet);
            return dataSet;
        }

        #endregion

        #region public void AddAdditionalInformation(ShouldBeOnStockDataSet dataSet)

        public void AddAdditionalInformation(ShouldBeOnStockDataSet dataSet)
        {
            byte[] operatorLogotype;
            string reportHeader;
            string location="";
            if (_currentStore != null)
            {
                operatorLogotype= _currentStore.Operator.LogoTypeWhite;
                reportHeader = _currentStore.ItemId + ". Should be on stock";
                location = _currentStore.Location;
            }
            else
            {
                operatorLogotype = _currentOperator.LogoTypeWhite;
                reportHeader = _currentOperator.Name + ". Should be on stock";
            }
            dataSet.AdditionalDataTable.AddAdditionalDataTableRow(reportHeader, location,
                                                                      new GlobalTermsProvider()["ReportFooter"].ToString(),
                                                                      new GlobalTermsProvider()["ReportFooterPrepared"].
                                                                          ToString(),
                                                                      new GlobalTermsProvider()["ReportFooterLink"].ToString(),
                                                                      operatorLogotype);
           
        }

        #endregion

        #region public void AddDetails(ShouldBeOnStockDataSet dataSet)

        public void AddDetails(ShouldBeOnStockDataSet dataSet)
        {
            List<StockComponentInfo> stockDetailInfos= new List<StockComponentInfo>();
            if (_currentStore != null)
            {
                stockDetailInfos.AddRange(GlobalObjects.StockCalculator.GetStockComponentInfosWithCalculation(_currentStore));
            }

            stockDetailInfos.Sort(new StockDetailInfosComparer());
            for (int i = 0; i < stockDetailInfos.Count; i++)
            {
                dataSet.Details.AddDetailsRow(stockDetailInfos[i].PartNumber,
                                              stockDetailInfos[i].Description,
                                              stockDetailInfos[i].Current + " / " + stockDetailInfos[i].ShouldBeOnStock,
                                              stockDetailInfos[i].Current < stockDetailInfos[i].ShouldBeOnStock ? 1 : 0);
            }
        }

        #endregion

        #endregion
    }

    #region public class StockDetailInfosComparer : IComparer<StockDetailInfo>

    /// <summary>
    /// Сравнивалка <see cref="StockComponentInfo"/>
    /// </summary>
    public class StockDetailInfosComparer : IComparer<StockComponentInfo>
    {
        #region IComparer<StockDetailInfo> Members

        ///<summary>
        ///Compares two objects and returns a value indicating whether one is less than, equal to, or greater than the other.
        ///</summary>
        ///
        ///<returns>
        ///Value Condition Less than zerox is less than y.Zerox equals y.Greater than zerox is greater than y.
        ///</returns>
        ///
        ///<param name="y">The second object to compare.</param>
        ///<param name="x">The first object to compare.</param>
        public int Compare(StockComponentInfo x, StockComponentInfo y)
        {
            return string.Compare(x.PartNumber, y.PartNumber);
        }

        #endregion
    }

    #endregion

}