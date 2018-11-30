using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Interfaces
{
    /// <summary>
    /// Represents some kind of data that can be displayed via IDisplayer
    /// </summary>
    public interface IDisplayingEntity
    {
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        object ContainedData{ get; set;}

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        bool ContainedDataEquals(IDisplayingEntity obj);

        /// <summary>
        /// Invoke control to show data
        /// </summary>
        void Show();

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
        void OnInitCompletion(object sender);

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        void OnDisplayerRemoving(DisplayerCancelEventArgs arguments);

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments);

        /// <summary>
        /// Метод меняюший состояние конторола [:|||:]
        /// </summary>
        /// <param name="isEnbaled">состояние</param>
        void SetEnabled(bool isEnbaled);

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        event EventHandler InitComplition;
    }
}