using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.OilControls.Model;
using MetroFramework.Controls;
using MetroFramework.Forms;
using SmartCore.Auxiliary;
using SmartCore.Entities.General.Accessory;
using Telerik.Charting;
using Telerik.WinControls.UI;
using DateTimeExtensions = System.DateTimeExtensions;

namespace CAS.UI.UIControls.OilControls
{
	public partial class OilGraphForm : MetroForm
	{
		#region Fields

		private readonly OilGraphicModel _graph;

		#endregion

		#region Constructor

		public OilGraphForm(OilGraphicModel graph, DateTime from, DateTime to)
		{
			InitializeComponent();

			_graph = graph;
			FillData();

			this.Text += $@" (Period: {from.Date:dd.MM.yyyy}  - {to.Date:dd.MM.yyyy})";
			label2.Text += $@" {(to - from).TotalDays:####} days";
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
				BorderWidth = 2
				//Spline = true, // закруглять углы
			};
			var lineSeriesMean = new ScatterLineSeries()
			{
				ShowLabels = true,
				LegendTitle = "Consumption Mean",
				Name = "Consumption Mean:",
				LabelFormat = "{0:F}",
				BorderWidth = 2
				//Spline = true, // закруглять углы
			};

			var lineSeriesMin = new ScatterLineSeries { BorderColor = Color.Green, LegendTitle = "Alert", ShowLabels = false, PointSize = new SizeF(0,0), BackColor = Color.Green };
			var lineSeriesNorm = new ScatterLineSeries { BorderColor = Color.Yellow, LegendTitle = "Max", ShowLabels = false, PointSize = new SizeF(0, 0), BackColor = Color.Yellow};
			var lineSeriesMax = new ScatterLineSeries { BorderColor = Color.Red, LegendTitle = "AWL", ShowLabels = false, PointSize = new SizeF(0, 0), BackColor = Color.Red };

			radChartView1.Series.Clear();

			foreach (var values in _graph.Graph[comp].OrderBy(i => i.Key.Hours))
			{
				if (_graph.Limits[comp].Max > 0)
					lineSeriesMax.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, _graph.Limits[comp].Max));
				if (_graph.Limits[comp].Normal > 0)
					lineSeriesNorm.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, _graph.Limits[comp].Normal));
				if (_graph.Limits[comp].Min > 0)
					lineSeriesMin.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, _graph.Limits[comp].Min));

				lineSeries.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, (double)values.Value.Consumption));
				lineSeriesMean.DataPoints.Add(new ScatterDataPoint(values.Key.Hours.Value, (double)values.Value.ConsumptionMean));
			}

			radChartView1.Series.Clear();

			if (lineSeriesMax.DataPoints.Count > 0)
				radChartView1.Series.Add(lineSeriesMax);
			if (lineSeriesNorm.DataPoints.Count > 0)
				radChartView1.Series.Add(lineSeriesNorm);
			if (lineSeriesMin.DataPoints.Count > 0)
				radChartView1.Series.Add(lineSeriesMin);
			radChartView1.Series.Add(lineSeries);
			radChartView1.Series.Add(lineSeriesMean);

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

			ChartTrackballController controler = new ChartTrackballController();
			controler.TextNeeded += controler_TextNeeded;
			radChartView1.Controllers.Add(controler);

			radChartView1.Controllers.Add(new ChartTooltipController());
			
			radChartView1.ShowToolTip = false;
			radChartView1.Zoom(85, 1);
			radChartView1.Pan(1000, 0);


			radChartView1.ShowLegend = true;
			this.radChartView1.LegendTitle = "Legend";
			this.radChartView1.ChartElement.LegendElement.TitleElement.Font = new Font("Arial", 16, FontStyle.Italic);


			//setup the Cartesian Grid
			var area = radChartView1.GetArea<CartesianArea>();
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

		//private Font font = new Font("Segoe Script", 12, FontStyle.Regular);
		private void controler_TextNeeded(object sender, TextNeededEventArgs e)
		{
			e.Element.BackColor = ColorTranslator.FromHtml("#ffffff");
			//e.Element.ForeColor = ColorTranslator.FromHtml("#bb2525");
			e.Element.BorderColor = ColorTranslator.FromHtml("#000000");
			e.Element.Padding = new Padding(10);
			//e.Element.Font = font;
			//e.Element.NumberOfColors = 1;
			e.Element.BorderGradientStyle = Telerik.WinControls.GradientStyles.Solid;
			ScatterDataPoint dataPoint = e.Points[3].DataPoint as ScatterDataPoint;
			
			e.Text = $@"<html><color='gray'>HRS:{dataPoint.XValue} Consumption:{dataPoint.YValue.Value:F}";
		}
	}
}
