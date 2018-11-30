using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl
{
    /// <summary>
    /// Класс для отображения детали
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredDetailScreen : DetailScreen, IDisplayingEntity
    {
        /// <summary>
        /// Отображаемая деталь
        /// </summary>
        private AbstractDetail detail;

        ///<summary>
        /// Создается элемент отображения агрегата
        ///</summary>
        /// <param name="detail">Деталь для отображения</param>
        public DispatcheredDetailScreen(AbstractDetail detail): base(detail)
        {
            if (detail == null) throw new ArgumentNullException("detail");
            this.detail = detail;
        }

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return detail; }
            set
            {
                if (value is AbstractDetail)
                    detail = (AbstractDetail)value;
            }
        }

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        bool IDisplayingEntity.ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredDetailScreen))
                return false;
            if (!(obj.ContainedData is AbstractDetail))
                return false;
            return detail.ID == ((AbstractDetail)obj.ContainedData).ID;
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
            if (baseDetailHeaderControl.GetChangeStatus() || generalInformationControl.GetChangeStatus() || warrantyControl.GetChangeStatus() || easaControl.GetChangeStatus() || (!currentDetail.InUse && storeControl.GetChangeStatus()))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        if (!SaveData())
                            arguments.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
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
