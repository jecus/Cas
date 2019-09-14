using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using CAS.UI.UIControls.OilControls.Model;
using MetroFramework.Controls;
using MetroFramework.Forms;
using SmartCore.Entities.General.Accessory;
using Telerik.Charting;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.RangeSelector.InterfacesAndEnum;

namespace CAS.UI.UIControls.OilControls
{
	public partial class OilGraphForm : MetroForm
	{
		#region Fields

		private readonly OilGraphicModel _graph;

		#endregion

		#region Constructor

		public OilGraphForm(OilGraphicModel graph)
		{
			InitializeComponent();

			_graph = graph;
			FillData();
		}

		#endregion

		private void FillData()
		{
			foreach (var baseComponent in _graph.Graph)
			{
				var radio = new MetroRadioButton()
				{
					Text = baseComponent.Key.ToString(),
					Tag = baseComponent.Key,
					Width = 150,
				};
				radio.CheckedChanged += Radio_CheckedChanged;
				flowLayoutPanel1.Controls.Add(radio);
			}

			var first = flowLayoutPanel1.Controls.OfType<MetroRadioButton>().FirstOrDefault();
			if(first!= null)
				first.Checked = true;
		}

		private void Radio_CheckedChanged(object sender, System.EventArgs e)
		{
			Initialize();

			var radio = sender as MetroRadioButton;
			var comp = radio.Tag as BaseComponent;
			var lineSeries = new ScatterLineSeries()
			{
				ShowLabels = true,
				LegendTitle = "Consumption",
				Name = "Consumption:",
				LabelFormat = "{0:F}",
				//Spline = true, // закруглять углы
			};

			var lineSeriesMin = new ScatterLineSeries { BorderColor = Color.Green, LegendTitle = "Min", ShowLabels = false, PointSize = new SizeF(0,0)};
			var lineSeriesNorm = new ScatterLineSeries { BorderColor = Color.Yellow, LegendTitle = "Normal", ShowLabels = false, PointSize = new SizeF(0, 0) };
			var lineSeriesMax = new ScatterLineSeries { BorderColor = Color.Red, LegendTitle = "Max", ShowLabels = false, PointSize = new SizeF(0, 0) };

			radChartView1.Series.Clear();

			foreach (var values in _graph.Graph[comp].OrderBy(i => i.Key.Hours))
			{
				lineSeries.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value,values.Value));

				if (_graph.Limits[comp].Min > 0)
					lineSeriesMin.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, _graph.Limits[comp].Min));
				if(_graph.Limits[comp].Normal > 0)
					lineSeriesNorm.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, _graph.Limits[comp].Normal));
				if (_graph.Limits[comp].Max > 0)
					lineSeriesMax.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, _graph.Limits[comp].Max));
			}

			radChartView1.Series.Clear();
			radChartView1.Series.Add(lineSeries);
			if (lineSeriesMin.DataPoints.Count > 0)
				radChartView1.Series.Add(lineSeriesMin);
			if (lineSeriesNorm.DataPoints.Count > 0)
				radChartView1.Series.Add(lineSeriesNorm);
			if (lineSeriesMax.DataPoints.Count > 0)
				radChartView1.Series.Add(lineSeriesMax);

			LinearAxis horizontalAxis = radChartView1.Axes.Get<LinearAxis>(0);
			//horizontalAxis.Minimum = (double)_graph.Graph[comp].OrderBy(i => i.Key.Hours).FirstOrDefault().Key.Hours;
			//horizontalAxis.Maximum = (double)_graph.Graph[comp].OrderBy(i => i.Key.Hours).LastOrDefault().Key.Hours;
			//horizontalAxis.MajorStep = 10;
			horizontalAxis.LastLabelVisibility = AxisLastLabelVisibility.Clip;

			horizontalAxis.LabelFitMode = AxisLabelFitMode.Rotate;
			horizontalAxis.LabelRotationAngle = 300;
			
			LinearAxis verticalAxis = radChartView1.Axes.Get<LinearAxis>(1);
			//verticalAxis.Minimum = _graph.Graph[comp].Min(i => i.Value);
			//verticalAxis.Maximum = _graph.Graph[comp].Max(i => i.Value);
			verticalAxis.MajorStep = 0.5;

			radChartView1.Refresh();
			radChartView1.Update();
			radRangeSelector1.AssociatedControl = radChartView1;
		}

		private void Initialize()
		{
			var panZoomController = new ChartPanZoomController { PanZoomMode = ChartPanZoomMode.Horizontal };
			radChartView1.Controllers.Add(panZoomController);

			radChartView1.ShowPanZoom = true;

			radChartView1.Controllers.Add(new ChartTooltipController());
			radChartView1.Controllers.Add(new ChartTrackballController());
			radChartView1.ShowToolTip = false;
			radChartView1.Zoom(85, 1);
			radChartView1.Pan(1000, 0);


			radChartView1.ShowLegend = true;
			this.radChartView1.LegendTitle = "Legend";
			this.radChartView1.ChartElement.LegendElement.TitleElement.Font = new Font("Arial", 16, FontStyle.Italic);


			//setup the Cartesian Grid
			var area = this.radChartView1.GetArea<CartesianArea>();
			area.ShowGrid = true;
			CartesianGrid grid = area.GetGrid<CartesianGrid>();
			grid.DrawHorizontalFills = true;
			grid.BorderDashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
			grid.ForeColor = Color.LightGray;
			grid.DrawHorizontalFills = true;
			grid.DrawVerticalFills = true;
			grid.AlternatingVerticalColor = true;
			grid.AlternatingHorizontalColor = true;
			grid.AlternatingBackColor = Color.White;
			grid.AlternatingBackColor2 = Color.White;
		}
	}
}
