using System.Windows.Forms;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.UI.Interfaces;
using LTR.UI.UIControls.DiscrepanciesControls;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls
{
    /// <summary>
    /// 
    /// </summary>
    internal partial class DispatcheredUIDiscrepancyCollection : DiscrepanciesScreen, IDisplayingEntity
    {
        private object containedData;

        public DispatcheredUIDiscrepancyCollection(Aircraft currentAircraft) : base(currentAircraft)
        {
            containedData = currentAircraft;
            Dock = DockStyle.Fill;
        }

        public DispatcheredUIDiscrepancyCollection(BaseDetail currentBaseDetail) : base(currentBaseDetail)
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
            if (obj is DispatcheredUIDiscrepancyCollection)
            {
                if (containedData is Aircraft && obj.ContainedData is Aircraft)
                    return ((Aircraft)containedData).ID == ((Aircraft)obj.ContainedData).ID && AppliedFilter.Equals(((DispatcheredUIDiscrepancyCollection)obj).AppliedFilter);
                if (containedData is BaseDetail && obj.ContainedData is BaseDetail)
                    return ((BaseDetail)containedData).ID == ((BaseDetail)obj.ContainedData).ID && AppliedFilter.Equals(((DispatcheredUIDiscrepancyCollection)obj).AppliedFilter);
            }
            return false;
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
        #endregion
    }
}
