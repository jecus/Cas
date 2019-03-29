using System;
using System.Windows.Forms;

namespace CAS.UI.Interfaces
{
    internal abstract class IDispatcher
    {
        #region Fields
        /// <summary>
        /// Proxy for collection of Displayers
        /// </summary>
        protected IDisplayerCollectionProxy defaultProxy;
        #endregion

        #region private void SetDefaultProxy(IDisplayerCollectionProxy proxy)
        internal virtual void SetDefaultProxy(IDisplayerCollectionProxy proxy)
        {
            if (proxy == null) throw new ArgumentNullException("proxy");
            defaultProxy = proxy;
        }
        #endregion

        /// <summary>
        /// Производит присоединение обработчиков к некоторым событиям контрола
        /// </summary>
        /// <param name="control">Контрол, события которого нужно отслеживать</param>
        internal abstract void ProcessControl(Control control);

        /// <summary>
        /// Производит отписку обработчиков некоторый событий контрола
        /// </summary>
        /// <param name="control">Контрол, от событий которого необходимо отписаться</param>
        internal abstract void UnProcessControl(Control control);
    }
}