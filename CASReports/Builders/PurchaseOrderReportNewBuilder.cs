using System;
using System.Collections.Generic;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using SmartCore.Auxiliary;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Personnel;
using SmartCore.Purchase;

namespace CASReports.Builders
{
	/// <summary>
	/// Построитель отчета Release To Service 
	/// </summary>
	public class PurchaseOrderReportNewBuilder : AbstractReportBuilder
	{

		#region Fields

		private Operator _operator;
		private readonly List<PurchaseRequestRecord> _orderRecords;
		private readonly PurchaseOrder _order;
		private readonly Department _department;
		private readonly Specialist _specialist;

		#endregion

		#region Properties

		#region public Operator Operator
		public Operator Operator
		{
			set { _operator = value; }
		}
		#endregion

		public byte[] AuthorSign { get; set; }
		public byte[] PublishSign { get; set; }

		#endregion

		#region Constructor
		/// <summary>
		/// Создается пустой построитель
		/// </summary>
		public PurchaseOrderReportNewBuilder()
		{
		}

		/// <summary>
		/// Создается построитель отчета Release To Service 
		/// </summary>
		/// <param name="op"></param>
		/// <param name="orderRecords"></param>
		/// <param name="order"></param>
		/// <param name="department"></param>
		/// <param name="personnel"></param>
		/// <param name="items"></param>
		public PurchaseOrderReportNewBuilder(Operator op, List<PurchaseRequestRecord> orderRecords, PurchaseOrder order,
			Department department, Specialist personnel)
		{
			_operator = op;
			_orderRecords = orderRecords;
			_order = order;
			_department = department;
			_specialist = personnel;
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
			var report = new PurchaseOrderReportNew();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region private SupplierListDataSet GenerateDataSet()

		private PurchaseRecordNewDataSet GenerateDataSet()
		{
			var dataSet = new PurchaseRecordNewDataSet();
			AddOperatorInformationToDataSet(dataSet);
			AddPurchaseOrderToDataSet(dataSet);
			PurchaseRequestsRecordsToDataSet(dataSet);
			AddDepartmentToDataSet(dataSet);
			AddSupplierToDataSet(dataSet);
			AddPersonnelToDataSet(dataSet);
			return dataSet;
		}

		private void PurchaseRequestsRecordsToDataSet(PurchaseRecordNewDataSet dataSet)
		{
			int i = 1;

			foreach (var record in _orderRecords)
			{
				var destination = record.ParentInitialRecord.DestinationObject is Aircraft
					? ((Aircraft)record.ParentInitialRecord.DestinationObject).ToString()
					: "";
				var total = record.Cost * record.Quantity;
				
				dataSet.PurchaseRequestsRecords.AddPurchaseRequestsRecordsRow(i.ToString(), record.Quantity.ToString("F1"), 
					record.Measure.ShortName, record.Cost.ToString("F1"), total.ToString("F1"), record.CostCondition.ToString(), 
					record.Product.Name,destination, record.Product.PartNumber, record.Currency.ToString(), record.ParentInitialRecord.Priority.ToString());

				i++;
			}
		}

		private void AddPurchaseOrderToDataSet(PurchaseRecordNewDataSet dataSet)
		{
			var total = _orderRecords.Sum(i => i.Cost * i.Quantity);
				dataSet.PurchaseOrder.AddPurchaseOrderRow(_order.Designation.ItemId.ToString(), _order.IncoTerm.ToString(), 
					_order.IncoTermRef, _order.ShipTo.Name, _order.PublishingDate.ToString("dd/MM/yyyy"), _order.ShipCompany.Name, 
					_order.PayTerm.ToString(), _order.OpeningDate.Year.ToString().Substring(2), total.ToString("F1"));
		}

		private void AddDepartmentToDataSet(PurchaseRecordNewDataSet dataSet)
		{
			dataSet.Department.AddDepartmentRow(_department.Address, _department.Phone, _department.Fax, _department.Website);
		}

		private void AddSupplierToDataSet(PurchaseRecordNewDataSet dataSet)
		{
			var _supplier = _order.Supplier;
			dataSet.Supplier.AddSupplierRow(_supplier.AirCode, _supplier.Name, _supplier.ContactPerson, _supplier.Phone, _supplier.Email);
		}

		private void AddPersonnelToDataSet(PurchaseRecordNewDataSet dataSet)
		{
			dataSet.Personnel.AddPersonnelRow(_specialist.ShortName, _specialist.Email, _specialist.PhoneMobile, 
				_specialist.Phone, string.IsNullOrEmpty(_specialist.Additional) ? "" : $"({_specialist.Additional})", _specialist.Specialization.ToString());
		}
		#endregion

		#region private void AddOperatorInformationToDataSet(SupplierListDataSet destinationDataSet)

		private void AddOperatorInformationToDataSet(PurchaseRecordNewDataSet destinationDataSet)
		{
			byte[] operatorLogotype = _operator.LogotypeReportVeryLarge;
			string operatorName = _operator.Name;
			string operatorAddress = _operator.Address;
			var todayDate = SmartCore.Auxiliary.Convert.GetDateFormat(DateTime.Today);
			
			destinationDataSet.HeaderTable.AddHeaderTableRow(operatorLogotype, operatorName, operatorAddress, AuthorSign, PublishSign, todayDate);
		}

		#endregion

		#endregion
	}
}
