using System;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using Microsoft.VisualBasic.Devices;

namespace CAS.UI.UIControls.OpepatorsControls
{
    /// <summary>
    /// Элемент управления отображения информации о эксплуатанте
    /// </summary>
    public class ReferenceOperatorListItem : OperatorListItem, IReference
    {

        #region Fields

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;

        #endregion
        
        #region Methods

        #region protected void OnDisplayerRequested()
        /// <summary>
        /// Occurs when requested associated displayer
        /// </summary>
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

        #region protected override void OnClick(EventArgs e)
        /// <summary>
        /// Occurs when control has been clicked
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            OnDisplayerRequested();
            base.OnClick(e);
        }
        #endregion

        #endregion

        #region IReference Members
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

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return entity; }
            set { entity = value; }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return reflectionType; }
            set { reflectionType = value; }
        }
        
        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;
        #endregion
    }
}