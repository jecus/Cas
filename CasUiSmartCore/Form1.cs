using System;
using System.Collections.Generic;
using System.Linq;
using MetroFramework.Forms;
using Telerik.Charting;
using Telerik.WinControls.UI;

namespace CAS.UI
{
	public partial class Form1 : MetroForm
	{
		public Form1()
		{
			InitializeComponent();

			Initialize();
			FillData();

		}

		private void FillData()
		{
			var dates = new DateTime(2018, 1, 1).Range(new DateTime(2018, 12, 31));

			//BarSeries barSeries2 = new BarSeries("Performance", "RepresentativeName");
			//barSeries2.Name = "Q2";

			var lineSeries = new LineSeries()
			{
				ShowLabels = true,
				Spline = true
			};
			var lineSeries1 = new LineSeries()
			{
				ShowLabels = true,
			};
			var random = new Random(1000);
			foreach (var date in dates)
			{
				//barSeries2.DataPoints.Add(new CategoricalDataPoint(random.Next(1, 200), date.ToString("d")));
				lineSeries.DataPoints.Add(new CategoricalDataPoint(random.Next(1, 200), date.ToString("d")));
				lineSeries1.DataPoints.Add(new CategoricalDataPoint(random.Next(-100, 200), date.ToString("d")));
			}

			//this.radChartView1.Series.Add(barSeries2);
			radChartView1.Series.Add(lineSeries);
			radChartView1.Series.Add(lineSeries1);
		}


		private void Initialize()
		{
			var panZoomController = new ChartPanZoomController { PanZoomMode = ChartPanZoomMode.Horizontal };
			radChartView1.Controllers.Add(panZoomController);

			radChartView1.ShowPanZoom = true;
			radChartView1.ShowGrid = true;

			radChartView1.Controllers.Add(new ChartTooltipController());
			radChartView1.Controllers.Add(new ChartTrackballController());
			radChartView1.ShowToolTip = true;
			radChartView1.Zoom(25, 1);
		}


	}
}
