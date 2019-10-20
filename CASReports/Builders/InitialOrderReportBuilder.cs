using System.Collections.Generic;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета Release To Service 
    /// </summary>
    public class InitialOrderReportBuilder : AbstractReportBuilder
    {

        #region Fields

        private Operator _operator;
        #endregion

        #region Properties

        #region public Operator Operator
        public Operator Operator
        {
            set { _operator = value; }
        }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Создается пустой построитель
        /// </summary>
        public InitialOrderReportBuilder()
        {
        }

        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="items"></param>
        public InitialOrderReportBuilder(Operator op)
        {
            _operator = op;
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
            var report = new InitialOrderReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private SupplierListDataSet GenerateDataSet()

        private InitialRecordDataSet GenerateDataSet()
        {
            var dataSet = new InitialRecordDataSet();
            AddOperatorInformationToDataSet(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddOperatorInformationToDataSet(SupplierListDataSet destinationDataSet)

        private void AddOperatorInformationToDataSet(InitialRecordDataSet destinationDataSet)
        {
            byte[] operatorLogotype = _operator.LogoTypeWhite;
            string operatorName = _operator.Name;
            string operatorAddress = _operator.Address;
            destinationDataSet.HeaderTable.AddHeaderTableRow(operatorLogotype, operatorName, operatorAddress);
        }

        #endregion

        #endregion
    }
}
