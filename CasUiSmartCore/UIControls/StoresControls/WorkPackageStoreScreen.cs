using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.StoresControls
{
	public partial class WorkPackageStoreScreen : ScreenControl
	{
		private CommonCollection<WorkPackage> _workPackages = new CommonCollection<WorkPackage>();

		#region Constructor

		public WorkPackageStoreScreen()
		{
			InitializeComponent();
		}

		public WorkPackageStoreScreen(Store store) : this()
		{
			if (store == null)
				throw new ArgumentNullException("store", "Cannot display null-store");

			CurrentStore = store;

			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			comboBoxWorkPackage.Items.Clear();
			comboBoxWorkPackage.Items.AddRange(_workPackages.ToArray());
			comboBoxWorkPackage.DisplayMember = "Number";
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_workPackages.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load WorkPackages");

			_workPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackages(status:WorkPackageStatus.Opened));
			_workPackages.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackages(status:WorkPackageStatus.Published));

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		private void ButtonCalculateClick(object sender, EventArgs e)
		{
			if(comboBoxWorkPackage.SelectedItem == null)
				return;

			var selectedWp = comboBoxWorkPackage.SelectedItem as WorkPackage;
			var equipmentAndMaterail = GlobalObjects.KitsCore.GetAllWorkPackageKits(selectedWp.ItemId);
		}
	}
}
