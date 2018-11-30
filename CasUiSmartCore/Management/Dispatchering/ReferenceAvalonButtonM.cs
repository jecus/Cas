using System;
using System.Collections.Generic;
using System.Text;
using Controls.AvalonButtonM;
using Controls.AvButtonT;
using LTR.UI.Interfaces;
using Microsoft.VisualBasic.Devices;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls
{
    public class ReferenceAvalonButtonM : AvButtonT, IReference
    {
        #region Fields

        #region private IDisplayer displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        private IDisplayer displayer;
        #endregion

        #region private DisplayingEntity entity
        /// <summary>
        /// Entity to display
        /// </summary>
        private IDisplayingEntity entity;
        #endregion

        #region private ReflectionTypes reflectionType
        private string displayerText;
        private ReflectionTypes reflectionType;
        #endregion

        #endregion

        #region Constructors

        #region public ReferenceAvalonButtonM()
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        public ReferenceAvalonButtonM()
        {
        }
        #endregion

        #region public ReferenceAvalonButtonM(IDisplayingEntity entity, ReflectionTypes reflectionType)
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public ReferenceAvalonButtonM(IDisplayingEntity entity, ReflectionTypes reflectionType)
            : this(null, entity, reflectionType)
        {
        }
        #endregion

        #region public ReferenceAvalonButtonM(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public ReferenceAvalonButtonM(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
            : this(null, entity, reflectionType, displayerText)
        {
        }
        #endregion

        #region public ReferenceAvalonButtonM(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType)
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public ReferenceAvalonButtonM(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType) 
            : this(displayer, entity, reflectionType, "")
        {
        }
        #endregion

        #region public ReferenceAvalonButtonM(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public ReferenceAvalonButtonM(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
        {
            this.displayer = displayer;
            this.entity = entity;
            this.reflectionType = reflectionType;
            this.displayerText = displayerText;
        }
        #endregion

        #endregion

        #region Methods

        #region protected void OnDisplayerRequested()
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = reflectionType;
                Keyboard keyboard = new Keyboard();
                if (keyboard.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                if (null != displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflection, displayerText));
                }
            }
        }
        #endregion

        #region protected override void OnClick(EventArgs e)
        protected override void OnClick(EventArgs e)
        {
            OnDisplayerRequested();
            base.OnClick(e);
        }
        #endregion

        #endregion

        #region Displayer

        #region public IDisplayer Displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }
        #endregion

        #region public string DisplayerText
        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }
        #endregion

        #endregion

        #region public DisplayingEntity Entity

        #region public IDisplayingEntity Entity
        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }
        #endregion

        #region public ReflectionTypes ReflectionType
        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }
        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        #endregion
    }
}
