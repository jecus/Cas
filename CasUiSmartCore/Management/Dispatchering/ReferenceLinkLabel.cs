using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.Management.Dispatchering
{
    ///<summary>
    /// Элемент управления ввиде гипер-ссылки, который может создавать запрос о предоставлении вкладки для некого содержимого
    ///</summary>
    public class ReferenceLinkLabel : LinkLabel, IReference
    {
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
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType { get; set; }

        #endregion

        #endregion

        #region Methods

        #region protected void OnDisplayerRequested()

        protected void OnDisplayerRequested()
        {
            if (null != DisplayerRequested)
            {
                ReflectionTypes reflection = ReflectionType;
                Keyboard k = new Keyboard();
                if (k.ShiftKeyDown && reflection == ReflectionTypes.DisplayInCurrent) reflection = ReflectionTypes.DisplayInNew;
                if (null != Displayer)
                {
                    DisplayerRequested(this, new ReferenceEventArgs(Entity, reflection, Displayer, DisplayerText));
                }
                else
                {
                    DisplayerRequested(this, new ReferenceEventArgs(Entity, reflection, DisplayerText));
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