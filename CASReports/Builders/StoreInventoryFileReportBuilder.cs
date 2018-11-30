using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Filters;

namespace CASReports.Builders
{
	public class StoreInventoryFileReportBuilder : AbstractReportBuilder
	{
		#region Fields

		private Operator _reportedOperator;

		private string _reportTitle;
		private byte[] _operatorLogotype;
		private string _filterSelection;
		private string _dateAsOf = "";
		private IEnumerable<Component> _reportedComponents;
		private string _formName;

		#endregion

		#region public string ReportTitle

		public string ReportTitle
		{
			get { return _reportTitle; }
			set { _reportTitle = value; }
		}

		#endregion

		#region public string FormName

		public string FormName
		{
			get { return _formName; }
			set { _formName = value; }
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

		#region Constructor

		public StoreInventoryFileReportBuilder(Operator @operator, IEnumerable<Component> components)
		{
			_reportedOperator = @operator;

			if (_reportedOperator != null)
				_operatorLogotype = _reportedOperator.LogotypeReportLarge;

			_reportedComponents = components;
		}

		#endregion

		public override object GenerateReport()
		{
			var report = new StoreInventoryFileReport();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

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
			var dataset = new StoreInventoryFileDataSet();
			AddAdditionalDataToDataSet(dataset);
			AddComponentDataToDataSet(dataset);
			return dataset;
		}

		#endregion

		#region private void AddComponentDataToDataSet(StoreInventoryFileDataSet dataset)

		private void AddComponentDataToDataSet(StoreInventoryFileDataSet dataset)
		{
			foreach (var component in _reportedComponents)
			{
				var partNumber = component.PartNumber;
				var serialNumber = component.SerialNumber;
				var idNumber = component.IdNumber;
				var description = component.Description;
				var goodClass = component.GoodsClass.ToString();
				var state = component.State.ToString();
				var status = component.ComponentStatus.ToString();

				bool isComponent =
					component.GoodsClass.IsNodeOrSubNodeOf(new IDictionaryTreeItem[]
					{
						GoodsClass.ComponentsAndParts,
						GoodsClass.ProductionAuxiliaryEquipment
					});

				var quantityIn = isComponent && component.ItemId > 0 ? 1 : component.QuantityIn;
				var current = isComponent && component.ItemId > 0 ? 1 : component.Quantity;
				var shouldBeOnStockString = component.ShouldBeOnStock > 0 ? "Yes" : "No";
				var workType = "";
				var isPool = component.IsPOOL ? "Yes" : "No";
				var isDangerous = component.IsDangerous ? "Yes" : "No";
				var remarks = component.Remarks;
				var location = component.Location.ToString();
				var locationType = component.Location?.LocationsType?.ToString();

				var lifeLimit = Lifelength.Null;
				var interval = Lifelength.Null;
				var lastPerformanceString = "";
				var next = "";
				var remain = Lifelength.Null;
				var warrrantly = Lifelength.Null;
				var ata = component.ATAChapter.ToString();

				if (component.ComponentDirectives.Count > 0)
				{
					var dd = component.ComponentDirectives.Last();

					workType = dd.DirectiveType.ToString();

					if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
						lifeLimit = dd.Threshold.FirstPerformanceSinceNew; 
					
					if (dd.LastPerformance != null)
						lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(dd.LastPerformance.RecordDate);

					if (dd.Threshold.RepeatInterval != null && !dd.Threshold.RepeatInterval.IsNullOrZero())
						interval = dd.Threshold.RepeatInterval;

					next = dd.NextPerformanceDate != null ? SmartCore.Auxiliary.Convert.GetDateFormat(dd.NextPerformanceDate.Value) : "";
					remain = dd.Remains;
					warrrantly = dd.Warranty;
				}

				dataset.ComponentDataTable.AddComponentDataTableRow(partNumber, serialNumber, idNumber, description, goodClass,
					state, status,
					quantityIn.ToString(), current.ToString(), shouldBeOnStockString, workType, lifeLimit.ToString(), interval.ToString(), lastPerformanceString, next.ToString(), remain.ToString(), warrrantly.ToString(),
					isPool, isDangerous, remarks, location, locationType, ata);
			}
		}

		#endregion

		#region private void AddAdditionalDataToDataSet(MaintenancePlanDataSet destinationDateSet)

		/// <summary>
		/// Добавление дополнительной информации 
		/// </summary>
		/// <param name="storeInventoryDateSet"></param>
		private void AddAdditionalDataToDataSet(StoreInventoryFileDataSet storeInventoryDateSet)
		{
			var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
			var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
			_dateAsOf = DateTime.Today.ToString("dd MM yyyy");
			storeInventoryDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, _dateAsOf, reportFooter, reportFooterPrepared, reportFooterLink, _formName);
		}

		#endregion

	}
}