using System;
using System.ComponentModel;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Arguments of events for displayer
    /// </summary>
    public class DisplayerEventArgs : EventArgs
    {
        #region Fields
        /// <summary>
        /// Displayer that event happenes with
        /// </summary>
        private IDisplayer displayer;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new Event arguments
        /// </summary>
        /// <param name="displayer">Displayer that event happenes with</param>
        public DisplayerEventArgs(IDisplayer displayer)
        {
            this.displayer = displayer;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Displayer that event happened with
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
        }
        #endregion
    }

    /// <summary>
    /// Arguments of events for displayer, that can be canceled
    /// </summary>
    public class DisplayerCancelEventArgs : CancelEventArgs
    {
        #region Fields
        /// <summary>
        /// Type of action of event
        /// </summary>
        private DisplayerAction action;
        /// <summary>
        /// Displayer that event happenes with
        /// </summary>
        private IDisplayer displayer;
        /// <summary>
        /// Тип управления
        /// </summary>
        private ControlType controlType;
        #endregion
        
        #region Constructors

        /// <summary>
        /// Creates new instance of event arguments
        /// </summary>
        /// <param name="displayer">Displayer that event happenes with</param>
        /// <param name="controlType">Тип управления</param>
        public DisplayerCancelEventArgs(IDisplayer displayer, ControlType controlType)
        {
            this.displayer = displayer;
            this.controlType = controlType;
        }

        /// <summary>
        /// Creates new instance of event arguments
        /// </summary>
        /// <param name="cancel">Should event be canceled by default</param>
        /// <param name="displayer">Displayer that event happenes with</param>
        /// <param name="action">Type of action of event</param>
        public DisplayerCancelEventArgs(bool cancel, IDisplayer displayer, DisplayerAction action) : base(cancel)
        {
            this.displayer = displayer;
            this.action = action;
            controlType = ControlType.Trivial;
        }

        /// <summary>
        /// Creates new instance of event arguments
        /// </summary>
        /// <param name="displayer">Displayer that event happenes with</param>
        /// <param name="action">Type of action of event</param>
        public DisplayerCancelEventArgs(IDisplayer displayer, DisplayerAction action)
        {
            this.displayer = displayer;
            this.action = action;
            controlType = ControlType.Trivial;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Displayer that event happenes with
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
        }
        /// <summary>
        /// Type of action of event
        /// </summary>
        public DisplayerAction Action
        {
            get { return action; }
        }


        /// <summary>
        /// Тип управления
        /// </summary>
        public ControlType ControlType
        {
            get { return controlType; }
        }

        #endregion
    }

    /// <summary>
    /// Type of action
    /// </summary>
    public enum DisplayerAction
    {
        /// <summary>
        /// Action of displayer adding
        /// </summary>
        Adding,

        /// <summary>
        /// Action when displayer added
        /// </summary>
        Added,

        /// <summary>
        /// Action of displayer removing
        /// </summary>
        Removing,

        /// <summary>
        /// Action when displayer removed
        /// </summary>
        Removed,

        /// <summary>
        /// Action of displayer selecting
        /// </summary>
        Selecting,

        /// <summary>
        /// Action when displayer selected
        /// </summary>
        Selected,

        /// <summary>
        /// Action of displayer deselecting
        /// </summary>
        Deselecting,

        /// <summary>
        /// Action when displayer deselected
        /// </summary>
        Deselected,

        /// <summary>
        /// Action of displayer closing
        /// </summary>
        Closing,

        /// <summary>
        /// Action when displayer
        /// </summary>
        Closed
    }
}