using System;
using System.Windows.Forms;
using AvControls.AvButtonT;
using CAS.UI.Interfaces;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    ///  ласс, дополн€ющий <see cref="AvButtonT"/> дл€ того, чтобы за ней производилс€ контроль диспетчером
    /// </summary>
    public class RichReferenceButton:AvButtonT,IReference
    {

        #region Fields

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
            Displayer = displayer;
            Entity = entity;
            ReflectionType = reflectionType;
            DisplayerText = displayerText;
            Click += RichReferenceButtonClick; 
        }
        
        #endregion

        #endregion

        #region protected override void Dispose(bool disposing)
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Click -= RichReferenceButtonClick;

                if (base.ContextMenuStrip != null)
                    foreach (ToolStripMenuItem item in base.ContextMenuStrip.Items)
                        item.Click -= ItemClick;
            }
            base.Dispose(disposing);
        }
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
        
        #region public DisplayingEntity Entity

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

        ///<summary>
        ///</summary>
        public override ContextMenuStrip ContextMenuStrip
        {
            get { return base.ContextMenuStrip; }
            set
            {  
                if(base.ContextMenuStrip != null && base.ContextMenuStrip.Items.Count > 0)
                    foreach (ToolStripMenuItem item in base.ContextMenuStrip.Items)
                        item.Click -= ItemClick;
                base.ContextMenuStrip = value;
                
                if (value == null) return;
                foreach (ToolStripMenuItem item in value.Items)
                    item.Click += ItemClick;
            }
        }
        #endregion

        #region Methods

        #region protected void OnDisplayerRequested()

        /// <summary>
        /// ћетод обработки событи€ DisplayerRequested
        /// </summary>
        protected void OnDisplayerRequested(object sender)
        {
            if (null != DisplayerRequested)
            {
                Keyboard keyboard = new Keyboard();
                if (keyboard.ShiftKeyDown && ReflectionType == ReflectionTypes.DisplayInCurrent) ReflectionType = ReflectionTypes.DisplayInNew;
                DisplayerRequested(sender, null != Displayer
                                       ? new ReferenceEventArgs(Entity, ReflectionType, Displayer, DisplayerText)
                                       : new ReferenceEventArgs(Entity, ReflectionType, DisplayerText));
            }
        }

        #endregion

        #region private void RichReferenceButtonClick(object sender, EventArgs e)

        private void RichReferenceButtonClick(object sender, EventArgs e)
        {
            ContextMenuStrip cms = ContextMenuStrip;
            if (cms != null) cms.Show(this, Left, Bottom);
            else OnDisplayerRequested(sender);
        }

        #endregion

        #region void ItemClick(object sender, EventArgs e)
        void ItemClick(object sender, EventArgs e)
        {
            OnDisplayerRequested(sender);
        }
        #endregion

        #region public void DisplayRequested()

        //public void DisplayRequested()
        //{
        //    OnDisplayerRequested();
        //}

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RichReferenceButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "RichReferenceButton";
            this.ResumeLayout(false);

        }

        #endregion

    }
}
