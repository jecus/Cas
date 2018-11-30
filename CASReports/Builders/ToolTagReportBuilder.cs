using System;
using System.Collections.Generic;
using System.Data;
using CASReports.Datasets;
using CASReports.ReportTemplates;
using CASTerms;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CASReports.Builders
{
	public class ToolTagReportBuilder : AbstractReportBuilder
	{
		private Operator _reportedOperator;
		private  Component _component;

		#region Constructor

		public ToolTagReportBuilder(Operator @operator, Component component)
		{
			_reportedOperator = @operator;
			_component = component;
		}

		#endregion

		#region public override object GenerateReport()

		public override object GenerateReport()
		{
			var report = new ToolTagReport();
			report.SetDataSource(GenerateDataSet());
			return report;
		}

		#endregion

		#region protected virtual DataSet GenerateDataSet()

		protected virtual DataSet GenerateDataSet()
		{
			var dataset = new ServisibleDataSet();
			AddServisibleComponentDataToDataSet(dataset);
			return dataset;
		}

		#endregion

		private void AddServisibleComponentDataToDataSet(ServisibleDataSet dataset)
		{
			var transferRecord = _component.TransferRecords.GetLast();
			var aircraftString = "N/A";
			var malfunction = "N/A";
			var owner = _reportedOperator.ToString();

			var description = _component.Description;
			var serialNumber = string.IsNullOrEmpty(_component.SerialNumber) ? "N/A" : _component.SerialNumber;
			var partNumber = string.IsNullOrEmpty(_component.PartNumber) ? "N/A" : _component.PartNumber;
			var batchNumber = string.IsNullOrEmpty(_component.BatchNumber) ? "N/A" : _component.BatchNumber;
			var status = _component.ComponentStatus.ToString();
			var idNumber = _component.IdNumber;


			dataset.ServisibleDataTable.AddServisibleDataTableRow(owner, aircraftString, description, serialNumber, partNumber, 
				batchNumber, status, _component.QuantityIn.ToString(), DateTime.Today.ToString("dd MM yyyy"), _reportedOperator.Name , malfunction, idNumber,
				"", "", "", "");
		}
	}
}