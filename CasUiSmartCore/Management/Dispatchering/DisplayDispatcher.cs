using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    internal class DisplayDispatcher : IDispatcher
    {
        #region Fields

        private List<IDisplayer> previousPositonsDisplayrList;
        private List<IDisplayer> nextPositonsDisplayrList;
        private IDisplayer _currentDisplayer;
        private bool _useEvent;

        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of Dispathcer, for specified Proxy
        /// </summary>
        /// <param name="defaultProxy">Proxy, to be observed and dispatchered</param>
        public DisplayDispatcher(IDisplayerCollectionProxy defaultProxy)
        {
            SetDefaultProxy(defaultProxy);

            defaultProxy.DisplayerDeleted -= defaultProxy_DisplayerDeleted;
            defaultProxy.DisplayerDeleted += defaultProxy_DisplayerDeleted;
            defaultProxy.DisplayerSelected -= DefaultProxyDisplayerSelected;
            defaultProxy.DisplayerSelected += DefaultProxyDisplayerSelected;


            previousPositonsDisplayrList = new List<IDisplayer>();
            nextPositonsDisplayrList = new List<IDisplayer>();

            reference_DisplayerRequestedEventHandler = ReferenceDisplayerRequested;
        }

        #endregion

        #region private void ReferenceDisplayerRequested(object sender, ReferenceEventArgs e)
        private void ReferenceDisplayerRequested(object sender, ReferenceEventArgs e)
        {
            _useEvent = true;
            Display(sender, e);
            _useEvent = false;
        }
        #endregion

        #region private void ProcessControl(Control control)
        private EventHandler<ReferenceEventArgs> reference_DisplayerRequestedEventHandler;
        internal override void ProcessControl(Control control)
        {
            if (control is IReference)
            {
                IReference reference = control as IReference;
                reference.DisplayerRequested -= reference_DisplayerRequestedEventHandler;
                reference.DisplayerRequested += reference_DisplayerRequestedEventHandler;
            }
            else if (control is ElementHost)
            {
                ElementHost host = (ElementHost) control;
                if (host.Child is IReference)
                {
                    IReference reference = host.Child as IReference;
                    reference.DisplayerRequested -= reference_DisplayerRequestedEventHandler;
                    reference.DisplayerRequested += reference_DisplayerRequestedEventHandler;
                }
            }
        }
        #endregion

        #region internal override void UnProcessControl(Control control)
        internal override void UnProcessControl(Control control)
        {
            if (control is IReference)
            {
                IReference reference = control as IReference;
                reference.DisplayerRequested -= reference_DisplayerRequestedEventHandler;
            }
        }
        #endregion

        #region private void Display(object sender, ReferenceEventArgs e)

        /// <summary>
        /// Request displaying operation for parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Parameters of request</param>
        internal void Display(object sender, ReferenceEventArgs e)
        {
            if (e.Cancel)
                return;
            if (e.TypeOfReflection == ReflectionTypes.DisplayInCurrent)
            {
                DisplayAtCurrent(e.RequestedEntity, e.DisplayerText);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.DisplayInExisting)
            {
                DisplayAtExisting(e.RequestedEntity, e.DestinationDisplayer, e.DisplayerText);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.CloseSelected)
            {
                CloseSelected();
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.CloseDisplayerContainingEntity)
            {
                CloseEntityContainingDisplayer(e);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.CloseAll)
            {
                CloseAll();
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.CloseAllButSelected)
            {
                CloseAllButSelected();
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.CloseAllButSome)
            {
                CloseAllButSome(e.DestinationDisplayer);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.ChangeText)
            {
                ChangeText(e.DestinationDisplayer, e.DisplayerText);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.ChangeTextOfSelected)
            {
                ChangeSelectedText(e.DisplayerText);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.ChangeTextOfContainingDisplayer)
            {
                ChangeTextOfContaingDisplayer(sender, e.DisplayerText);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.DisplayNextPage)
            {
                DisplayNextPage();
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.DisplayPreviousPage)
            {
                DisplayPreviousPage();
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.DisplayFewPages)
            {
                DisplayFewPages(e.RequestedDisplayingObject);
                return;
            }
            if (e.TypeOfReflection == ReflectionTypes.DisplayInNewWithCloseCurrent)
            {
                DisplayAtNewWithCloseCurrent(e.RequestedEntity, e.DisplayerText);
                return;
            }

            Display(e.RequestedEntity, e.DisplayerText);
        }


        #endregion

        #region private void CloseAllButSome(IDisplayer notClosedDisplayer)

        private void CloseAllButSome(IDisplayer notClosedDisplayer)
        {
            for (int i = 0; i < defaultProxy.ContainedDisplayers.Length; i++)
            {
                IDisplayer displayer = defaultProxy.ContainedDisplayers[i];
                if (notClosedDisplayer != displayer)
                    defaultProxy.Remove(displayer, true);
            }
        }

        #endregion

        #region private void CloseAllButSelected()

        private void CloseAllButSelected()
        {
            CloseAllButSome(defaultProxy.Selected);
        }

        #endregion

        #region private void CloseAll()

        private void CloseAll()
        {
            CloseAllButSome(null);
        }

        #endregion

        #region private void CloseEntityContainingDisplayer(ReferenceEventArgs e)

        private void CloseEntityContainingDisplayer(ReferenceEventArgs e)
        {
            if (e.RequestedEntity == null)
                throw new ArgumentNullException("RequestedEntity", "Entity of request cannot be null");
            for (int i = 0; i < defaultProxy.ContainedDisplayers.Length; i++)
            {
                if (defaultProxy.ContainedDisplayers[i].Entity == e.RequestedEntity)
                {
                    defaultProxy.Remove(defaultProxy.ContainedDisplayers[i], true);
                    return;
                }
            }
        }

        #endregion

        #region private void CloseSelected()
        /// <summary>
        /// Closes the currently selected IDisplayer
        /// </summary>
        private void CloseSelected()
        {
            defaultProxy.Remove(defaultProxy.Selected, true);
        }
        #endregion

        #region private void ChangeTextOfContaingDisplayer(object sender, string newText)

        private void ChangeTextOfContaingDisplayer(object sender, string newText)
        {
            Control current = sender as Control;
            while (current != null && !(current is IDisplayer))
            {
                current = current.Parent;
            }
            if (current != null)
                ChangeText(current as IDisplayer, newText);
        }

        #endregion

        #region private void ChangeSelectedText(string newText)

        private void ChangeSelectedText(string newText)
        {
            ChangeText(defaultProxy.Selected, newText);
        }

        #endregion

        #region private void ChangeText(IDisplayer displayer, string newText)

        private void ChangeText(IDisplayer displayer, string newText)
        {
            displayer.Text = newText;
        }

        #endregion

        #region private void DisplayAtExisting(DisplayingEntity entity, IDisplayer displayer, string displayerText)
        /// <summary>
        /// Request operation to display specified entity at specified displayer
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="displayer"></param>
        /// <param name="displayerText">text of displayer's header</param>
        private void DisplayAtExisting(IDisplayingEntity entity, IDisplayer displayer, string displayerText)
        {
            if (displayer != null)
            {
                DisplayAt(entity, displayer, displayerText);
            }
            else
            {
                Display(entity, displayerText);
            }
        }
        #endregion

        #region private void DisplayAtCurrent(DisplayingEntity entity, string displayerText)
        /// <summary>
        /// Request operation to display specified entity at current displayer
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="displayerText">text of displayer's header</param>
        private void DisplayAtCurrent(IDisplayingEntity entity, string displayerText)
        {
            if (defaultProxy.Selected != null)
            {
                DisplayAt(entity, defaultProxy.Selected, displayerText);
            }
            else
            {
                Display(entity, displayerText);
            }
        }
        #endregion

        #region private void DisplayAtCurrentWithRemoveLastEntity(DisplayingEntity entity, string displayerText)
        /// <summary>
        /// Request operation to display specified entity at current displayer
        /// </summary>
        /// <param name="entity">Entity to display</param>
        /// <param name="displayerText">text of displayer's header</param>
        private void DisplayAtNewWithCloseCurrent(IDisplayingEntity entity, string displayerText)
        {
            if (defaultProxy.Selected != null)
            {
                defaultProxy.Remove(defaultProxy.Selected, true);
                Display(entity, displayerText);
            }
            else
            {
                Display(entity, displayerText);
            }
        }
        #endregion

        #region private void DisplayNextPage()

        /// <summary>
        /// Display next page
        /// </summary>
        private void DisplayNextPage()
        {
            //if (nextPositonsDisplayrList.Count != 0)
            //{
            //IDisplayer displayer = nextPositonsDisplayrList[nextPositonsDisplayrList.Count - 1];
            //defaultProxy.Select(displayer);
            //nextPositonsDisplayrList.Remove(displayer);
            //previousPositonsDisplayrList.Remove(currentDisplayer);
            //previousPositonsDisplayrList.Add(currentDisplayer);
            //currentDisplayer = displayer;    
            _currentDisplayer.NextPage();
            //}
        }

        #endregion

        #region private void DisplayPreviousPage()

        /// <summary>
        /// Display previous page
        /// </summary>
        private void DisplayPreviousPage()
        {
            //useChangePositionCapability = true;
            //if (previousPositonsDisplayrList.Count != 0)
            //{
            //IDisplayer displayer = previousPositonsDisplayrList[previousPositonsDisplayrList.Count - 1];
            //defaultProxy.Select(displayer);
            //previousPositonsDisplayrList.Remove(displayer);
            //nextPositonsDisplayrList.Remove(currentDisplayer);
            //nextPositonsDisplayrList.Add(currentDisplayer);
            //currentDisplayer = displayer;
            _currentDisplayer.PreviousPage();

            // }
        }

        #endregion

        #region private void DisplayFewPages(DisplayingObject[] entityes)
        /// <summary>
        /// Display few pages
        /// </summary>
        /// <param name="entityes">Pages</param>
        private void DisplayFewPages(DisplayingObject[] entityes)
        {
            if (entityes != null)
                if (entityes.Length != 0)
                {
                    for (int i = 0; i < entityes.Length; i++)
                    {
                        Display(entityes[i].DisplayingEntity, entityes[i].DisplayingText);
                    }
                }
        }

        #endregion

        #region internal void Display(IDisplayingEntity objectToDisplay, string displayerText)
        /// <summary>
        /// ¬ытаетс€ выбрать отображатель дл€ содержимого или создать новый отображатель
        /// </summary>
        /// <param name="objectToDisplay">—одержимое дл€ отображател€</param>
        /// <param name="displayerText">“екст отображател€ (вкладки)</param>
        internal void Display(IDisplayingEntity objectToDisplay, string displayerText)
        {
            if (objectToDisplay == null) //throw new ArgumentNullException("objectToDisplay");
                return;

            foreach (IDisplayer displayer in defaultProxy.ContainedDisplayers)
            {
                //if (displayer.Entity.ContainedDataEquals(objectToDisplay))
                if (displayer.Text == displayerText)
                {
                    // displayer.Text = displayerText;
                    defaultProxy.Select(displayer);
                    StorePageOrder(displayer);
                    return;
                }
            }
            IDisplayer newDisplayer = defaultProxy.CreateNewDisplayer(objectToDisplay, displayerText);
            defaultProxy.Add(newDisplayer);
            defaultProxy.Select(newDisplayer);
            StorePageOrder(newDisplayer);



            objectToDisplay.OnInitCompletion(defaultProxy);
        }
        #endregion

        #region internal void DisplayAt(IDisplayingEntity objectToDisplay, IDisplayer destination, string displayerText)
        /// <summary>
        /// Display entity at specified displayer 
        /// </summary>
        /// <param name="objectToDisplay">entity to be displayed</param>
        /// <param name="destination">destination displayer</param>
        internal void DisplayAt(IDisplayingEntity objectToDisplay, IDisplayer destination)
        {
            if (objectToDisplay == null) throw new ArgumentNullException("objectToDisplay");
            if (destination == null) throw new ArgumentNullException("destination");
            if (defaultProxy.Contains(destination))
            {
                defaultProxy.Select(destination);
            }
            else
            {
                defaultProxy.Add(destination);
            }
            destination.Show(objectToDisplay);
            
            objectToDisplay.OnInitCompletion(defaultProxy);
        }

        /// <summary>
        /// Display entity at specified displayer 
        /// </summary>
        /// <param name="objectToDisplay">entity to be displayed</param>
        /// <param name="destination">destination displayer</param>
        /// <param name="displayerText">text of displayer's header</param>
        internal void DisplayAt(IDisplayingEntity objectToDisplay, IDisplayer destination, string displayerText)
        {
            if (destination == null) throw new ArgumentNullException("destination");

            destination.Text = displayerText;
            DisplayAt(objectToDisplay, destination);
        }
        #endregion

        #region void DefaultProxyDisplayerSelected(object sender, DisplayerEventArgs e)

        void DefaultProxyDisplayerSelected(object sender, DisplayerEventArgs e)
        {
            if (!_useEvent)
            {
                IDisplayer displayer = e.Displayer;
                StorePageOrder(displayer);
            }
        }


        #endregion

        #region private void StorePageOrder(IDisplayer displayer)

        private void StorePageOrder(IDisplayer displayer)
        {
            //if (currentDisplayer != null)
            //{
            //    previousPositonsDisplayrList.Remove(displayer);
            //    nextPositonsDisplayrList.Remove(displayer);
            //    previousPositonsDisplayrList.Remove(currentDisplayer);
            //    nextPositonsDisplayrList.Remove(currentDisplayer);
            //    if (nextPositonsDisplayrList.Count == 0)
            //    {
            //        previousPositonsDisplayrList.Add(currentDisplayer);
            //    }
            //    else
            //    {
            //        previousPositonsDisplayrList.AddRange(nextPositonsDisplayrList);
            //        previousPositonsDisplayrList.Add(currentDisplayer);
            //        nextPositonsDisplayrList.Remove(currentDisplayer);
            //    }
            //}
            _currentDisplayer = displayer;
        }

        #endregion

        #region private void defaultProxy_DisplayerDeleted(object sender, DisplayerEventArgs e)

        private void defaultProxy_DisplayerDeleted(object sender, DisplayerEventArgs e)
        {
            DispatcheredTabPage tabPage = e.Displayer as DispatcheredTabPage;
            if (tabPage != null && !tabPage.IsDisposed)
            {
                tabPage.Dispose();
            }
            //nextPositonsDisplayrList.Remove(e.Displayer);
            //previousPositonsDisplayrList.Remove(e.Displayer);
            //currentDisplayer = null;
        }

        #endregion

    }


}
