using System;
using System.Windows.Forms;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.MaintenanceStatusControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls
{
    public class DispatcheredJobCardsCollectionScreen: MaintenanceJobCardsCollectionScreen, IDisplayingEntity
    {

        public DispatcheredJobCardsCollectionScreen(MaintenanceSubCheck subCheck) : base(subCheck)
        {
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members

        public object ContainedData
        {
            get
            {
                return subCheck;
            }
            set
            {
                subCheck = (MaintenanceSubCheck)value;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredJobCardsCollectionScreen)) return false;
            if (!(obj.ContainedData is MaintenanceSubCheck))
                return false;
            return (subCheck.ID == ((MaintenanceSubCheck)obj.ContainedData).ID);
        }

        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null) InitComplition(sender, new EventArgs());
        }

        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
        }

        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        public void SetEnabled(bool isEnbaled)
        {
            
        }

        public event EventHandler InitComplition;

        #endregion
    }
}
