using System;
using System.Windows.Forms;
using CAS.Core.ProjectTerms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.MainControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls
{
    internal partial class DispatcheredUILoginPage : UILoginPage, IDisplayingEntity, IReference
    { 
        private bool canBeClosed = false;

        public DispatcheredUILoginPage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members
        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return this; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (obj is DispatcheredUILoginPage)
            {
                return true;
            }
            return false;
        }
        #endregion

        protected override void dispatcheredLoginControl_Connected(object sender, EventArgs e)
        {
            OnDisplayerRequested();
            base.dispatcheredLoginControl_Connected(sender, e);
        }

        private void OnDisplayerRequested()
        {
            canBeClosed = true;
            if (DisplayerRequested != null)
            {
                DisplayerRequested(this, new ReferenceEventArgs(Entity, ReflectionType, ""));
            }
        }

        #region IReference Members

        /// <summary>
        /// Displayer for displaying entity
        /// </summary>
        public IDisplayer Displayer
        {
            get { return null; }
            set { }
        }

        /// <summary>
        /// Text of page's header that Reference lead to
        /// </summary>
        public string DisplayerText
        {
            get { return ""; }
            set { }
        }

        /// <summary>
        /// Entity to display
        /// </summary>
        public IDisplayingEntity Entity
        {
            get { return this; }
            set { }
        }

        /// <summary>
        /// Type of reflection
        /// </summary>
        public ReflectionTypes ReflectionType
        {
            get { return ReflectionTypes.CloseDisplayerContainingEntity; }
            set { }
        }

        /// <summary>
        /// Occurs when linked invoker requests displaying 
        /// </summary>
        public event EventHandler<ReferenceEventArgs> DisplayerRequested;

        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (arguments.ControlType == ControlType.Trivial && !canBeClosed)
            {
                MessageBox.Show("Closing this tab can cause impossible work.", new TermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                arguments.Cancel = true;
            }
        }

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        #endregion
    }
}
