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

			var dates = new DateTime(2018, 1, 1).Range(new DateTime(2018, 12, 31));

			//BarSeries barSeries2 = new BarSeries("Performance", "RepresentativeName");
			//barSeries2.Name = "Q2";

			LineSeries lineSeries = new LineSeries()
			{
				ShowLabels = true,
				Spline = true
			};
			LineSeries lineSeries1 = new LineSeries()
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

			
			var panZoomController = new ChartPanZoomController();
			panZoomController.PanZoomMode = ChartPanZoomMode.Horizontal;
			radChartView1.Controllers.Add(panZoomController);

			radChartView1.ShowPanZoom = true;

			radChartView1.Controllers.Add(new ChartTooltipController());
			radChartView1.Controllers.Add(new ChartTrackballController());
			radChartView1.ShowToolTip = true;
			radChartView1.Zoom(25, 1);
			//this.radChartView1.Series.Add(barSeries2);
			this.radChartView1.Series.Add(lineSeries);
			this.radChartView1.Series.Add(lineSeries1);

		}
	}
}
