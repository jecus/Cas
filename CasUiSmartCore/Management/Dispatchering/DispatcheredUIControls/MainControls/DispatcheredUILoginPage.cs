using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.MainControls;
using CASTerms;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.MainControls
{
    internal partial class DispatcheredUILoginPage : UILoginPage, IDisplayingEntity, IReference
    { 
        private bool _canBeClosed;

        public DispatcheredUILoginPage()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region Implementation of IDisplayingEntity

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }

        public void SetEnabled(bool isEnbaled)
        {

        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        /// <summary>
        /// Событие, оповещающее об удаленни содержимого (вкладку)
        /// </summary>
        public event EventHandler<EntityCancelEventArgs> EntityRemoving;

        #region public event EventHandler DisplayerRemoved;
        /// <summary>
        /// Возникает после удаления содержимого
        /// </summary>
        public event EventHandler EntityRemoved;

        #endregion

        public void DisposeScreen()
        {
            Dispose(true);
        }

        #endregion

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

        protected override void DispatcheredLoginControlConnected(object sender, EventArgs e)
        {
            base.DispatcheredLoginControlConnected(sender, e);
            OnDisplayerRequested();
        }

        private void OnDisplayerRequested()
        {
            _canBeClosed = true;
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
            if (arguments.ControlType == ControlType.Trivial && !_canBeClosed)
            {
                MessageBox.Show("Closing this tab can cause impossible work.", new GlobalTermsProvider()["SystemName"].ToString(), MessageBoxButtons.OK,
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

        #region public void OnDisplayerRemoved()

        public void OnDisplayerRemoved()
        {

        }

        #endregion
    }
}
