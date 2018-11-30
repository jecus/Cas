using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core;
using CAS.Core.Types;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.StoresControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.StoresControls
{
    /// <summary>
    /// Элемент управления для отображения списка агрегатов склада
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredShouldBeOnStockScreen : ShouldBeOnStockScreen, IDisplayingEntity
    {

        #region Fields

        private Store store;
        private Operator currentOperator;

        #endregion

        #region Constructors

        #region public DispatcheredShouldBeOnStockScreen(Store store) : base(store)

        /// <summary>
        /// Создает элемент управления для отображения списка агрегатов склада
        /// </summary>
        public DispatcheredShouldBeOnStockScreen(Store store) : base(store)
        {
            this.store = store;
            Dock = DockStyle.Fill;
        }

        #endregion

        #region public DispatcheredShouldBeOnStockScreen(Operator op) : base(op)

        /// <summary>
        /// Создает элемент управления для отображения списка агрегатов склада
        /// </summary>
        public DispatcheredShouldBeOnStockScreen(Operator op) : base(op)
        {
            currentOperator = op;
            Dock = DockStyle.Fill;
        }

        #endregion
        
        #endregion

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get
            {
                if (store != null)
                    return store;
                else
                    return currentOperator;
            }
            set
            {
                if (value is Store)
                    store = (Store)value;
                else
                    currentOperator = (Operator) value;
            }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredShouldBeOnStockScreen))
                return false;
            if (!(obj.ContainedData is CoreType))
                return false;
            if (store != null)
                return (store.ID == ((CoreType) obj.ContainedData).ID);
            else
                return (currentOperator.ID == ((CoreType)obj.ContainedData).ID);
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
          //  SetEnabledToControls(isEnbaled);
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion
    }
}
