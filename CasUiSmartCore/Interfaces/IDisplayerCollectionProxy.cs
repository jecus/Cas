using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Interfaces
{
    /// <summary>
    /// Provides methods of IDisplayer containing object
    /// </summary>
    public interface IDisplayerCollectionProxy
    {

        #region Properties

        #region IDisplayer Selected

        /// <summary>
        /// Currently selected IDisplayer
        /// </summary>
        IDisplayer Selected { get; set; }

        #endregion

        #region IDisplayer[] ContainedDisplayers

        /// <summary>
        /// All contained IDisplayers
        /// </summary>
        IDisplayer[] ContainedDisplayers { get;}

        #endregion

        #region bool ClosingCanBeCanceled

        /// <summary>
        /// Свойство - может ли закрытие вкладок быть отменено
        /// </summary>
        bool ClosingCanBeCanceled
        {
            get; set;
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Sets focus to IDisplayer contained at collection
        /// </summary>
        /// <param name="objectToSelect"><see cref="IDisplayer">IDisplayer</see> that gets focus</param>
        void Select(IDisplayer objectToSelect);

        /// <summary>
        /// Checks if displayer is contained
        /// </summary>
        /// <param name="displayer">Displayer to be checked</param>
        /// <returns></returns>
        bool Contains(IDisplayer displayer);

        /// <summary>
        /// Adds displayer to collection of Displayers
        /// </summary>
        /// <param name="displayer">Added item</param>
        void Add(IDisplayer displayer);

        /// <summary>
        /// Removes displayer from collection of Displayers
        /// </summary>
        /// <param name="displayer">Removed item</param>
        /// <returns>Result of operation</returns>
        /// <param name="performCloseChecking">Perform or not checking before closing</param>
        bool Remove(IDisplayer displayer, bool performCloseChecking);

        /// <summary>
        /// Creates new instance of Displayer for control
        /// </summary>
        /// <param name="objectToDisplay">Entity, that should be displayed at displayer</param>
        /// <returns></returns>
        IDisplayer CreateNewDisplayer(IDisplayingEntity objectToDisplay);

        /// <summary>
        /// Creates new instance of Displayer for control
        /// </summary>
        /// <param name="objectToDisplay">Entity, that should be displayed at displayer</param>
        /// <param name="text">Text of tabpage's header</param>
        /// <returns></returns>
        IDisplayer CreateNewDisplayer(IDisplayingEntity objectToDisplay, string text);

        #endregion

        #region Events
        /// <summary>
        /// Occurs when Displayer is being added to collection
        /// </summary>
        event EventHandler<DisplayerCancelEventArgs> DisplayerAdding;
        /// <summary>
        /// Occurs when Displayer has been added to collection
        /// </summary>
        event EventHandler<DisplayerEventArgs> DisplayerAdded;
        /// <summary>
        /// Occurs when Displayer is being deleted from collection
        /// </summary>
        event EventHandler<DisplayerCancelEventArgs> DisplayerDeleting;
        /// <summary>
        /// Событие, оповещающее об удалении отображателя из коллекции
        /// </summary>
        event EventHandler<DisplayerEventArgs> DisplayerDeleted;
        /// <summary>
        /// Occurs when Displayer is being selected
        /// </summary>
        event EventHandler<DisplayerCancelEventArgs> DisplayerSelecting;
        /// <summary>
        /// Occurs when Displayer has been selected
        /// </summary>
        event EventHandler<DisplayerEventArgs> DisplayerSelected;
        /// <summary>
        /// Occurs when Control is removed from control collection
        /// </summary>
        event EventHandler ProxyClientRemoved;

        /// <summary>
        /// Occurs when a new control is added to the System.Windows.Forms.Control.ControlCollection.
        /// </summary>
        event ControlEventHandler ControlAdded;

        #endregion
    }
}