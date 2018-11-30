using System;
using System.ComponentModel;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Interfaces
{
    /// <summary>
    /// Интерфейс, определяет сущность, которая может отображаться в объектах IDisplayer
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
        /// Метод, вызывается после добавления содежимого на отображатель(вкладку)
        /// </summary>
        void OnInitCompletion(object sender);

        /// <summary>
        /// Возникает во время удаления отображателя данного содержимого
        /// </summary>
        /// <param name="arguments"></param>
        void OnDisplayerRemoving(DisplayerCancelEventArgs arguments);

        /// <summary>
        /// Возникает после удаления отображателя данного содержимого
        /// </summary>
        void OnDisplayerRemoved();

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
        /// Событие, вызывается после добавление содержимого на отображатель (вкладку)
        /// </summary>
        event EventHandler InitComplition;
       
        /// <summary>
        /// Событие, оповещающее о начале удаления содержимого
        /// </summary>
        event EventHandler<EntityCancelEventArgs> EntityRemoving;

        /// <summary>
        /// Возникает после удаления содержимого
        /// </summary>
        event EventHandler EntityRemoved;

    }
}