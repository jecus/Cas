using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ComplianceControls;
using CAS.UI.UIControls.ComponentChangeReport;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.ComponentChangeControl
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class DispatcheredComponentChangeScreen : ComponentChangeScreen, IDisplayingEntity
    {
        private object containedData;

        public DispatcheredComponentChangeScreen(Aircraft currentAircraft) : base(currentAircraft)
        {
            containedData = currentAircraft;
            Dock = DockStyle.Fill;
        }


        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return containedData; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (obj is DispatcheredComponentChangeScreen)
            {
                return ((Aircraft) containedData).ID == ((Aircraft) obj.ContainedData).ID;
            }
            return false;
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }
        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
        }

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        public void SetEnabled(bool isEnbaled)
        {

        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion
    }
}