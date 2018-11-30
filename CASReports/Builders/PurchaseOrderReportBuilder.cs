using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Purchase;

namespace CASReports.Builders
{
    public class PurchaseOrderReportBuilder : AbstractReportBuilder
    {
        #region Fields

        private PurchaseOrder _currentPurchaseOrder;

        #endregion

        #region Properties

        #region public RequestForQuotation RfQ
        /// <summary>
        /// Возвращает рабочий пакет
        /// </summary>
        public PurchaseOrder PurchaseOrder
        {
            get { return _currentPurchaseOrder; }
            set { _currentPurchaseOrder = value; }
        }

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="purchaseOrder">Закупочный ордер</param>
        public PurchaseOrderReportBuilder(PurchaseOrder purchaseOrder)
        {
            _currentPurchaseOrder = purchaseOrder;
        }

        #endregion

        #region Methods

        #region public object GenerateReport()

        /// <summary>
        /// Сгенерируовать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
            PurchaseOrderReport report = new PurchaseOrderReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private PurchaseOrderDataSet GenerateDataSet()

        private PurchaseOrderDataSet GenerateDataSet()
        {
            PurchaseOrderDataSet dataSet = new PurchaseOrderDataSet();
            AddOperatorInfoToDataSet(dataSet);
            AddItemsToDataSet(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddItemsToDataSet(PurchaseOrderDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        private void AddItemsToDataSet(PurchaseOrderDataSet dataset)
        {
            foreach(PurchaseRequestRecord purchaseRequest in _currentPurchaseOrder.PackageRecords)
            {
                AddItemDataset(purchaseRequest, dataset);
            }
        }

        #endregion

        #region private void AddItemDataset(Kit kit, Supplier supp, PurchaseOrderDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="request"></param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddItemDataset(PurchaseRequestRecord request, PurchaseOrderDataSet destinationDataSet)
        {

            //Supplier supp = request.Supplier;
            //Product accessory = request.Product;

            //String description = "";

            //if (_currentPurchaseOrder.Parent is Aircraft)
            //    description += ((Aircraft)_currentPurchaseOrder.Parent).Model;

            //if (accessory.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Maintenance) ||
            //    accessory.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools))
            //{
            //    //AccessoryRequired kr = (AccessoryRequired) accessory;
            //    //if (kr.ParentObject is Directive)
            //    //{
            //    //    Directive d = (Directive)kr.ParentObject;
            //    //    description += " " + d.Title +
            //    //                   " " + d.WorkType;
            //    //}
            //    //if (kr.ParentObject is DetailDirective)
            //    //{
            //    //    DetailDirective d = (DetailDirective)kr.ParentObject;
            //    //    description += " " + d.ParentDetail.PartNumber +
            //    //                   " " + d.DirectiveType;
            //    //}
            //    //if (kr.ParentObject is Detail) description += " " + ((Detail)kr.ParentObject).PartNumber;
            //    //if (kr.ParentObject is MaintenanceCheck) description += " " + ((MaintenanceCheck)kr.ParentObject).Name;
            //    //if (kr.ParentObject is NonRoutineJob) description += " " + ((NonRoutineJob)kr.ParentObject).Title;

            //    description += " kit desc: " + accessory.Description; 
            //}
            //else
            //{
            //    description += " desc: " + accessory.Description;   
            //}

            //destinationDataSet.PurchaseRequestTable.AddPurchaseRequestTableRow(accessory.PartNumber, description, request.Quantity,
            //                                               request.CostCondition.ToString(), supp.Name, request.Cost);
        }

        #endregion

        #region private void AddOperatorInfoToDataSet(PurchaseOrderDataSet destinationDataSet)

        private void AddOperatorInfoToDataSet(PurchaseOrderDataSet destinationDataSet)
        {
            Operator op = GlobalObjects.CasEnvironment.Operators[0];
            destinationDataSet.OperatorInfoTable.AddOperatorInfoTableRow(op.ICAOCode,
                                                                         op.Address, op.Phone, op.Fax,
                                                                         "", 
                                                                         "",
                                                                         op.Email,
                                                                         op.LogoTypeWhite,
                                                                         _currentPurchaseOrder.ParentRequest.Title,
                                                                         "PURCHASE ORDER # " +_currentPurchaseOrder.Title);
        }

        #endregion

        #endregion
    }
}
