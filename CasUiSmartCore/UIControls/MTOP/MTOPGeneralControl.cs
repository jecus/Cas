using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPGeneralControl : UserControl
	{
		private Aircraft _currentAircraft;
		private AnimatedThreadWorker _animatedThreadWorker;

		#region Constructor

		public MTOPGeneralControl()
		{
			InitializeComponent();
		}

		#endregion

		public void UpdateControl(Aircraft currentAircraft, List<MTOPCheck> maintenanceChecks,AnimatedThreadWorker animatedThreadWorker)
		{
			_currentAircraft = currentAircraft;
			_animatedThreadWorker = animatedThreadWorker;

			mtopCheckListView1.SetItemsArray(maintenanceChecks.ToArray());

			var frame = GlobalObjects.CasEnvironment.BaseComponents.FirstOrDefault(i =>
				i.ParentAircraftId == _currentAircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Frame));
			averageUtilizationItemControl1.UpdateControl(frame);
		}

		#region private void avButtonAddCheck_Click(object sender, EventArgs e)

		private void avButtonAddCheck_Click(object sender, EventArgs e)
		{
			var newMTOP = new MTOPCheck{ParentAircraftId = _currentAircraft.ItemId};

			var form = new MTOPEditForm(newMTOP);
			if(form.ShowDialog() == DialogResult.OK)
				_animatedThreadWorker.RunWorkerAsync();

		}

		#endregion

		#region private void avButtonEditCheck_Click(object sender, EventArgs e)

		private void avButtonEditCheck_Click(object sender, EventArgs e)
		{
			if (mtopCheckListView1.SelectedItems.Count != 1)
				return;

			var form = new MTOPEditForm(mtopCheckListView1.SelectedItem);
			if (form.ShowDialog() == DialogResult.OK)
				_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void avButtonDeleteCheck_Click(object sender, EventArgs e)

		private void avButtonDeleteCheck_Click(object sender, EventArgs e)
		{
			if (mtopCheckListView1.SelectedItems.Count == 0)
				return;

			var confirmResult = MessageBox.Show(
				"Do you really want to delete MTOPs ?", "Confirm delete operation",
				MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (confirmResult == DialogResult.Yes)
			{
				try
				{
					mtopCheckListView1.radGridView1.BeginUpdate();

					foreach (var item in mtopCheckListView1.SelectedItems)
						GlobalObjects.NewKeeper.Delete(item, true);

					mtopCheckListView1.radGridView1.EndUpdate();
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while deleting data", ex);
					return;
				}
				_animatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void mtopCheckListView1_SelectedItemsChanged_1(object sender, Auxiliary.SelectedItemsChangeEventArgs e)

		private void mtopCheckListView1_SelectedItemsChanged_1(object sender, SelectedItemsChangeEventArgs e)
		{
			avButtonEditCheck.Enabled = mtopCheckListView1.SelectedItems.Count == 1;
			avButtonDeleteCheck.Enabled = mtopCheckListView1.SelectedItems.Count > 0;
		}

		#endregion

		//TODO:Сохраняем утилизацию для Frame(в форме утилизации когда сохраняем Frame еще и добавляем утилизацию в LDG) разобраться зачем
		public bool SaveData()
		{
			var engines = GlobalObjects.CasEnvironment.BaseComponents.Where(i =>
				i.ParentAircraftId == _currentAircraft.ItemId && Equals(i.BaseComponentType, BaseComponentType.Engine));

			var au = averageUtilizationItemControl1.GetAverageUtilization();

			foreach (var engine in engines)
			{
				engine.AverageUtilization = au;
				GlobalObjects.NewKeeper.Save(engine);
			}

			return averageUtilizationItemControl1.SaveData();
		}
	}
}
