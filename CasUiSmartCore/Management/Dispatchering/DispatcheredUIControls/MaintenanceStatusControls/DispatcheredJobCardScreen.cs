using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.MaintenanceStatusControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls
{
    public class DispatcheredJobCardScreen : JobCardScreen, IDisplayingEntity
    {
        public DispatcheredJobCardScreen(MaintenanceJobCard jobCard) : base(jobCard)
        {
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members

        public object ContainedData
        {
            get
            {
                return jobCard;
            }
            set
            {
                jobCard = (MaintenanceJobCard)value;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredJobCardScreen))
                return false;
            if (!(obj.ContainedData is MaintenanceJobCard))
                return false;
            return false; //todo !!
            //return (jobCard.ID == ((JobCard)obj.ContainedData).ID);
        }

        public void OnInitCompletion(object sender)
        {
            
        }

        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (GetChangeStatus())
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new StaticProjectTermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        SaveData();
                        arguments.Cancel = false;
                        break;
                    case DialogResult.No:
                        arguments.Cancel = false;
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        public event EventHandler InitComplition;

        #endregion
    }
}
