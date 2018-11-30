using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Core.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering
{
    /// <summary>
    /// Class for dispatchering collection of IDisplayers
    /// </summary>
    internal class Dispatcher
    {
        #region Fields
        private Form controlledForm;
        private ControlType actionApplied = ControlType.Exit;
        
        /// <summary>
        /// Proxy for collection of Displayers
        /// </summary>
        private IDisplayerCollectionProxy defaultProxy;
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
            this.controlledForm = controlledForm;
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
            get { return actionApplied; }
            set { actionApplied = value; }
        }
        #endregion

        #region public Form ControlledForm
        /// <summary>
        /// Контролируемая форма
        /// </summary>
        public Form ControlledForm
        {
            get { return controlledForm; }
            set { controlledForm = value; }
        }
        #endregion

        #region public IDisplayerCollectionProxy DefaultProxy
        /// <summary>
        /// Proxy, defaultly controlled
        /// </summary>
        public IDisplayerCollectionProxy DefaultProxy
        {
            get { return defaultProxy; }
            set { SetDefaultProxy(value); }
        }
        #endregion
        
        #region private void SetDefaultProxy(IDisplayerCollectionProxy proxy)
        private void SetDefaultProxy(IDisplayerCollectionProxy proxy)
        {
            if (proxy == null) throw new ArgumentNullException("proxy");
            defaultProxy = proxy;
            for (int i = 0; i < dispatchers.Count; i++)
            {
                dispatchers[i].SetDefaultProxy(proxy);
            }
            ProcessControl(defaultProxy as Control);
        }
        #endregion

        #region private void defaultProxyControls_ControlAdded(object sender, ControlEventArgs e)
        private void defaultProxyControls_ControlAdded(object sender, ControlEventArgs e)
        {
            ProcessControl(e.Control);
        }
        #endregion
        
        #region private void ProcessControl(Control control)
        private void ProcessControl(Control control)
        {
            control.ControlAdded -= defaultProxyControls_ControlAdded;
            control.ControlAdded += defaultProxyControls_ControlAdded;
            foreach (Control c in control.Controls)
            {
                if (c is IApplicationControlRequester)
                    (c as IApplicationControlRequester).ControlRequest += Dispatcher_ControlRequest;
                ProcessControl(c);
            }
            for (int i = 0; i < dispatchers.Count; i++)
            {
                dispatchers[i].ProcessControl(control);
            }
        }
        #endregion

        #region private void Dispatcher_ControlRequest(object sender, ApplicationControlRequestArgs e)

        private void Dispatcher_ControlRequest(object sender, ApplicationControlRequestArgs e)
        {
            actionApplied = e.ControlType;
            if (e.ControlType == ControlType.Exit || e.ControlType == ControlType.LogOut)
            {
                IDisplayer[] displayers = defaultProxy.ContainedDisplayers;
                foreach (IDisplayer displayer in displayers)
                {
                    DisplayerCancelEventArgs arguments = new DisplayerCancelEventArgs(displayer, ControlType.Exit);
                    displayer.OnDisplayerRemoved(arguments);
                    if (arguments.Cancel)
                    {
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        defaultProxy.Remove(displayer, false);
                    }
                }
            }
            ConnectionManager.Disconnect();
            controlledForm.Close();
        }

        #endregion

    }
}