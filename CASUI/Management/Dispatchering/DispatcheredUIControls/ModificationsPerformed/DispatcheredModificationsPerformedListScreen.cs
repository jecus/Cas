using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ModificationsPerformed;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.ModificationsPerformed
{
    /// <summary>
    /// Элемент управления для работы со списком <see cref="ModificationItem"/> 
    /// </summary>
    public class DispatcheredModificationsPerformedListScreen : ModificationsPerformedListScreen, IDisplayingEntity
    {

        #region Fields

        private Aircraft parentAircraft;

        #endregion

        #region Constructor

        /// <summary>
        /// Создаёт элемент управления для работы со списком <see cref="ModificationItem"/> 
        /// </summary>
        ///<param name="parentAircraft">ВС, к которому принадлежат ModificationItems</param>
        public DispatcheredModificationsPerformedListScreen(Aircraft parentAircraft): base(parentAircraft)
        {
            this.parentAircraft = parentAircraft;
            Dock = DockStyle.Fill;
        }

        #endregion

        #region IDisplayingEntity Members

        public object ContainedData
        {
            get
            {
                return parentAircraft;
            }
            set
            {
                if (value is Aircraft)
                    parentAircraft = value as Aircraft;
            }
        }

        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredModificationsPerformedListScreen)) return false;
            if (!(obj.ContainedData is Aircraft)) return false;

            return (parentAircraft.ID == ((Aircraft)obj.ContainedData).ID);
        }

        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());
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