using System.Data;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Accessory;

namespace CASReports.Builders
{
    public class StoreBarCodeReportBuilder : AbstractReportBuilder
    {
	    #region Properties

       public Component Component { get; set; }

	   public byte[] BarCode { get;set; }

        #endregion

        #region Methods

        #region public override object GenerateReport()

        /// <summary>
        /// Сгенерировать отчет по данным, добавленным в текущий объект
        /// </summary>
        /// <returns>Построенный отчет</returns>
        public override object GenerateReport()
        {
	        StoreBarCodeReport report = new StoreBarCodeReport();
            report.SetDataSource(GenerateDataSet());
            return report;
        }

        #endregion

        #region protected virtual DataSet GenerateDataSet()

        /// <summary>
        /// Построить источник данных (DataSet) для вывода в отчет
        /// </summary>
        /// <returns></returns>
        protected virtual DataSet GenerateDataSet()
        {
	        StoreBarCodeDataSet dataset = new StoreBarCodeDataSet();
            AddAdditionalDataToDataSet(dataset);
            return dataset;
        }

        #endregion

        
        #region protected virtual void AddAdditionalDataToDataSet(DirectivesListDataSet destinationDateSet)

        /// <summary>
        /// Добавление дополнительной информации 
        /// </summary>
        /// <param name="destinationDateSet"></param>
        protected virtual void AddAdditionalDataToDataSet(StoreBarCodeDataSet destinationDateSet)
        {
	        var transferDate = Component.TransferRecords.GetLast().TransferDate;
			var date = transferDate > DateTimeExtend.GetCASMinDateTime()
		        ? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate)
		        : "";
			destinationDateSet.Information.AddInformationRow(Component.Name, Component.AtaSorted.ToString(), Component.PartNumber, Component.SerialNumber,
		        BarCode, date, Component.BatchNumber, Component.ComponentStatus.ToString());

        }

        #endregion

        #endregion

    }
}
