using System;
using System.Collections.Generic;
using System.Data;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using CrystalDecisions.CrystalReports.Engine;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Filters;
using SmartCore.Purchase;
using TempUIExtentions;

namespace CASReports.Builders
{
	public class TrackingListBuilder : AbstractReportBuilder
	{
		#region Fields

		private Operator _reportedOperator;
		private Store _currentStore;
		private readonly Specialist _received;
		private readonly Specialist _released;

		private string _reportTitle = "TRACKING LIST";
		private byte[] _operatorLogotype;
		private string _filterSelection;
		private string _dateAsOf = "";

		private IEnumerable<TransferRecord> _transferRecords;
		private string _formName;
		private string _footer;

		#endregion

		#region Constructor

		public TrackingListBuilder(Operator @operator, IEnumerable<TransferRecord> transferRecords, Store currentStore)
		{
			_reportedOperator = @operator;

			if (_reportedOperator != null)
				_operatorLogotype = _reportedOperator.LogotypeReportLarge;

			_transferRecords = transferRecords;
			_currentStore = currentStore;
			_formName = "F SK 044 R0  30Aug2016";
			_footer = new GlobalTermsProvider()["ReportFooter"].ToString();
		}

		public TrackingListBuilder(Operator @operator, TransferRecord[] transferRecords, Store currentStore, Specialist received, Specialist released)
		{
			_reportedOperator = @operator;

			if (_reportedOperator != null)
				_operatorLogotype = _reportedOperator.LogotypeReportLarge;

			_transferRecords = transferRecords;
			_currentStore = currentStore;
			_received = received;
			_released = released;
			_reportTitle = "REQUEST";
			_formName = "F SK 045 R0  30Aug2016";
		}

		#endregion

		#region public CommonFilterCollection FilterSelection

		/// <summary>
		/// фильтры отчета
		/// </summary>
		public CommonFilterCollection FilterSelection
		{
			set { GetFilterSelection(value); }
		}

		#endregion

		#region private void GetFilterSelection(CommonFilterCollection filterCollection)

		private void GetFilterSelection(CommonFilterCollection filterCollection)
		{
			_filterSelection = "All";
			if (filterCollection == null || filterCollection.IsEmpty)
				return;
			_filterSelection = filterCollection.ToStrings();
		}

		#endregion

		#region protected virtual DataSet GenerateDataSet()

		protected virtual DataSet GenerateDataSet()
		{
			var dataset = new TrackingListDataSet();
			AddAdditionalDataToDataSet(dataset);
			AddTrackingDataToDataSet(dataset);
			return dataset;
		}

		#endregion

		#region private void AddAdditionalDataToDataSet(MaintenancePlanDataSet destinationDateSet)

		/// <summary>
		/// Добавление дополнительной информации 
		/// </summary>
		/// <param name="trackingListDataSet"></param>
		private void AddAdditionalDataToDataSet(TrackingListDataSet trackingListDataSet)
		{
			var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
			_dateAsOf = DateTime.Today.ToString("dd MM yyyy");
			
			trackingListDataSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, _dateAsOf, _footer, reportFooterPrepared, reportFooterLink, _formName, _released?.ToString(), _received?.ToString());
		}

		#endregion

		#region private void AddTrackingDataToDataSet(TrackingListDataSet trackingListDataSet)

		private void AddTrackingDataToDataSet(TrackingListDataSet trackingListDataSet)
		{
			foreach (var transferRecord in _transferRecords)
			{
				var date = transferRecord.TransferDate.ToString(new GlobalTermsProvider()["DateFormat"].ToString());
				var goodClass = transferRecord.GoodsClass;
				var reason = transferRecord.Reason;
				var description = transferRecord.Description;
				var remark = transferRecord.Remarks;
				var fromTo = "";
				string descriptionOn = "", descriptionOff = "";
				var quantity = $"{transferRecord.ParentComponent.QuantityIn:0.##}" +
				               (transferRecord.ParentComponent.Measure != null ? " " + transferRecord.ParentComponent.Measure + "(s)" : "");
				var component = transferRecord.ParentComponent;

				if (transferRecord.FromAircraft != null)
					fromTo = "Aircraft: " + transferRecord.FromAircraft;
				if (transferRecord.FromStore != null)
				{
					fromTo = "Store: " + transferRecord.FromStore;
					descriptionOn = component.Description + " " +
					                transferRecord.Position
					                + " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
				}
				if (transferRecord.FromSpecialist != null)
				{
					fromTo = "Employee: " + transferRecord.FromSpecialist;
					descriptionOff = component.Description + " " +
					                transferRecord.Position
					                + " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
				}
				if (transferRecord.FromSupplier != null)
				{
					fromTo = $"Supplier: {transferRecord.FromSupplier} / {transferRecord.FromSupplier.SupplierClass}";
					descriptionOff = component.Description + " " +
					                transferRecord.Position
					                + " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
				}
				if (transferRecord.FromBaseComponent != null)
				{
					if (fromTo != "") fromTo += " ";
					fromTo += "Base Component:" + transferRecord.FromBaseComponent;
					descriptionOff = component.Description + " " +
					                 transferRecord.Position
					                 + " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
				}
				if (transferRecord.FromAircraft == null && transferRecord.FromBaseComponent == null && transferRecord.FromStore == null)
				{
					if (_currentStore != null)
					{
						descriptionOff = component.Description + " " +
						                 transferRecord.Position
						                 + " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
					}
					else
					{
						descriptionOn = component.Description + " " +
						                transferRecord.Position
						                + " P/N:" + component.PartNumber + " S/N: " + component.SerialNumber;
					}

				}


				if (transferRecord.DestinationObject != null)
				{
					if (fromTo != "") fromTo += " ";
					fromTo += "=> " + GetDestinationObjectString(transferRecord);
				}


				var onOff = "";

				if (!string.IsNullOrEmpty(descriptionOn))
					onOff += $"On: {descriptionOn} ";
				if (!string.IsNullOrEmpty(descriptionOff))
					onOff += $"On: {descriptionOff} ";

				trackingListDataSet.TrackingDataTable.AddTrackingDataTableRow(date, fromTo, goodClass.ToString(), quantity, reason.ToString(), onOff, description, remark);
			}
		}

		#endregion

		#region public override object GenerateReport()

		public override object GenerateReport()
		{
			var report = new TrackingListReport();

			if (_received == null && _released == null)
			{
				var o = report.Section5.ReportObjects["Text5"] as TextObject;
				o.Width = 0;
				o.Height = 0;
			}
			else
			{
				var o = report.Section5.ReportObjects["Text10"] as TextObject;
				o.Width = 0;
				o.Height = 0;
			}

			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region private string GetDestinationObjectString(TransferRecord record)

		private string GetDestinationObjectString(TransferRecord record)
		{
			var destination = "";
			var destinationObject = record.DestinationObject;
			if (destinationObject != null)
			{
				if (destinationObject is Aircraft)
					destination = "Aircraft: " + destinationObject;
				if (destinationObject is Store)
					destination = "Store: " + destinationObject;
				if (destinationObject is Specialist)
					destination = "Employee: " + destinationObject;
				if (destinationObject is Supplier)
				{
					var supplier = destinationObject as Supplier;
					destination = $"{supplier.SupplierClass} : {destinationObject} / ";
				}
				if (destinationObject is BaseComponent)
				{
					var bd = (BaseComponent)destinationObject;
					var parentStore = GlobalObjects.StoreCore.GetStoreById(bd.ParentStoreId);
					if (parentStore != null)
						destination = $"Store: {parentStore}";
					if (bd.ParentAircraftId > 0)
						destination = $"Aircraft: {bd.GetParentAircraftRegNumber()}";
					if (destination != "") destination += ", ";
					destination += destinationObject;
				}
			}
			return destination;
		}
		#endregion
	}
}
