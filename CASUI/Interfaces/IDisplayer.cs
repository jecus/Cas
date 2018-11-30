using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Interfaces
{
    /// <summary>
    /// Provides a functional of displayer-control
    /// </summary>
    public interface IDisplayer
    {
        /// <summary>
        /// Entity which is displayed
        /// </summary>
        IDisplayingEntity Entity
        {
            get;
            set;
        }

        /// <summary>
        /// Text of displayer's header
        /// </summary>
        string Text{ get; set;}

        /// <summary>
        /// Perform or no checkins before closing displayer
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
        /// Occurs when the current displayer is removed from control collection
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
    }
}