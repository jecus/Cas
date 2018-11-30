using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.DetailsControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl
{
    /// <summary>
    /// Элемент управления для добавления агрегата
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredDetailAddingScreen : DetailAddingScreen, IDisplayingEntity
    {

        #region Constructor

        ///<summary>
        /// Создается элемент отображения добавления агрегата
        ///</summary>
        /// <param name="parentDetail">Базовый агрегат для которго добавляется агрегат</param>
        public DispatcheredDetailAddingScreen(IDetailContainer parentDetail) : base(parentDetail)
        {
            Dock = DockStyle.Fill;
        }

        #endregion
        
        #region Properties

        #region public object ContainedData

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return parentBaseDetail; }
            set
            {
                if (value is BaseDetail)
                    parentBaseDetail = (BaseDetail)value;
            }
        }

        #endregion

        #endregion
        
        #region Methods

        #region public bool ContainedDataEquals(IDisplayingEntity obj)
        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredDetailAddingScreen))
                return false;
            if (!(obj.ContainedData is BaseDetail))
                return false;
            if (!(parentBaseDetail is CoreType)) return false;
            return ((CoreType) parentBaseDetail).ID == ((CoreType) obj.ContainedData).ID;
        }

        #endregion

        #region public void OnInitCompletion(object sender)

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
            //if (generalInformationControl.GetChangeStatus() || compliancePerformanceListControl.GetChangeStatusOfNewDetail() || warrantyControl.GetChangeStatus() || (parentBaseDetail is Store && storeControl.GetChangeStatus()))
            if (generalInformationControl.GetChangeStatus() || warrantyControl.GetChangeStatus(addedDetail) || (isStore && storeControl.GetChangeStatus(addedDetail)))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        if (!AddNewDetail(false))
                            arguments.Cancel = true;
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

        #endregion

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {

        }

        #endregion

        #region public void SetEnabled(bool isEnbaled)

        /// <summary>
        /// Метод меняюший состояние конторола [:|||:]
        /// </summary>
        /// <param name="isEnbaled">состояние</param>
        public void SetEnabled(bool isEnbaled)
        {

        }

        #endregion
        
        #endregion

        #region Events

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        #endregion

    }
}
