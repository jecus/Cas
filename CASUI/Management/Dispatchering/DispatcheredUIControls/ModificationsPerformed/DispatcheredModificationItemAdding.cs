using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.ModificationsPerformed;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.ModificationsPerformed
{
    /// <summary>
    /// Класс, описывающий отображение добавления <see cref="ModificationItem"/>
    /// </summary>
    public class DispatcheredModificationItemAdding : ModificationItemAdding, IDisplayingEntity
    {
        #region Constructor

        /// <summary>
        /// Создается объект, описывающий отображение добавления <see cref="ModificationItem"/> 
        /// </summary>
        /// <param name="parentAircraft"></param>
        public DispatcheredModificationItemAdding(Aircraft parentAircraft) : base(parentAircraft)
        {
        }

        #endregion

        #region Properties

        #region public object ContainedData
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return parentAircraft; }
            set
            {
                if (value is Aircraft)
                    parentAircraft = (Aircraft)value;
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
            if (!(obj is DispatcheredModificationItemAdding))
                return false;
            if (!(obj.ContainedData is Aircraft))
                return false;
            if (parentAircraft == null) 
                return false;

            return (parentAircraft.ID == ((Aircraft)obj.ContainedData).ID);
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
            if (modificationItemControl.GetChangeStatus(false))
            {
                switch (MessageBox.Show("Do you want to save changes?", (string)new TermsProvider()["SystemName"],
                                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                                        MessageBoxDefaultButton.Button1))
                {
                    case DialogResult.Yes:
                        if (!AddNewModificationItem(false))
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

        #endregion
    }
}
