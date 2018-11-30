using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ModificationsPerformed;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.ModificationsPerformed
{
    /// <summary>
    /// Элемент управления для отображения <see cref="ModificationItem"/>
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredModificationItemScreen : ModificationItemScreen, IDisplayingEntity
    {
        #region Constructor

        /// <summary>
        /// Создает элемент управления для отображения <see cref="ModificationItem"/>
        /// </summary>
        /// <param name="item">Сам ModofocationItem</param>
        ///// <param name="parentAircraft">ВС, которому принадлежит ModificationItem</param>
        public DispatcheredModificationItemScreen(ModificationItem item) : base(item)//, Aircraft parentAircraft) : base(item, parentAircraft)
        {
            Dock = DockStyle.Fill;
        }

        #endregion

        #region IDisplayingEntity Members

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return currentItem; }
            set
            {
                if (value is ModificationItem)
                    currentItem = (ModificationItem)value;
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
            if (!(obj is DispatcheredModificationItemScreen))
                return false;
            if (!(obj.ContainedData is ModificationItem))
                return false;
            return currentItem.ID == ((ModificationItem)obj.ContainedData).ID;
        }

        public void OnInitCompletion(object sender)
        {
        }

        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (modificationItemControl.GetChangeStatus(true))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        SaveData();
                        break;
                    case DialogResult.Cancel:
                        arguments.Cancel = true;
                        break;
                }
            }
        }

        #endregion

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

        public event EventHandler InitComplition;

        #endregion
        
    }
}