using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.PersonnelControls.EmployeeControls;
using CASTerms;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Personnel;
using SmartCore.Purchase;

namespace CAS.UI.UIControls.PersonnelControls.EmployeeTraining
{
    ///<summary>
    /// ЭУ для отображения информации о русурсе деталей и параметрах выполнения директив
    ///</summary>
    public partial class EmployeeTrainingListControl : UserControl
    {
		private Specialist _currentItem;
	    private List<Supplier> _suppliers;
	    private List<AircraftModel> _aircraftModels;
	    private IEnumerable<EmployeeLicenceGeneralControl> _employeeLicenceControl;

	    #region Constructor

		public EmployeeTrainingListControl()
	    {
		    InitializeComponent();
	    }

		#endregion

		#region public void UpdateControl(Specialist currentItem)

		public void UpdateControl(Specialist currentItem, List<Supplier> suppliers, List<AircraftModel> aircraftModels, IEnumerable<EmployeeLicenceGeneralControl> employeeLicenceControl)
	    {
		    if (currentItem == null)
			    return;
		    _suppliers = suppliers;
			_currentItem = currentItem;
		    _aircraftModels = aircraftModels;
		    _employeeLicenceControl = employeeLicenceControl;

			if (currentItem.SpecialistTrainings.Count > 0)
				flowLayoutPanelPerformances.Controls.Clear();

		    foreach (var training in currentItem.SpecialistTrainings)
			    AddTrainingControl(training, aircraftModels);
	    }

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";

			foreach (var control in flowLayoutPanelPerformances.Controls.OfType<EmployeeTrainingControl>())
				control.ValidateData(out message);

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
		{
			var trainingControls = flowLayoutPanelPerformances.Controls.OfType<EmployeeTrainingControl>();
			return trainingControls.Any(e => e.GetChangeStatus());
		}

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			foreach (var control in flowLayoutPanelPerformances.Controls.OfType<EmployeeTrainingControl>())
				control.ApplyChanges();
		}

		#endregion

		#region private void AddTrainingControl(SpecialistTraining training)

		private void AddTrainingControl(SpecialistTraining training, List<AircraftModel> aircraftModels)
	    {
		    var control = new EmployeeTrainingControl();
		    control.UpdateInformation(training, _suppliers, aircraftModels, _employeeLicenceControl);
			control.Deleted += Control_Deleted;
		    flowLayoutPanelPerformances.Controls.Remove(linkLabelAddNew);
		    flowLayoutPanelPerformances.Controls.Add(control);
		    flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
	    }
		#endregion

		#region private void Control_Deleted(object sender, System.EventArgs e)

		private void Control_Deleted(object sender, EventArgs e)
	    {
		    var control = sender as EmployeeTrainingControl;

		    var dialogResult = MessageBox.Show("Do you really want to delete Training?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
		    if (dialogResult == DialogResult.Yes)
		    {
			    if (control.CurrentTraining.ItemId > 0)
			    {
				    try
				    {
					    GlobalObjects.CasEnvironment.Manipulator.Delete(control.CurrentTraining, false);
				    }
				    catch (Exception ex)
				    {
					    Program.Provider.Logger.Log("Error while removing data", ex);
				    }
			    }
			    flowLayoutPanelPerformances.Controls.Remove(control);
			    control.Deleted -= Control_Deleted;
			    control.Dispose();
		    }
	    }

	    #endregion

		#region private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var newSpecialistTraining = new SpecialistTraining();
			_currentItem.SpecialistTrainings.Add(newSpecialistTraining);
			AddTrainingControl(newSpecialistTraining, _aircraftModels);
		}

	    #endregion
	}
}
