using System;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;
using SmartCore.Purchase;

namespace CASReports.Builders
{
    public class RequestForQuotationReportBuilder : AbstractReportBuilder
    {
        #region Fields

        private readonly RequestForQuotation _currentRfQ;

        #endregion

        #region Properties

        #endregion

        #region Constructor
        /// <summary>
        /// Создается построитель отчета Release To Service 
        /// </summary>
        /// <param name="rfq">Рабочий пакет</param>
        public RequestForQuotationReportBuilder(RequestForQuotation rfq)
        {
            _currentRfQ = rfq;
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
            RequestForQuotationReport report = new RequestForQuotationReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region private RequestForQuotationDataSet GenerateDataSet()

        private RequestForQuotationDataSet GenerateDataSet()
        {
            RequestForQuotationDataSet dataSet = new RequestForQuotationDataSet();
            AddOperatorInfoToDataSet(dataSet);
            AddItemsToDataSet(dataSet);
            return dataSet;
        }

        #endregion

        #region private void AddItemsToDataSet(RequestForQuotationDataSet dataset)

        /// <summary>
        /// Добавление директив в таблицу данных
        /// </summary>
        /// <param name="dataset">Таблица, в которую добавляются данные</param>
        private void AddItemsToDataSet(RequestForQuotationDataSet dataset)
        {
            foreach (Product kit in _currentRfQ.Products)
            {
                foreach(Supplier supp in kit.Suppliers)
                {
                    AddItemDataset(kit, supp, dataset);
                }
            }
        }

        #endregion

        #region private void AddItemDataset(AbstractAccessory kit, Supplier supp, RequestForQuotationDataSet destinationDataSet)
        /// <summary>
        /// Добавляется элемент в таблицу данных
        /// </summary>
        /// <param name="accessory">Добавлямая директива</param>
        /// <param name="supp"></param>
        /// <param name="destinationDataSet">Таблица, в которую добавляется элемент</param>
        private void AddItemDataset(Product accessory, Supplier supp, RequestForQuotationDataSet destinationDataSet)
        {

            RequestForQuotationRecord rec =
                _currentRfQ.PackageRecords.FirstOrDefault(item => item.PackageItemId == accessory.ItemId && item.PackageItemType == accessory.SmartCoreObjectType);


            String description = "";
            #region Инициализация description
            if(_currentRfQ.Parent is Aircraft)
                description += ((Aircraft)_currentRfQ.Parent).Model;

            if (accessory.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.MaintenanceMaterials) ||
                accessory.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools))
            {
                //AccessoryRequired kr = (AccessoryRequired) accessory;

                //if (kr.ParentObject is Directive)
                //{
                //    Directive d = (Directive)kr.ParentObject;
                //    description += " " + d.Title +
                //                   " " + d.WorkType;
                //}
                //if (kr.ParentObject is DetailDirective)
                //{
                //    DetailDirective d = (DetailDirective)kr.ParentObject;
                //    description += " " + d.ParentDetail.PartNumber +
                //                   " " + d.DirectiveType;
                //}
                //if (kr.ParentObject is Detail) description += " " + ((Detail)kr.ParentObject).PartNumber;
                //if (kr.ParentObject is MaintenanceCheck) description += " " + ((MaintenanceCheck)kr.ParentObject).Name;
                //if (kr.ParentObject is NonRoutineJob) description += " " + ((NonRoutineJob)kr.ParentObject).Title;

                description += " kit desc: " + accessory.Description;
            }
            else
            {
                description += " desc: " + accessory.Description;
            }
            #endregion
           
            String costCondition = "";
            
            #region инициализация CostCondition
            if((rec.CostCondition & ComponentStatus.New) != 0)
                costCondition += "New";
            if ((rec.CostCondition & ComponentStatus.Serviceable) != 0)
            {
                if(costCondition != "") costCondition += " or ";
                costCondition += "Serviceable";
            }
            if ((rec.CostCondition & ComponentStatus.Overhaul) != 0)
            {
                if(costCondition != "") costCondition += " or ";
                costCondition += "Overhaul";
            }
            #endregion

            destinationDataSet.KitsTable.AddKitsTableRow(accessory.PartNumber, description, (int)rec.Quantity,
                                                         costCondition, supp.Name);
        }

        #endregion

        #region private void AddOperatorInfoToDataSet(RequestForQuotationDataSet destinationDataSet)

        private void AddOperatorInfoToDataSet(RequestForQuotationDataSet destinationDataSet)
        {
            Operator op;
	        if (_currentRfQ.Parent is Aircraft)
	        {
		        var aircraft = (Aircraft) _currentRfQ.Parent;
				op = GlobalObjects.CasEnvironment.Operators.First(o => o.ItemId == aircraft.OperatorId);
			}
            else if (_currentRfQ.Parent is Store)
                op = ((Store)_currentRfQ.Parent).Operator;
            else if (_currentRfQ.Parent is Operator)
                op = ((Operator)_currentRfQ.Parent);
            else op = GlobalObjects.CasEnvironment.Operators[0];

            destinationDataSet.OperatorInfoTable.AddOperatorInfoTableRow(op.ICAOCode,
                                                                         op.Address, op.Phone, op.Fax,
                                                                         "QUOTATION REQUEST # " + _currentRfQ.Title, 
                                                                         "",
                                                                         op.Email,
                                                                         op.LogoTypeWhite);
        }

        #endregion

        #endregion
    }
}
