using System;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    internal class ReferenceUILoginControl : LoginControl,IReference
    {
        #region Fields

        private IDisplayer displayer;
        private string displayerText;
        private IDisplayingEntity entity;
        private ReflectionTypes reflectionType;
        private EventHandler connectedAction;
        
        #endregion

        #region Constructors

        public ReferenceUILoginControl()
        {
            
        }

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

        public EventHandler ConnectedAction
        {
            get { return connectedAction; }
            set { connectedAction = value; }
        }

        protected override void OnConnectedAction()
        {
            base.OnConnectedAction();
            if (ConnectedAction != null) 
                ConnectedAction.Invoke(null, EventArgs.Empty);
        }

        #region Methods

        protected void OnDisplayerRequested( ReferenceEventArgs e)
        {
            if (null != DisplayerRequested) 
            {
                if (null != displayer)
                {
                    // Серега и Леха были здесь. Улыбнуло
                    DisplayerRequested(this, e);
                }
                else
                {
                    DisplayerRequested(this, e);
                }
            }
        }

        public void DisplayObject( ReferenceEventArgs e)
        {
            OnDisplayerRequested(e);
        }
        #endregion

     
    }
}