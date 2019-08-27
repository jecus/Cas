using CAS.UI.UIControls.OilControls.Model;
using MetroFramework.Forms;
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
			_graph = graph;
			InitializeComponent();

			Initialize();
			FillData();
		}

		#endregion

		private void FillData()
		{
			foreach (var baseComponent in _graph.Graph)
			{
				var lineSeries = new LineSeries()
				{
					ShowLabels = true,
					Spline = true,
					Name = baseComponent.Key.ToString()
				};

				foreach (var values in baseComponent.Value)
					lineSeries.DataPoints.Add(new CategoricalDataPoint(values.Value, values.Key.ToString()));

				radChartView1.Series.Add(lineSeries);
			}

			AddScale();
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

		void AddScale()
		{
			var verticalAxis = radChartView1.Axes.Get<LinearAxis>(1);

			var scaleBreakItem = new AxisScaleBreak { Name = "Min", From = _graph.Min };
			var scaleBreakItem1 = new AxisScaleBreak { Name = "Normal", From = _graph.Normal };
			var scaleBreakItem2 = new AxisScaleBreak { Name = "Max", From = _graph.Max };
			verticalAxis.ScaleBreaks.Add(scaleBreakItem);
			verticalAxis.ScaleBreaks.Add(scaleBreakItem1);
			verticalAxis.ScaleBreaks.Add(scaleBreakItem2);
		}


	}
}
