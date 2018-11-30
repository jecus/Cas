using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASTerms;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Класс для отображения коллекции элементов управления,унаследованных от IDisplayer
    /// </summary>
    internal class Dispatcher
    {
        #region Fields
        private Form _controlledForm;
        private ControlType _actionApplied = ControlType.Exit;
        
        /// <summary>
        /// Proxy for collection of Displayers
        /// </summary>
        private IDisplayerCollectionProxy _defaultProxy;
        private List<IDispatcher> dispatchers;
        private DisplayDispatcher displayDispatcher;

        #endregion

        #region Constructors
        /// <summary>
        /// Creates new instance of Dispathcer, for specified Proxy
        /// </summary>
        /// <param name="defaultProxy">Proxy, to be observed and dispatchered</param>
        /// <param name="controlledForm">Контролируемая форма</param>
        public Dispatcher(IDisplayerCollectionProxy defaultProxy, Form controlledForm)
        {
            _controlledForm = controlledForm;
            dispatchers = new List<IDispatcher>(2);
            displayDispatcher = new DisplayDispatcher(defaultProxy);
            dispatchers.Add(displayDispatcher);
            dispatchers.Add(new HelpDispatcher(defaultProxy));
            SetDefaultProxy(defaultProxy);
        }
        #endregion

        #region public ControlType ActionApplied
        /// <summary>
        /// Тип действия над приложением
        /// </summary>
        public ControlType ActionApplied
        {
            get { return _actionApplied; }
            set { _actionApplied = value; }
        }
        #endregion

        #region public Form ControlledForm
        /// <summary>
        /// Контролируемая форма
        /// </summary>
        public Form ControlledForm
        {
            get { return _controlledForm; }
            set { _controlledForm = value; }
        }
        #endregion

        #region public IDisplayerCollectionProxy DefaultProxy
        /// <summary>
        /// Proxy, defaultly controlled
        /// </summary>
        public IDisplayerCollectionProxy DefaultProxy
        {
            get { return _defaultProxy; }
            set { SetDefaultProxy(value); }
        }
        #endregion
        
        #region private void SetDefaultProxy(IDisplayerCollectionProxy proxy)
        private void SetDefaultProxy(IDisplayerCollectionProxy proxy)
        {
            if (proxy == null) throw new ArgumentNullException("proxy");
            _defaultProxy = proxy;
            for (int i = 0; i < dispatchers.Count; i++)
            {
                dispatchers[i].SetDefaultProxy(proxy);
            }
            ProcessControl(_defaultProxy as Control);
        }
        #endregion

        #region private void DefaultProxyControlsControlAdded(object sender, ControlEventArgs e)
        private void DefaultProxyControlsControlAdded(object sender, ControlEventArgs e)
        {
            ProcessControl(e.Control);
        }
        #endregion

        #region private void ControlDisposed(object sender, EventArgs e)
        private void ControlDisposed(object sender, EventArgs e)
        {
            UnProcessControl(sender as Control);
        }
        #endregion

        #region public void ProcessControl(Control control)
        public void ProcessControl(Control control)
        {
            control.ControlAdded -= DefaultProxyControlsControlAdded;
            control.ControlAdded += DefaultProxyControlsControlAdded;
            control.Disposed -= ControlDisposed;
            control.Disposed += ControlDisposed;

            foreach (Control c in control.Controls)
            {
                if (c is IApplicationControlRequester)
                {
                    //Предватирельное отписание от события, что бы один и тот же подписчик
                    //не подписывался на событие 2 и более раз
                    (c as IApplicationControlRequester).ControlRequest -= DispatcherControlRequest;
                    //Подписка на событие
                    (c as IApplicationControlRequester).ControlRequest += DispatcherControlRequest;
                }
                ProcessControl(c);
            }
            foreach (IDispatcher t in dispatchers)
            {
                t.ProcessControl(control);
            }
        }
        #endregion

        #region private void DispatcherControlRequest(object sender, ApplicationControlRequestArgs e)

        private void DispatcherControlRequest(object sender, ApplicationControlRequestArgs e)
        {
            _actionApplied = e.ControlType;
            //if (e.ControlType == ControlType.Exit || e.ControlType == ControlType.LogOut)
            //{
            //    IDisplayer[] displayers = _defaultProxy.ContainedDisplayers;
            //    foreach (IDisplayer displayer in displayers)
            //    {
            //        DisplayerCancelEventArgs arguments = new DisplayerCancelEventArgs(displayer, ControlType.Exit);
            //        displayer.OnDisplayerRemoved(arguments);
            //        if (arguments.Cancel)
            //        {
            //            e.Cancel = true;
            //            return;
            //        }
            //        if(_defaultProxy.ContainedDisplayers.Length > 1)
            //        {
            //            _defaultProxy.Remove(displayer, false);
            //        }
            //    }
            //}
            //GlobalObjects.CasEnvironment.Disconnect();
            //_controlledForm.Close(); 
            if (e.ControlType == ControlType.Exit)
            {
                IDisplayer[] displayers = _defaultProxy.ContainedDisplayers;
                foreach (IDisplayer displayer in displayers)
                {
                    DisplayerCancelEventArgs arguments = new DisplayerCancelEventArgs(displayer, ControlType.Exit);
                    displayer.OnDisplayerRemoving(arguments);
                    if (arguments.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    //Оповещение о окончании удаления вкладки
                    displayer.OnDisplayerRemoved(arguments);
                    //Если вкладка запросила отменить закрытие, операция прекращается
                    if (arguments.Cancel)
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (_defaultProxy.ContainedDisplayers.Length > 1)
                    {
                        _defaultProxy.Remove(displayer, false);
                    }
                }
                GlobalObjects.CasEnvironment.Disconnect();
                _controlledForm.Close();
            }

            if (e.ControlType == ControlType.LogOut)
            {
                IDisplayer[] displayers = _defaultProxy.ContainedDisplayers;
                foreach (IDisplayer displayer in displayers)
                {
                    DisplayerCancelEventArgs arguments = new DisplayerCancelEventArgs(displayer, ControlType.Exit);
                    displayer.OnDisplayerRemoving(arguments);
                    if (arguments.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    //Оповещение о окончании удаления вкладки
                    displayer.OnDisplayerRemoved(arguments);
                    //Если вкладка запросила отменить закрытие, операция прекращается
                    if (arguments.Cancel)
                    {
                        e.Cancel = true;
                        break;
                    }

                    if (_defaultProxy.ContainedDisplayers.Length > 1)
                    {
                        _defaultProxy.Remove(displayer, false);
                    }
                }
                GlobalObjects.CasEnvironment.Disconnect();

                _defaultProxy.ContainedDisplayers[0].Text = "Login";
                _defaultProxy.ContainedDisplayers[0].Entity =
                    new DispatcheredUIControls.MainControls.DispatcheredUILoginPage
                    {
                        BackColor = System.Drawing.Color.White,
                        Displayer = null,
                        DisplayerText = "Login",
                        Dock = DockStyle.Fill,
                        Location = new System.Drawing.Point(0, 0),
                        Margin = new Padding(4, 4, 4, 4),
                        ReflectionType = ReflectionTypes.CloseDisplayerContainingEntity,
                    };
                //_defaultProxy.ContainedDisplayers[0].Entity =
                //    new OperatorSummaryScreen(GlobalObjects.CasEnvironment.Operators[0]);
            }
        }

        #endregion

        #region private void ProcessControl(Control control)

        private void UnProcessControl(Control control)
        {
            if(control == null)return;
            control.ControlAdded -= DefaultProxyControlsControlAdded;
            control.Disposed -= ControlDisposed;

            foreach (Control c in control.Controls)
            {
                if (c is IApplicationControlRequester)
                {
                    (c as IApplicationControlRequester).ControlRequest -= DispatcherControlRequest;
                }
                UnProcessControl(c);
            }
            foreach (IDispatcher t in dispatchers)
            {
                t.UnProcessControl(control);
            }
        }
        #endregion

        #region public void DisplayerRequest(ReferenceEventArgs args)
        public void DisplayerRequest(ReferenceEventArgs args)
        {
            ((DisplayDispatcher)dispatchers[0]).Display(null, args);
        }
        #endregion
    }
}