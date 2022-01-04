using System;
using System.Windows.Forms;

namespace CAS.UI.UICAAControls.CheckList
{
    ///<summary>
    /// ЭУ для отображения информации о русурсе деталей и параметрах выполнения директив
    ///</summary>
    public partial class AuditListControl : UserControl
    {

	    #region Constructor

		public AuditListControl()
	    {
            
	    }

		#endregion

		#region public void UpdateControl(Specialist currentItem)

		public void UpdateControl()
	    {
		    
	    }

		#endregion

		#region public bool ValidateData(out string message)

		public bool ValidateData(out string message)
		{
			message = "";

			//foreach (var control in flowLayoutPanelPerformances.Controls.OfType<AuditControl>())
			//	control.ValidateData(out message);

			if (message != "")
				return false;
			return true;
		}

		#endregion

		#region public bool GetChangeStatus()

		public bool GetChangeStatus()
        {
            return true;
        }

		#endregion

		#region public void ApplyChanges()

		public void ApplyChanges()
		{
			//foreach (var control in flowLayoutPanelPerformances.Controls.OfType<AuditControl>())
				//control.ApplyChanges();
		}

		#endregion

		#region private void AddTrainingControl(SpecialistTraining training)

		private void AddTrainingControl()
	    {
		    var control = new AuditControl();
		    //control.UpdateInformation(training, _suppliers, aircraftModels, _employeeLicenceControl);
			//control.Deleted += Control_Deleted;
		    flowLayoutPanelPerformances.Controls.Remove(linkLabelAddNew);
		    flowLayoutPanelPerformances.Controls.Add(control);
		    flowLayoutPanelPerformances.Controls.Add(linkLabelAddNew);
	    }
		#endregion

		#region private void Control_Deleted(object sender, System.EventArgs e)

		private void Control_Deleted(object sender, EventArgs e)
	    {
		    var control = sender as AuditControl;

		    var dialogResult = MessageBox.Show("Do you really want to delete Training?", "Deleting confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
		    if (dialogResult == DialogResult.Yes)
		    {
			    //if (control.CurrentTraining.ItemId > 0)
			    //{
				   // try
				   // {
					  //  GlobalObjects.CasEnvironment.Manipulator.Delete(control.CurrentTraining, false);
				   // }
				   // catch (Exception ex)
				   // {
					  //  Program.Provider.Logger.Log("Error while removing data", ex);
				   // }
			    //}
			    //flowLayoutPanelPerformances.Controls.Remove(control);
			    //control.Deleted -= Control_Deleted;
			    //control.Dispose();
		    }
	    }

	    #endregion

		#region private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)

		private void linkLabelAddNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
            //var newSpecialistTraining = new SpecialistTraining();
            //_currentItem.SpecialistTrainings.Add(newSpecialistTraining);
            //AddTrainingControl(newSpecialistTraining, _aircraftModels);
            AddTrainingControl();

        }

	    #endregion
	}
}
