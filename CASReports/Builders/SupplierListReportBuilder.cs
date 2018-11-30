using System.Collections.Generic;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace CASReports.Builders
{
    /// <summary>
    /// Построитель отчета Release To Service 
    /// </summary>
    public class SupplierListReportBuilder : AbstractReportBuilder
    {

        #region Fields

        /// <summary>
        /// Поставщики включаемые в отчет
        /// </summary>
        private List<Supplier> _items;

        private Operator _operator;
        #endregion

        #region Properties

        #region public Operator Operator
        public Operator Operator
        {
            set { _operator = value; }
        }
        #endregion

        #region public List<Supplier> Items
        public List<Supplier> Items
        {
            set { _items = value; }
        }
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Создается пустой построитель
        /// </summary>
        public SupplierListReportBuilder()
        {
        }

        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="op"></param>
        /// <param name="items"></param>
        public SupplierListReportBuilder(Operator op, List<Supplier> items)
        {
            _operator = op;
            _items = items;
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
            SupplierListReport report = new SupplierListReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private SupplierListDataSet GenerateDataSet()

        private SupplierListDataSet GenerateDataSet()
        {
            SupplierListDataSet dataSet = new SupplierListDataSet();
            AddOperatorInformationToDataSet(dataSet);
            AddItemsToDataSet(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddItemsToDataSet(SupplierListDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        private void AddItemsToDataSet(SupplierListDataSet dataset)
        {
            foreach (Supplier suppler in _items)
            {
                AddItemDataset(suppler, dataset);
            }
        }

        #endregion

        #region private void AddItemDataset(Supplier item, SupplierListDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="item">Добавлямая директива</param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddItemDataset(Supplier item, SupplierListDataSet destinationDataSet)
        {
            destinationDataSet.ItemsTable.AddItemsTableRow(item.Name, item.Address, item.VendorCode, item.Products, "");
        }

        #endregion

        #region private void AddOperatorInformationToDataSet(SupplierListDataSet destinationDataSet)

        private void AddOperatorInformationToDataSet(SupplierListDataSet destinationDataSet)
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
