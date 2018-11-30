using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AircraftsControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.AircraftsControls
{
    /// <summary>
    /// Элемент управления, отображающий информацию о ВС
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredAircraftScreen : AircraftScreen, IDisplayingEntity
    {

        /// <summary>
        /// Создаёт экземпляр элемента управления, отображающего воздушное судно
        /// </summary>
        ///<param name="aircraft">Воздушное судно для отображения</param>
        ///<exception cref="ArgumentNullException"></exception>
        public DispatcheredAircraftScreen(Aircraft aircraft) : base(aircraft)
        {
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return currentAircraft; }
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
            if (!(obj is DispatcheredAircraftScreen)) 
                return false;
            if (!(obj.ContainedData is Aircraft)) 
                return false;

            return (currentAircraft.ID == ((Aircraft) obj.ContainedData).ID);
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
            SetEnabledToControls(isEnbaled);
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion


    }
}
