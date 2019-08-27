using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.OilControls.Model;
using MetroFramework.Controls;
using MetroFramework.Forms;
using SmartCore.Entities.General.Accessory;
using Telerik.Charting;
using Telerik.WinControls.UI;

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
			var lineSeries = new LineSeries()
			{
				ShowLabels = true,
				LegendTitle = "Oil"
				//Spline = true, // закруглять углы
			};

			var lineSeriesMin = new LineSeries {BorderColor = Color.Red, LegendTitle = "Min"};
			var lineSeriesNorm = new LineSeries {BorderColor = Color.Yellow, LegendTitle = "Normal"};
			var lineSeriesMax = new LineSeries {BorderColor = Color.Green, LegendTitle = "Max" };

			radChartView1.Series.Clear();

			foreach (var values in _graph.Graph[comp])
			{
				lineSeries.DataPoints.Add(new CategoricalDataPoint(values.Value, values.Key.ToString()));
				lineSeriesMin.DataPoints.Add(new CategoricalDataPoint(_graph.Min, values.Key.ToString()));
				lineSeriesNorm.DataPoints.Add(new CategoricalDataPoint(_graph.Normal, values.Key.ToString()));
				lineSeriesMax.DataPoints.Add(new CategoricalDataPoint(_graph.Max, values.Key.ToString()));
			}

			radChartView1.Series.AddRange(lineSeries, lineSeriesMin, lineSeriesMax, lineSeriesNorm);

			radRangeSelector1.AssociatedControl = this.radChartView1;
			var categoricalAxis = radChartView1.Axes[0] as CategoricalAxis;
			categoricalAxis.PlotMode = AxisPlotMode.OnTicksPadded;
			categoricalAxis.LabelFitMode = AxisLabelFitMode.Rotate;
			categoricalAxis.LabelRotationAngle = 300;

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


			radChartView1.ShowLegend = true;
			this.radChartView1.LegendTitle = "Legend";
		}
	}
}
