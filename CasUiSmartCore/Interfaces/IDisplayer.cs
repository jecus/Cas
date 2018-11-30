using System;
using AvControls.AvMultitabControl;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Interfaces
{
    /// <summary>
    /// Интерфейс самой вкладки: 
    /// </summary>
    public interface IDisplayer
    {
        #region IDisplayingEntity Entity
        /// <summary>
        /// Скрин, отображаемый вкладкой
        /// </summary>
        IDisplayingEntity Entity
        {
            get; set;
        }
        #endregion

        /// <summary>
        /// Текст заголовка вкладки
        /// </summary>
        string Text{ get; set;}

        /// <summary>
        /// Выполнять ли проветку перед закрытием отображателя
        /// </summary>
        bool PerformCloseChecking { get; set; }

        /// <summary>
        /// Invokes displaying of default entity
        /// </summary>
        void Show();

        /// <summary>
        /// Invokes displaying of entity
        /// </summary>
        /// <param name="entity">Entity to display</param>
        void Show(IDisplayingEntity entity);

        /// <summary>
        /// Checks whether contained data of two displayers are equal
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool ContainedDataEquals(IDisplayer obj);

        /// <summary>
        /// Checks whether displaying entities have same type
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool ContainedDisplayingEntityEquals(IDisplayer obj);

        /// <summary>
        /// Возникает при удвлении отображателя
        /// </summary>
        event EventHandler DisplayerRemoving;

        /// <summary>
        /// Проверяется возможность удаления отображателя
        /// </summary>
        /// <param name="arguments"></param>
        void OnDisplayerRemoving(DisplayerCancelEventArgs arguments);

        /// <summary>
        /// Возникает после удаления отображателя
        /// </summary>
        event EventHandler DisplayerRemoved;

        /// <summary>
        /// Проверяется возможность удаление отображателя
        /// </summary>
        /// <param name="arguments"></param>
        void OnDisplayerRemoved(DisplayerCancelEventArgs arguments);

        /// <summary>
        /// Действия, происходящие при деактвации отображателя
        /// </summary>
        /// <param name="arguments"></param>
        void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments);

        #region  Для кнопок вперед и назад
        /// <summary>
        /// Для открытия предыдущей страници в данной вкладке
        /// </summary>
        void PreviousPage();
        /// <summary>
        /// Для открытия следующей страници в данной вкладке
        /// </summary>
        void NextPage();

        ///<summary>
        /// Происходит при смене отображаемого скрина в данной вкладке
        ///</summary>
        event EventHandler ScreenChanged;

        ///<summary>
        /// Показывает есть-ли PreviousPage
        ///</summary>
        ///<returns></returns>
        bool CanPreviousPage();

        ///<summary>
        /// Показывает есть-ли NextPage
        ///</summary>
        ///<returns></returns>
        bool CanNextPage();
        #endregion

        #region Для кнопки закрытия вкладки

        /// <summary>
        /// Событие, сигнализирующее об изменении количества вкладок у родителя данной вкладки
        /// </summary>
        event EventHandler CountScreenChanget;

        /// <summary>
        /// Показывает активность кнопки закрытия данной вкладки
        /// </summary>
        /// <returns></returns>
        bool CanEnableCloseTab();
        #endregion

        #region Обработка кнопки закрытия формы
        /// <summary>
        /// Вызывается при нажатии кнопки закрытия программы
        /// </summary>
        event EventHandler ClosingWindow;

        /// <summary>
        /// Вызывает событие ClosingWindow
        /// </summary>
        void OnClosingWindow();

        /// <summary>
        /// Вызывается при отмене закрытия программы 
        /// </summary>
        event EventHandler CancelClosingWindow;

        /// <summary>
        /// Вызывает событие  CancelClosingWindow
        /// </summary>
        void OnCancelClosingWindow();
        #endregion
       
        /// <summary>
        /// Доступ к родительскому элементу
        /// </summary>
        AvMultitabControl ParentControl { get; }
    }
}