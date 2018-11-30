using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения коллекций шаблонов
    /// </summary>
    public class DispatcheredTemplateAircraftCollectionScreen : TemplateAircraftCollectionScreen, IDisplayingEntity
    {
        /// <summary>
        /// Создает элемент управления для отображения коллекций шаблонов
        /// </summary>
        public DispatcheredTemplateAircraftCollectionScreen()
        {
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return this; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (obj is DispatcheredTemplateAircraftCollectionScreen)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>

        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition!=null) 
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
            base.SetEnabledToControls(isEnbaled);
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion
    }
}