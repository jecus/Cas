using System;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.DiscrepanciesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DiscrepanciesControls
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class DispatcheredDiscrepanciesScreen : DiscrepanciesScreen, IDisplayingEntity
    {
        private object containedData;

        public DispatcheredDiscrepanciesScreen(Aircraft currentAircraft) : base(currentAircraft)
        {
            containedData = currentAircraft;
            Dock = DockStyle.Fill;
        }

        public DispatcheredDiscrepanciesScreen(BaseDetail currentBaseDetail) : base(currentBaseDetail)
        {
            containedData = currentBaseDetail;
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
            if (obj is DispatcheredDiscrepanciesScreen)
            {
                if (containedData is Aircraft && obj.ContainedData is Aircraft)
                    return ((Aircraft)containedData).ID == ((Aircraft)obj.ContainedData).ID && AppliedFilter.Equals(((DispatcheredDiscrepanciesScreen)obj).AppliedFilter);
                if (containedData is BaseDetail && obj.ContainedData is BaseDetail)
                    return ((BaseDetail)containedData).ID == ((BaseDetail)obj.ContainedData).ID && AppliedFilter.Equals(((DispatcheredDiscrepanciesScreen)obj).AppliedFilter);
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
            SetPageEnable(isEnbaled);
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion
    }
}