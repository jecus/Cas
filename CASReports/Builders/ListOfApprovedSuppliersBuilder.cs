using System;
using System.Collections.Generic;
using System.Data;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Filters;
using SmartCore.Purchase;

namespace CASReports.Builders
{
	public class ListOfApprovedSuppliersBuilder : AbstractReportBuilder
	{
		#region Fields

		private Operator _reportedOperator;

		private string _reportTitle = "";
		private byte[] _operatorLogotype;
		private string _filterSelection;
		private string _dateAsOf = "";
		private string _formName = "";

		private IEnumerable<Supplier> _reportedSuppliers;

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

		#region Constructor

		public ListOfApprovedSuppliersBuilder(Operator @operator, IEnumerable<Supplier> suppliers, string formName, string reportTitle)
		{
			_reportedOperator = @operator;

			if (_reportedOperator != null)
				_operatorLogotype = _reportedOperator.LogotypeReportLarge;

			_reportedSuppliers = suppliers;
			_formName = formName;
			_reportTitle = reportTitle;
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

		#region public override object GenerateReport()

		public override object GenerateReport()
		{
			var report = new ListOfApproveSuppliersCrystalReport();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region protected virtual DataSet GenerateDataSet()

		protected virtual DataSet GenerateDataSet()
		{
			var dataset = new SupplierDataSet();
			AddAdditionalDataToDataSet(dataset);
			AddSuppliersToDataSet(dataset);
			return dataset;
		}

		#endregion

		#region private void AddSuppliersToDataSet(SupplierDataSet dataset)

		private void AddSuppliersToDataSet(SupplierDataSet dataset)
		{
			foreach (var supplier in _reportedSuppliers)
			{
				var name = supplier.Name;
				var subject = supplier.Subject;
				var vendor = supplier.VendorCode;
				var approved = supplier.SupplierClass.ToString();
				var adress = supplier.Address;
				var contactPerson = supplier.ContactPerson;
				var faxPhone = $"{supplier.Fax} / {supplier.Phone}";
				var email = supplier.Email;
				var site = supplier.WebSite;
				var remark = supplier.Remarks;

				dataset.SupplierDataTable.AddSupplierDataTableRow(name, subject, vendor, approved, "", adress, contactPerson, faxPhone, email, site, remark);
			}

		}

		#endregion

		#region private void AddAdditionalDataToDataSet(SupplierDataSet dataset)

		private void AddAdditionalDataToDataSet(SupplierDataSet dataset)
		{
			var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
			var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
			_dateAsOf = DateTime.Today.ToString("dd MM yyyy");
			dataset.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, _dateAsOf, reportFooter, reportFooterPrepared, reportFooterLink, _formName);
		}

		#endregion
	}
}