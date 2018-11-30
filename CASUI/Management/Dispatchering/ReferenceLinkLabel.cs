using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.Management.Dispatchering
{
    public class ReferenceLinkLabel : LinkLabel, IReference
    {

        #region Fields

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion
        
        #region Properties

        #region public IDisplayer Displayer

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get
            {
                return displayer;
            }
            set
            {
                displayer = value;
            }
        }

        #endregion

        #region public string DisplayerText

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get
            {
                return displayerText;
            }
            set
            {
                displayerText = value;
            }
        }

        #endregion

        #region public IDisplayingEntity Entity

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get
            {
                return entity;
            }
            set
            {
                entity = value;
            }
        }

        #endregion

        #region public ReflectionTypes ReflectionType

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get
            {
                return reflectionType;
            }
            set
            {
                reflectionType = value;
            }
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
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
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

        #region protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)

        protected override void OnLinkClicked(LinkLabelLinkClickedEventArgs e)
        {
            base.OnLinkClicked(e);

            if (e.Button == MouseButtons.Left)
            {
                OnDisplayerRequested();
                base.OnClick(e);
            }
        }

        #endregion
        
        #region protected override void OnClick(EventArgs e)

        protected override void OnClick(EventArgs e)
        {
        }

        #endregion
        
        #endregion

        #region public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

    }
}