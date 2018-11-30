using System;
using Controls.AvButtonT;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    ///  ласс, дополн€ющий <see cref="AvButtonT"/> дл€ того, чтобы за ней производилс€ контроль диспетчером
    /// </summary>
    public class RichReferenceButton:AvButtonT,IReference
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

        #region public RichReferenceButton() : this(null,null,ReflectionTypes.DisplayInNew, "")

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        public RichReferenceButton() : this(null,null,ReflectionTypes.DisplayInNew, "")
        {
        }
        
        #endregion

        #region public RichReferenceButton(IDisplayingEntity entity, ReflectionTypes reflectionType) : this(null, entity, reflectionType)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public RichReferenceButton(IDisplayingEntity entity, ReflectionTypes reflectionType) : this(null, entity, reflectionType)
        {
        }
        
        #endregion

        #region public RichReferenceButton(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText) : this(null, entity, reflectionType, displayerText)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public RichReferenceButton(IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText) : this(null, entity, reflectionType, displayerText)
        {
        }

        #endregion

        #region public RichReferenceButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType) : this(displayer, entity, reflectionType, "")

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        public RichReferenceButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType) : this(displayer, entity, reflectionType, "")
        {
        }
        
        #endregion

        #region public RichReferenceButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)

        /// <summary>
        /// Creates new instance of reference avbutton
        /// </summary>
        /// <param name="displayer">Displayer in which entity should be displayed</param>
        /// <param name="entity">Entity to display</param>
        /// <param name="reflectionType">Type of displaying</param>
        /// <param name="displayerText">Text to display</param>
        public RichReferenceButton(IDisplayer displayer, IDisplayingEntity entity, ReflectionTypes reflectionType, string displayerText)
        {
            this.displayer = displayer;
            this.entity = entity;
            this.reflectionType = reflectionType;
            this.displayerText = displayerText;
            Click += RichReferenceButton_Click;
        }
        
        #endregion

        #endregion

        #region Properties

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
        
        #region public DisplayingEntity Entity
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

        #region Methods

        #region protected void OnDisplayerRequested()

        /// <summary>
        /// ћетод обработки событи€ DisplayerRequested
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

        #region private void RichReferenceButton_Click(object sender, EventArgs e)

        private void RichReferenceButton_Click(object sender, EventArgs e)
        {
            OnDisplayerRequested();
        }

        #endregion

        #region public void DisplayRequested()

        public void DisplayRequested()
        {
            OnDisplayerRequested();
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
