using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Обычная кнопка реализующая интерфейс <see cref="IReference"/>
    /// </summary>
    public class ReferenceSimpleButton : Button, IReference
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

        #region public ReferenceSimpleButton(): this(null, null, ReflectionTypes.DisplayInNew, null)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        public ReferenceSimpleButton(): this(null, null, ReflectionTypes.DisplayInNew, null)
        {
        }
        
        #endregion

        #region public ReferenceSimpleButton(IDisplayingEntity entity, ReflectionTypes reflectionType)
        
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public ReferenceSimpleButton(IDisplayingEntity entity, ReflectionTypes reflectionType)
            : this(null, entity, reflectionType)
        {
        }
        
        #endregion

        #region public ReferenceSimpleButton(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public ReferenceSimpleButton(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
            : this(null, entity, reflectionType, displayerText)
        {
        }

        #endregion

        #region public ReferenceSimpleButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType)
        
        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public ReferenceSimpleButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType) 
            : this(displayer, entity, reflectionType, "")
        {
        }
        
        #endregion

        #region public ReferenceSimpleButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public ReferenceSimpleButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
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

        /// <summary>
        /// Метод обработки события DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                //ReflectionTypes reflection = reflectionType;
                //Keyboard keyboard = new Keyboard();
                //if (keyboard.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                if (null != displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflectionType, displayer, displayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(entity, reflectionType, displayerText));
                }
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
        
        #region public IDisplayer Displayer
        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return displayer; }
            set { displayer = value; }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return displayerText; }
            set { displayerText = value; }
        }
        #endregion

        #region public DisplayingEntity Entity
        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection [:|||:]
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }
        #endregion

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion
    }
}
