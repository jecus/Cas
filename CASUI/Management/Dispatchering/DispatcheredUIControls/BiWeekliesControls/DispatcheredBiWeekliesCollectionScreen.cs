using System;
using System.Windows.Forms;
using CAS.Core.Types.Dictionaries;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.BiWeekliesReportsControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.BiWeekliesControls
{
    public class DispatcheredBiWeekliesCollectionScreen : BiWeekliesCollectionScreen, IDisplayingEntity
    {
        
        public DispatcheredBiWeekliesCollectionScreen()
        {
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members

        public object ContainedData
        {
            get
            {
                return BiWeekliesCollection;
            }
            set
            {
                if (!(value is BiWeekliesCollection))
                    throw new ArgumentException("Argument must be of type BiWeekliesCollection");
                BiWeekliesCollection = value as BiWeekliesCollection;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredBiWeekliesCollectionScreen)) return false;

            DispatcheredBiWeekliesCollectionScreen collection = obj as DispatcheredBiWeekliesCollectionScreen;
            return (collection.ContainedData == ContainedData);

        }

        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null) InitComplition(sender, new EventArgs());
        }

        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                if (!processes[i].HasExited)
                    processes[i].Kill();
            }
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
