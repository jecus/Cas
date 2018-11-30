using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.WorkPackages;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.WorkPackages
{
    ///<summary>
    /// Элемент управления для отображения списка рабочих пакетов
    ///</summary>
    [ToolboxItem(false)]
    public class DispatcheredWorkPackagesListScreen : WorkPackagesListScreen, IDisplayingEntity
    {

        #region Constructor

        ///<summary>
        /// Создаёт элемент управления для отображения списка рабочих пакетов
        ///</summary>
        ///<param name="currentAircraft">ВС, которому принадлежат рабочие пакеты</param>
        public DispatcheredWorkPackagesListScreen(Aircraft currentAircraft) : base(currentAircraft)
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
            get
            {
                return currentAircraft;
            }
            set
            {
                if (value is Aircraft)
                    currentAircraft = value as Aircraft;
            }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredWorkPackagesListScreen)) return false;
            if (!(obj.ContainedData is Aircraft)) return false;

            return (currentAircraft.ID == ((Aircraft)obj.ContainedData).ID);
        }

/*        public void Show()
        {
            throw new NotImplementedException();
        }*/

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
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

        /// <summary>
        /// Метод меняюший состояние конторола [:|||:]
        /// </summary>
        /// <param name="isEnbaled">состояние</param>
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
