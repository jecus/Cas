using System;
using System.Windows.Forms;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.MaintenanceStatusControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.MaintenanceStatusControls
{
    /// <summary>
    /// </summary>
    public class DispatcheredSubChecksCollectionScreen : MaintenanceSubChecksCollectionScreen, IDisplayingEntity
    {
        /// <summary>
        /// </summary>
        public DispatcheredSubChecksCollectionScreen(MaintenanceDirective directive) : base(directive)
        {
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members

        public object ContainedData
        {
            get
            {
                return directive;
            }
            set
            {
                directive = (MaintenanceDirective) value;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredSubChecksCollectionScreen)) return false;

            DispatcheredSubChecksCollectionScreen collection = obj as DispatcheredSubChecksCollectionScreen;
            return (collection.ContainedData == ContainedData);
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
