using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using System.Drawing;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.PowerPlants
{
	public partial class PowerPlantListScreen : ScreenControl
	{
		private ICommonCollection<BaseComponent> _initialDocumentArray = new CommonCollection<BaseComponent>();
		private PowerPlantListView _directivesViewer;

		#region Constructor

		public PowerPlantListScreen()
		{
			InitializeComponent();
		}

		public PowerPlantListScreen(Operator currentOperator)
			: this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");

			aircraftHeaderControl1.Operator = currentOperator;

			InitListView();

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDocumentArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load BaseComponents");

			_initialDocumentArray.AddRange(GlobalObjects.CasEnvironment.BaseComponents.Where(c => c.BaseComponentType == BaseComponentType.Engine));

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_initialDocumentArray.ToArray());
			_directivesViewer.Focus();
		}

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new PowerPlantListView
			{
				TabIndex = 2,
				Location = new Point(panel1.Left, panel1.Top),
				Dock = DockStyle.Fill,
				IgnoreAutoResize = true
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion`
	}
}
