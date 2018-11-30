using System;
using AvControls.StatusImageLink;
using CAS.UI.Interfaces;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Ёлемент управлени€ StatusImageLinkLabel поддерживающий переход по ссылке
    /// </summary>
    public class ReferenceStatusImageLinkLabel : StatusImageLinkLabel,IReference
    {
        #region Fields

        #endregion

        #region Constructors

        #region public ReferenceStatusImageLinkLabel()

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        public ReferenceStatusImageLinkLabel()
        {
        }

        #endregion

        #region public ReferenceStatusImageLinkLabel(IDisplayingEntity entity, ReflectionTypes reflectionType)
        
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public ReferenceStatusImageLinkLabel(IDisplayingEntity entity, ReflectionTypes reflectionType)
            : this(null, entity, reflectionType)
        {
        }
        
        #endregion

        #region public ReferenceStatusImageLinkLabel(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public ReferenceStatusImageLinkLabel(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
            : this(null, entity, reflectionType, displayerText)
        {
        }

        #endregion

        #region public ReferenceStatusImageLinkLabel(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType)
        
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public ReferenceStatusImageLinkLabel(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType) 
            : this(displayer, entity, reflectionType, "")
        {
        }
        
        #endregion

        #region public ReferenceStatusImageLinkLabel(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public ReferenceStatusImageLinkLabel(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
        {
            Displayer = displayer;
            Entity = entity;
            ReflectionType = reflectionType;
            DisplayerText = displayerText;   
        }

        #endregion


        #endregion

        #region Methods

        #region private void OnDisplayerRequested()

        /// <summary>
        /// ћетод обработки событи€ DisplayerRequested
        /// </summary>
        private void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && ReflectionType == ReflectionTypes.DisplayInCurrent) ReflectionType = ReflectionTypes.DisplayInNew;
                DisplayerRequested(this,
                                   null != Displayer
                                       ? new ReferenceEventArgs(Entity, ReflectionType, Displayer, DisplayerText)
                                       : new ReferenceEventArgs(Entity, ReflectionType, DisplayerText));
            }
        }

        #endregion

        #region protected override void OnClick(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Control.Click"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnClick(EventArgs e)
        {
            OnDisplayerRequested();
            base.OnClick(e);
        }

        #endregion

        #endregion

        #region Properties

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer { get; set; }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText { get; set; }

        #endregion

        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity { get; set; }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        #endregion

        #endregion

        #region Event

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #endregion
    }
}
