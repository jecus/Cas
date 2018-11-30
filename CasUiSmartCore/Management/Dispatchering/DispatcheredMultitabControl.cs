using System;
using System.ComponentModel;
using System.Windows.Forms;
using AvControls;
using AvControls.AvMultitabControl;
using AvControls.AvMultitabControl.Auxiliary;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Implimentation of AvMultitabControl that can be Date by <see cref="Dispatcher"/>
    /// </summary>
    public class DispatcheredMultitabControl : AvMultitabControl, IDisplayerCollectionProxy
    {
        private bool _closingCanBeCanceled;

        #region Constructors

        #endregion
                
        #region Properties

        #region public IDisplayer Selected
        /// <summary>
        /// Currently selected IDisplayer
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IDisplayer Selected
        {
            get { return SelectedTab as IDisplayer; }
            set { Select(value); }
        }
        #endregion

        #region public List<IDisplayer> ContainedDisplayers
        /// <summary>
        /// All contained IDisplayers
        /// </summary>
        public IDisplayer[] ContainedDisplayers
        {
            get
            {
                IDisplayer[] tabPages = new IDisplayer[TabCount];
                for (int i = 0; i < TabPages.Count; i++)
                {
                    IDisplayer displayer = TabPages[i] as IDisplayer;
                    tabPages[i] = displayer;
                }
                return tabPages;
            }
        }


        #endregion

        /// <summary>
        /// Свойство - может ли закрытие вкладок быть отменено
        /// </summary>
        public bool ClosingCanBeCanceled
        {
            get { return _closingCanBeCanceled; }
            set { _closingCanBeCanceled = value; }
        }

        #endregion

        #region Methods

        #region private bool ControlAllowedToAdd(Control control)
        /// <summary>
        /// Checks wether control can be added to collection of controls
        /// </summary>
        /// <param name="control">Control</param>
        /// <returns>true if control can be added or false otherwise</returns>
        private bool ControlAllowedToAdd(Control control)
        {
            bool IsExistingDisplayer = control is IDisplayer;
            bool IsServiceButton = control is ServiceButton;
            return IsExistingDisplayer || IsServiceButton;
        }
        #endregion

        #region protected override void OnSelecting(AvMultitabControlCancelEventArgs e)

        /// <summary>
        /// Event of page selecting
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnSelecting(AvMultitabControlCancelEventArgs e)
        {
            IDisplayer associatedDisplayer = e.TabPage as IDisplayer;
            base.OnSelecting(e);
            if (DisplayerSelecting != null)
            {
                DisplayerSelecting(this, new DisplayerCancelEventArgs(associatedDisplayer, DisplayerAction.Selecting));
            }
            
        }
        #endregion

        #region protected override void OnSelected(AvMultitabControlEventArgs e)
        /// <summary>
        /// Event of page already selected
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnSelected(AvMultitabControlEventArgs e)
        {
            IDisplayer associatedDisplayer = e.TabPage as IDisplayer;
            base.OnSelected(e);
            if (DisplayerSelected != null)
            {
                DisplayerSelected(this, new DisplayerEventArgs(associatedDisplayer));
            }
        }
        #endregion

        #region protected override void OnControlAdded(ControlEventArgs e)
        /// <summary>
        /// Event of added control
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnControlAdded(ControlEventArgs e)
        {
            IDisplayer associatedDisplayer = e.Control as IDisplayer;
            DisplayerCancelEventArgs eventArguments =
                new DisplayerCancelEventArgs(associatedDisplayer, DisplayerAction.Adding);
            if (DisplayerAdding != null && associatedDisplayer != null)
                DisplayerAdding(this, eventArguments);
            if (ControlAllowedToAdd(e.Control) && !eventArguments.Cancel)
            {
                base.OnControlAdded(e);
                if (DisplayerAdded != null)
                    DisplayerAdded(this, new DisplayerEventArgs(associatedDisplayer));
            }
            else
            {
                CloseTab(e.Control as MultitabPage);
                Invalidate();
            }
        }
        #endregion

        #region protected override void OnClosing(AvMultitabControlCancelEventArgs e)

        /// <summary>
        /// Метод вызывающийся перед закрытием вкладки
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(AvMultitabControlCancelEventArgs e)
        {
            IDisplayer associatedDisplayer = e.TabPage as IDisplayer;
            if (associatedDisplayer == null) return;
            if (!associatedDisplayer.PerformCloseChecking) return;
            DisplayerCancelEventArgs eventArguments =
                new DisplayerCancelEventArgs(associatedDisplayer, DisplayerAction.Removing);
            
            if (DisplayerDeleting != null)
                DisplayerDeleting(this, eventArguments);

            //Оповещение о начале удаления вкладки
            associatedDisplayer.OnDisplayerRemoving(eventArguments);
            //Если вкладка запросила отменить удаление, операция прекращается
            if (eventArguments.Cancel)
            {
                e.Cancel = true;
                return;
            }

            //Оповещение о окончании удаления вкладки
            associatedDisplayer.OnDisplayerRemoved(eventArguments);
            //Если вкладка запросила отменить закрытие, операция прекращается
            if (eventArguments.Cancel)
            {
                e.Cancel = true;
                return;
            }

            e.Cancel = eventArguments.Cancel;
            base.OnClosing(e);

            if (!eventArguments.Cancel)
            {
                if (DisplayerDeleted != null)
                {
                    DisplayerDeleted(this, new DisplayerEventArgs(associatedDisplayer));
                }
            }
        }

        #endregion

        #region protected override void OnDeselecting(AvMultitabControlCancelEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeselecting(AvMultitabControlCancelEventArgs e)
        {
            IDisplayer associatedDisplayer = e.TabPage as IDisplayer;
            if (associatedDisplayer == null) return;
            DisplayerCancelEventArgs eventArguments =
                new DisplayerCancelEventArgs(associatedDisplayer, DisplayerAction.Removing);
            associatedDisplayer.OnDisplayerDeselecting(eventArguments);
            e.Cancel |= eventArguments.Cancel;
            base.OnDeselecting(e);
        }
        #endregion

        #region protected override void OnControlRemoved(ControlEventArgs e)
        /// <summary>
        /// Event of control removed
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected override void OnControlRemoved(ControlEventArgs e)
        {
            IDisplayer associatedDisplayer = e.Control as IDisplayer;
            base.OnControlRemoved(e);
            if (DisplayerDeleted != null)
            {
                DisplayerDeleted(this, new DisplayerEventArgs(associatedDisplayer));
            }
        }
        #endregion

        #region public void Select(IDisplayer objectToSelect)
        /// <summary>
        /// Sets focus to IDisplayer contained at collection
        /// </summary>
        /// <param name="objectToSelect"><see cref="IDisplayer">IDisplayer</see> that gets focus</param>
        public void Select(IDisplayer objectToSelect)
        {
            if (objectToSelect is MultitabPage)
                SelectTab(objectToSelect as MultitabPage);
        }

        /// <summary>
        /// Checks if displayer is contained
        /// </summary>
        /// <param name="displayer">Displayer to be checked</param>
        /// <returns></returns>
        public bool Contains(IDisplayer displayer)
        {
            MultitabPage displayerPage = displayer as MultitabPage;
            if (displayerPage != null)
                return TabPages.Contains(displayerPage);
            return false;
        }

        /// <summary>
        /// Adds displayer to collection of Displayers
        /// </summary>
        /// <param name="displayer">Added item</param>
        public void Add(IDisplayer displayer)
        {
            if (null == displayer) throw new ArgumentNullException("displayer");
            if (!(displayer is MultitabPage)) throw new ArgumentException("Displayer must be AvTabPage");
            if (Contains(displayer)) Select(displayer);
            TabPages.Add(displayer as MultitabPage);
        }

        /// <summary>
        /// Removes displayer from collection of Displayers
        /// </summary>
        /// <param name="displayer">Removed item</param>
        /// <returns>Result of operation</returns>
        /// <param name="performCloseChecking">Perform or not checking before closing</param>
        public bool Remove(IDisplayer displayer, bool performCloseChecking)
        {
            if (null == displayer) throw new ArgumentNullException("displayer");
            if (!(displayer is MultitabPage)) throw new ArgumentException("Displayer must be AvTabPage");
            displayer.PerformCloseChecking = performCloseChecking;
            CloseTab(displayer as MultitabPage);
            return !TabPages.Contains(displayer as MultitabPage);
        }

        /// <summary>
        /// Creates new instance of Displayer for control
        /// </summary>
        /// <param name="objectToDisplay">Entity, that should be displayed at displayer</param>
        /// <returns></returns>
        public IDisplayer CreateNewDisplayer(IDisplayingEntity objectToDisplay)
        {
            
            DispatcheredTabPage newPage = new DispatcheredTabPage();
            newPage.Show(objectToDisplay);
            return CreateNewDisplayer(objectToDisplay, "");
        }


        /// <summary>
        /// Creates new instance of Displayer for control
        /// </summary>
        /// <param name="objectToDisplay">Entity, that should be displayed at displayer</param>
        /// <param name="text">Text of tabpage's header</param>
        /// <returns></returns>
        public IDisplayer CreateNewDisplayer(IDisplayingEntity objectToDisplay, string text)
        {
            
            DispatcheredTabPage newPage = new DispatcheredTabPage(text);
            newPage.Owner = this;
            newPage.Show(objectToDisplay);
            return newPage;
        }
        #endregion

        #region public override MultitabPage CreateNewTabPage(string caption)

        ///<summary>
        /// New object of tab page is created
        ///</summary>
        ///<param name="caption">Caption of tab page</param>
        ///<returns>Created object</returns>
        public override MultitabPage CreateNewTabPage(string caption)
        {
            return new DispatcheredTabPage(caption);
        }

        #endregion

        #region public override MultitabPage CreateNewTabPage()

        ///<summary>
        /// New object of tab page is created
        ///</summary>
        ///<returns>Created object</returns>
        public override MultitabPage CreateNewTabPage()
        {
            return CreateNewTabPage("");
        }

        #endregion

        #region public override Type TypeOfPages

        ///<summary>
        /// Type of pages, used at control
        ///</summary>
        public override Type TypeOfPages
        {
            get
            {
                return typeof(DispatcheredTabPage);
            }
        }

        #endregion

        #region public void SetEnabledToAllEntityes(bool isEnabled)
        /// <summary>
        /// Изменяет состояние каждого из Entityes
        /// </summary>
        /// <param name="isEnabled">состояние</param>
        public void SetEnabledToAllEntityes(bool isEnabled)
        {
            for (int i = 0; i < ContainedDisplayers.Length; i++)
            {
                ContainedDisplayers[i].Entity.SetEnabled(isEnabled);
            }
        }

        #endregion

        #endregion

        #region Events

        #region public event EventHandler<DisplayerCancelEventArgs> DisplayerAdding
        /// <summary>
        /// Occurs when Displayer is being added to collection
        /// </summary>
        public event EventHandler<DisplayerCancelEventArgs> DisplayerAdding;
        #endregion

        #region public event EventHandler<DisplayerEventArgs> DisplayerAdded
        /// <summary>
        /// Occurs when Displayer has been added to collection
        /// </summary>
        public event EventHandler<DisplayerEventArgs> DisplayerAdded;
        #endregion

        #region public event EventHandler<DisplayerCancelEventArgs> DisplayerDeleting
        /// <summary>
        /// Occurs when Displayer is being deleted from collection
        /// </summary>
        public event EventHandler<DisplayerCancelEventArgs> DisplayerDeleting;
        #endregion

        #region public event EventHandler<DisplayerEventArgs> DisplayerDeleted
        /// <summary>
        /// Occurs when Displayer has been deleted from collection
        /// </summary>
        public event EventHandler<DisplayerEventArgs> DisplayerDeleted;
        #endregion

        #region public event EventHandler<DisplayerCancelEventArgs> DisplayerSelecting
        /// <summary>
        /// Occurs when Displayer is being selected
        /// </summary>
        public event EventHandler<DisplayerCancelEventArgs> DisplayerSelecting;
        #endregion

        #region public event EventHandler<DisplayerEventArgs> DisplayerSelected
        /// <summary>
        /// Occurs when Displayer has been selected
        /// </summary>
        public event EventHandler<DisplayerEventArgs> DisplayerSelected;
        #endregion

        #region public event EventHandler ProxyClientRemoved
        /// <summary>
        /// Occurs when client of proxy has been removed
        /// </summary>
#pragma warning disable 0067
        public event EventHandler ProxyClientRemoved;
#pragma warning restore 0067
        #endregion

        #endregion
    }
}