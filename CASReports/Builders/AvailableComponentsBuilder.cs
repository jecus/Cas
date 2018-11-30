using System;
using System.Collections.Generic;
using System.Data;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Filters;

namespace CASReports.Builders
{
	public class AvailableComponentsBuilder : AbstractReportBuilder
	{
		#region Fields

		private Operator _reportedOperator;

		private string _reportTitle = "Available Components & Equipment&Materials";
		private byte[] _operatorLogotype;
		private string _filterSelection;
		private string _dateAsOf = "";
		private IEnumerable<Component> _reportedComponents;
		private WorkPackage _reportedWorkPackage;

		#endregion

		#region Constructor

		public AvailableComponentsBuilder(Operator @operator, IEnumerable<Component> components, WorkPackage wp)
		{
			_reportedOperator = @operator;

			if (_reportedOperator != null)
				_operatorLogotype = _reportedOperator.LogotypeReportLarge;

			_reportedWorkPackage = wp;
			_reportedComponents = components;
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
			var dataset = new AvailableComponentsDataSet();
			AddAdditionalDataToDataSet(dataset);
			AddComponentsDataToDataSet(dataset);
			return dataset;
		}

		#endregion

		#region private void AddComponentsDataToDataSet(AvailableComponentsDataSet dataset)

		private void AddComponentsDataToDataSet(AvailableComponentsDataSet dataset)
		{
			foreach (var component in _reportedComponents)
			{
				var partNumber = component.PartNumber;
				var description = component.Description;
				var goodClass = component.GoodsClass.ToString();
				var remarks = component.Remarks;

				bool isComponent =
					component.GoodsClass.IsNodeOrSubNodeOf(new IDictionaryTreeItem[]
					{
						GoodsClass.ComponentsAndParts,
						GoodsClass.ProductionAuxiliaryEquipment
					});

				var quantityIn = isComponent && component.ItemId > 0 ? 1 : component.QuantityIn;
				var current = isComponent && component.ItemId > 0 ? 1 : component.Quantity;
				var shouldBeOnStockString = component.ShouldBeOnStock;
				var needWP = component.NeedWpQuantity;
				var reserve = current - needWP;

				var ata = component.ATAChapter.ToString();
				var location = component.Location.ToString();
				var locationType = component.Location?.LocationsType?.ToString();


				dataset.ComponentsDataTable.AddComponentsDataTableRow(partNumber, description, goodClass, $"{quantityIn:0.##}" + (component.Measure != null ? " " + component.Measure + "(s)" : ""),
					shouldBeOnStockString.ToString(), current.ToString(), needWP.ToString(), reserve.ToString(), remarks, ata, locationType, location);
			}
		}

		#endregion

		#region private void AddAdditionalDataToDataSet(AvailableComponentsDataSet destinationDateSet)

		/// <summary>
		/// Добавление дополнительной информации 
		/// </summary>
		/// <param name="availableComponentsDateSet"></param>
		private void AddAdditionalDataToDataSet(AvailableComponentsDataSet availableComponentsDateSet)
		{
			var reportFooter = new GlobalTermsProvider()["ReportFooter"].ToString();
			var reportFooterPrepared = new GlobalTermsProvider()["ReportFooterPrepared"].ToString();
			var reportFooterLink = new GlobalTermsProvider()["ProductWebsite"].ToString();
			_dateAsOf = DateTime.Today.ToString("dd MM yyyy");

			var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(_reportedWorkPackage.ParentId);
			var wpTitle = _reportedWorkPackage.Title;
			var date = _reportedWorkPackage.OpeningDate.ToString("dd MM yyyy");

			availableComponentsDateSet.AdditionalDataTAble.AddAdditionalDataTAbleRow(_reportTitle, _operatorLogotype, _filterSelection, _dateAsOf, reportFooter, reportFooterPrepared, reportFooterLink, aircraft.ToString(), wpTitle, date);
		}

		#endregion

		public override object GenerateReport()
		{
			var report = new AvailableComponentsReport();
			report.SetDataSource(GenerateDataSet());
			return report;
		}
	}
}